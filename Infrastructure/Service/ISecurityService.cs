﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface ISecurityService
    {
        void AddUsersToRoles(string[] usernames, string[] roleNames);

        void CreateRole(string roleName);

        bool DeleteRole(string roleName, bool throwOnPopulatedRole);

        string[] FindUsersInRole(string roleName, string usernameToMatch);

        string[] GetAllRoles();

        string[] GetRolesForUser(string username);

        string[] GetUsersInRole(string roleName);

        bool IsUserInRole(string username, string roleName);

        void RemoveUsersFromRoles(string[] usernames, string[] roleNames);

        bool RoleExists(string roleName);
    }
}
