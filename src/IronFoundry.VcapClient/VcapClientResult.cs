// -----------------------------------------------------------------------
// <copyright file="VcapClientResult.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

using IronFoundry.Models;

namespace IronFoundry.VcapClient
{
    public class VcapClientResult
    {
        private readonly string _message;
        private readonly Message _responseMessage;
        private readonly bool _success = true;
        private readonly VcapResponse _vcapResponse;

        public VcapClientResult()
        {
            _success = true;
        }

        public VcapClientResult(bool argSuccess)
        {
            _success = argSuccess;
        }

        public VcapClientResult(bool argSuccess, string argMessage)
        {
            _success = argSuccess;
            _message = argMessage;
        }

        public VcapClientResult(bool argSuccess, VcapResponse argResponse)
        {
            _success = argSuccess;
            _vcapResponse = argResponse;
        }

        public VcapClientResult(bool argSuccess, Message argResponseMessage)
        {
            _success = argSuccess;
            _responseMessage = argResponseMessage;
        }

        public bool Success
        {
            get { return _success; }
        }

        public string Message
        {
            get
            {
                string rv;

                if (null == _vcapResponse)
                {
                    rv = _message;
                }
                else
                {
                    rv = _vcapResponse.Description; // TODO
                }

                return rv;
            }
        }

        public T GetResponseMessage<T>() where T : Message
        {
            return (T) _responseMessage;
        }
    }
}