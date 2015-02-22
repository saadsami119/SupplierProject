using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Infrastructure.Service;
using Infrastructure.Models;
using Infrastructure.Repository;

namespace Services
{
    public class SecurityService : Service<Roles>, ISecurityService
    {
        private readonly IRepository<Roles> _repository;

        public SecurityService(IRepository<Roles> repository)
            : base(repository)
        {
            this._repository = repository;
        }

        public void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            var role = new Roles { RoleName = "saad", RoleDescription = "asasa" };
            this._repository.Create(role);
        }

        public void CreateRole(string roleName)
        {
            Roles role = new Roles();
            role.RoleName = roleName;
            _repository.Create(role);
        }

        public bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            var itemToDelete = _repository.SingleOrDefault(x => x.RoleName == roleName);

            if (itemToDelete != null)
            {
                _repository.Delete(itemToDelete);
            }

            return true;
        }

        public string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public string[] GetRolesForUser(string username)
        {
            throw new NotImplementedException();
        }

        public string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
