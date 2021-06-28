using GraciousGiver_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Data
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetByUsername(string username);
        User GetById(int id);
        object Generate(int userId);
        User ChangePsw(User user);
    }
}
