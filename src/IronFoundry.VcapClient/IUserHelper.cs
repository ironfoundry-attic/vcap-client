using System.Collections.Generic;
using IronFoundry.Models;

namespace IronFoundry.VcapClient
{
    public interface IUserHelper
    {
        void Login(string email, string password);
        void ChangePassword(string user, string newPassword);
        void AddUser(string email, string password);
        void DeleteUser(string email);
        VcapUser GetUser(string email);
        IEnumerable<VcapUser> GetUsers();
        string GetApplicationJson(string name);
        Application GetApplication(string name);
        IEnumerable<Application> GetApplications(string proxyUser = null);
    }
}