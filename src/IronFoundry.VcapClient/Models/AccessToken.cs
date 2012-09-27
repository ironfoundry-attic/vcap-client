// -----------------------------------------------------------------------
// <copyright file="AccessToken.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace IronFoundry.Models
{
    public class AccessToken
    {
        private readonly string _token;
        private readonly Uri _uri;

        public AccessToken(Uri argUri, string argToken)
        {
            _uri = argUri;
            _token = argToken;
        }

        public AccessToken(string argUri, string argToken)
        {
            _uri = new Uri(argUri);
            _token = argToken;
        }

        public Uri Uri
        {
            get { return _uri; }
        }

        public string Token
        {
            get { return _token; }
        }

        public bool HasToken
        {
            get { return false == _token.IsNullOrWhiteSpace(); }
        }
    }
}