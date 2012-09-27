// -----------------------------------------------------------------------
// <copyright file="BaseVmcHelper.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using IronFoundry.Models;
using Newtonsoft.Json;
using RestSharp;

namespace IronFoundry.VcapClient
{
    internal abstract class BaseVmcHelper
    {
        protected readonly VcapCredentialManager credentialManager;
        protected readonly VcapUser proxyUser;

        protected BaseVmcHelper(VcapUser proxyUser, VcapCredentialManager credentialManager)
        {
            this.proxyUser = proxyUser;
            this.credentialManager = credentialManager;
        }

        private string ProxyUserEmail
        {
            get
            {
                string proxyUserEmail = null;

                if (null != proxyUser)
                {
                    proxyUserEmail = proxyUser.Email;
                }

                return proxyUserEmail;
            }
        }

        public string GetApplicationJson(string name)
        {
            VcapRequest vcapRequest = BuildVcapRequest(Constants.AppsResource, name);
            return vcapRequest.Execute().Content;
        }

        public Application GetApplication(string name)
        {
            string json = GetApplicationJson(name);
            return JsonConvert.DeserializeObject<Application>(json);
        }

        public IEnumerable<Application> GetApplications(string proxy_user = null)
        {
            VcapRequest vcapRequest = BuildVcapRequest(Constants.AppsResource);
            return vcapRequest.Execute<Application[]>();
        }

        protected bool AppExists(string name)
        {
            bool rv = true;
            try
            {
                string appJson = GetApplicationJson(name);
            }
            catch (VcapNotFoundException)
            {
                rv = false;
            }
            return rv;
        }

        protected VcapRequest BuildVcapRequest(params object[] resourceParams)
        {
            return new VcapRequest(ProxyUserEmail, credentialManager, resourceParams);
        }

        protected VcapRequest BuildVcapRequest(bool useAuth, Uri uri, params object[] resourceParams)
        {
            return new VcapRequest(ProxyUserEmail, credentialManager, useAuth, uri, resourceParams);
        }

        protected VcapRequest BuildVcapRequest(Method method, params string[] resourceParams)
        {
            return new VcapRequest(ProxyUserEmail, credentialManager, method, resourceParams);
        }

        protected VcapJsonRequest BuildVcapJsonRequest(Method method, params string[] resourceParams)
        {
            return new VcapJsonRequest(ProxyUserEmail, credentialManager, method, resourceParams);
        }
    }
}