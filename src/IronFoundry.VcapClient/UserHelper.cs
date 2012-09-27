// -----------------------------------------------------------------------
// <copyright file="UserHelper.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using IronFoundry.Models;
using IronFoundry.VcapClient.Properties;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace IronFoundry.VcapClient
{
    internal class UserHelper : BaseVmcHelper, IUserHelper
    {
        public UserHelper(VcapUser proxyUser, VcapCredentialManager credentialManager)
            : base(proxyUser, credentialManager)
        {
        }

        public void Login(string email, string password)
        {
            var vcapJsonRequest = BuildVcapJsonRequest(Method.POST, Constants.UsersResource, email, "tokens");
            vcapJsonRequest.AddBody(new {password});

            try
            {
                var response = vcapJsonRequest.Execute();
                var parsed = JObject.Parse(response.Content);
                var token = parsed.Value<string>("token");
                credentialManager.RegisterToken(token);
            }
            catch (VcapAuthException)
            {
                throw new VcapAuthException(string.Format(Resources.Vmc_LoginFail_Fmt, credentialManager.CurrentTarget));
            }
        }

        public void ChangePassword(string user, string newPassword)
        {
            var request = BuildVcapRequest(Constants.UsersResource, user);
            var response = request.Execute();

            var parsed = JObject.Parse(response.Content);
            parsed["password"] = newPassword;

            var vcapJsonRequestPut = BuildVcapJsonRequest(Method.PUT, Constants.UsersResource, user);
            vcapJsonRequestPut.AddBody(parsed);
            vcapJsonRequestPut.Execute();
        }

        public void AddUser(string email, string password)
        {
            var vcapJsonRequest = BuildVcapJsonRequest(Method.POST, Constants.UsersResource);
            vcapJsonRequest.AddBody(new {email, password});
            vcapJsonRequest.Execute();
        }

        public void DeleteUser(string email)
        {
            // TODO: doing this causes a "not logged in" failure when the user
            // doesn't exist, which is kind of misleading.
            var appsHelper = new AppsHelper(proxyUser, credentialManager);
            foreach (var a in appsHelper.GetApplications(email))
            {
                appsHelper.Delete(a.Name);
            }

            var servicesHelper = new ServicesHelper(proxyUser, credentialManager);
            foreach (var ps in servicesHelper.GetProvisionedServices())
            {
                servicesHelper.DeleteService(ps.Name);
            }

            VcapJsonRequest r = BuildVcapJsonRequest(Method.DELETE, Constants.UsersResource, email);
            r.Execute();
        }

        public VcapUser GetUser(string email)
        {
            var vcapJsonRequest = BuildVcapJsonRequest(Method.GET, Constants.UsersResource, email);
            return vcapJsonRequest.Execute<VcapUser>();
        }

        public IEnumerable<VcapUser> GetUsers()
        {
            var vcapJsonRequest = BuildVcapJsonRequest(Method.GET, Constants.UsersResource);
            return vcapJsonRequest.Execute<VcapUser[]>();
        }
    }
}