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
    public class CustomerService
    {
        private IRepository<Customer> _repository;
        public CustomerService()
        {
            _repository = new CustomerRepository();
        }

        public Customer GetCustomerByUsername(string username)
        {
            var customers = _repository.GetAll();
            var customer = customers.FirstOrDefault(c => c.Username == username);
            return customer;
        }

        public Customer GetCustomerById(int id)
        {
            var customers = _repository.GetAll();
            var customer = customers.FirstOrDefault(c => c.Id == id);
            return customer;
        }
    }
}

