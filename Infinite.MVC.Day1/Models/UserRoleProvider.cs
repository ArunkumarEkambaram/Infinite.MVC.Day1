using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Infinite.MVC.Day1.Models
{
    public class UserRoleProvider : RoleProvider
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
            //throw new NotImplementedException();
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                // var user = dbContext.Users.FirstOrDefault(x => x.Username == username);
                //var roles = user.UserRolesMappings == null ? new string[] { } : user.UserRolesMappings.Select(u => u.Role).Select(u => u.RoleName).ToArray();
                //var roles = dbContext.Users
                //    .Join(dbContext.UserRolesMappings, u => u.Id, ur => ur.UserId, (u, ur) => new { u, ur })
                //    .Where(x => x.u.Username == username)
                //    .Join(dbContext.Roles, uur => uur.ur.RoleId, r => r.Id, (uur, r) => new { uur, r })
                //    .Select(x => new
                //    {
                //        RoleName = x.r.RoleName
                //    });

                var roles = (from user in dbContext.Users join userrole in dbContext.UserRolesMappings on user.Id equals userrole.UserId
                             join role in dbContext.Roles on userrole.RoleId equals role.Id
                             where user.Username == username select role.RoleName).ToArray();                
                return roles;
            }
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