using GraciousGiver_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly GraciousDbContext _context;

        public UserRepository(GraciousDbContext context)
        {
            _context = context;
        }
        public User Create(User user)
        {
            _context.Users.Add(user);
            user.UserId = _context.SaveChanges();

            return user;
        }
        public Organization CreateOrg(Organization org)
        {
            _context.Organization.Add(org);
            org.OrganizationId = _context.SaveChanges();

            return org;
        }
        public User ChangePsw(User user)
        {
            _context.Users.Update(user);
            user.UserId = _context.SaveChanges();

            return user;
        }
        public Organization ChangeOrgPsw(Organization org)
        {
            _context.Organization.Update(org);
            org.OrganizationId = _context.SaveChanges();

            return org;
        }

        public object Generate(int userId)
        {
            throw new NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username);
        }
        public Organization GetOrgByUsername(string username)
        {
            return _context.Organization.FirstOrDefault(u => u.Username == username);
        }
        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id);
        }
        public Organization GetOrgById(int id)
        {
            return _context.Organization.FirstOrDefault(u => u.OrganizationId == id);
        }
    }
}
