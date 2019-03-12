using System;
using System.Linq;
using System.Web.Security;
using CarRentalMS.DataAccess;

namespace CarRentalMS.Services
{
    public class RoleProviderServices : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            AWS_POSTGREQL_TRIALEntities dbContext = new AWS_POSTGREQL_TRIALEntities();
            var UserList = dbContext.UserAccounts.ToList();
            string userRole = UserList.Where(u => u.UserName == username).Select(u => u.UserRole.Role).FirstOrDefault().ToString();
            string[] resultUserRole = { userRole };
            return resultUserRole;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
