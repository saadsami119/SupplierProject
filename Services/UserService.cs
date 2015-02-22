using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Models;
using Infrastructure.Repository;
using Infrastructure.Service;


namespace Services
{
    public class UserService : Service<Users>, IUserService
    {
        private readonly IRepository<Users> _repository;

        public UserService(IRepository<Users> repository) // datacontext must be refactoredd to Icontext
            : base(repository)
        {
            _repository = repository;

        }

        public void GetUserInformation()
        {
            Users user = new Users();
            user.UserName = "s1";
            user.FirstName = "s1";
            user.LastName = "s1";
            user.Password = "s1";
            user.Email = "s1";

            base.Insert(user);
        }

        public void RegisterUser(Users user)
        {
            _repository.Create(user);
        }

        public bool VerifyUser(Users user)
        {
            return (_repository.GetAll().SingleOrDefault(x => x.UserName == user.UserName && x.Password == user.Password) != null)
                  ? true
                  : false;

        }

        public IEnumerable<Users> GetAllUsers()
        {
            return _repository.GetAll().AsEnumerable();
        }

        public void DeleteUser(int UserId)
        {
            Users user = _repository.GetAll().Single(x => x.Id  == UserId);
            _repository.Delete(user);
        }
    }
}
