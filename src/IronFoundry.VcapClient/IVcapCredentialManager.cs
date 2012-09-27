using System;
using System.Net;

namespace IronFoundry.VcapClient
{
    public interface IVcapCredentialManager
    {
        Uri CurrentTarget { get; }
        IPAddress CurrentTargetIp { get; }
        string CurrentToken { get; }
        bool HasToken { get; }
        void SetTarget(string uri);
        void SetTarget(Uri uri);
        void SetTarget(Uri uri, IPAddress ip);
        void RegisterToken(string token);
        void StoreTarget();
    }
}