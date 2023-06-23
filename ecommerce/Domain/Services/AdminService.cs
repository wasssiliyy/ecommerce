using ecommerce.DataAccess.Abstractions;
using ecommerce.DataAccess.Concrete;
using ecommerce.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Services
{
    public class AdminService
    {
        private IRepository<Admin> _repository;

        public AdminService()
        {
            _repository = new AdminRepository();
        }

        public Admin GetAdminByNameAndPassword(string username, string password)
        {
            var admins = _repository.GetAll();
            var admin = admins.FirstOrDefault(f => f.Username == username && f.Password == password);
            return admin;
        }
    }
}
