using APIforUpcomingProjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIforUpcomingProjects.Services.IServices
{
    public interface IUserService
    {
        User Login(string username, string password);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User Register(User user, string password);
        void UpdateUser(User userParam, string password = null);
        void DeleteUser(int id);
    }
}
