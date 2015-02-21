using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Models;

namespace Infrastructure.Service
{
    public interface IUserService
    {
        void GetUserInformation();
        void RegisterUser(Users user);
        bool VerifyUser(Users user);
        IEnumerable<Users> GetAllUsers();
        void DeleteUser(int UserId);
    }
}
