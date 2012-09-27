// -----------------------------------------------------------------------
// <copyright file="ServicesHelper.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using IronFoundry.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace IronFoundry.VcapClient
{
    internal class ServicesHelper : BaseVmcHelper
    {
        public ServicesHelper(VcapUser proxyUser, VcapCredentialManager credentialManager)
            : base(proxyUser, credentialManager)
        {
        }

        public IEnumerable<SystemService> GetSystemServices()
        {
            var vcapRequest = BuildVcapRequest(Constants.GlobalServicesResource);
            var response = vcapRequest.Execute();

            var list =
                JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, SystemService>>>>
                    (response.Content);

            var dataStores = from val in list.Values
                                                    from val1 in val.Values
                                                    from val2 in val1.Values
                                                    select val2;

            return dataStores.ToList();
        }

        public IEnumerable<ProvisionedService> GetProvisionedServices()
        {
            var vcapRequest = BuildVcapRequest(Constants.ServicesResource);
            return vcapRequest.Execute<ProvisionedService[]>();
        }

        public void CreateService(string serviceName, string provisionedServiceName)
        {
            var services = GetSystemServices();
            var service = services.FirstOrDefault(s => s.Vendor == serviceName);
            if (service != null)
            {
                // from vmc client.rb
                var data = new
                               {
                                   name = provisionedServiceName,
                                   type = service.Type,
                                   tier = "free",
                                   vendor = service.Vendor,
                                   version = service.Version,
                               };
                var vcapJsonRequest = BuildVcapJsonRequest(Method.POST, Constants.ServicesResource);
                vcapJsonRequest.AddBody(data);
                vcapJsonRequest.Execute();
            }
        }

        public void DeleteService(string provisionedServiceName)
        {
            var request = BuildVcapJsonRequest(Method.DELETE, Constants.ServicesResource,
                                                           provisionedServiceName);
            request.Execute();
        }

        public void BindService(string provisionedServiceName, string appName)
        {
            var apps = new AppsHelper(proxyUser, credentialManager);

            var app = apps.GetApplication(appName);
            app.AddService(provisionedServiceName);

            var request = BuildVcapJsonRequest(Method.PUT, Constants.AppsResource, app.Name);
            request.AddBody(app);
            request.Execute();

            // Ruby code re-gets info
            app = apps.GetApplication(appName);
            if (app.IsStarted)
            {
                apps.Restart(app);
            }
        }

        public void UnbindService(string provisionedServiceName, string appName)
        {
            var apps = new AppsHelper(proxyUser, credentialManager);
            var appJson = apps.GetApplicationJson(appName);
            var appParsed = JObject.Parse(appJson);
            var services = (JArray) appParsed["services"];
            appParsed["services"] = new JArray(services.Where(s => ((string) s) != provisionedServiceName));

            var vcapJsonRequest = BuildVcapJsonRequest(Method.PUT, Constants.AppsResource, appName);
            vcapJsonRequest.AddBody(appParsed);
            vcapJsonRequest.Execute();

            apps = new AppsHelper(proxyUser, credentialManager);
            apps.Restart(appName);
        }
    }
}