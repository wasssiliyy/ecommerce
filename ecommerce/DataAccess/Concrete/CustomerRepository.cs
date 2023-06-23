﻿using ecommerce.DataAccess.Abstractions;
using ecommerce.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.DataAccess.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly EECommerceDataContext _context;
        public CustomerRepository()
        {
            _context = new EECommerceDataContext();
        }
        public void AddData(Customer data)
        {
            throw new NotImplementedException();
        }

        public void DeleteData(Customer data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Customer> GetAll()
        {
            var result = from c in _context.Customers
                         orderby c.Username
                         select c;
            return new ObservableCollection<Customer>(result);
        }

        public Customer GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Customer data)
        {
            throw new NotImplementedException();
        }
    }
}
