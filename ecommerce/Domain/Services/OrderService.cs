using ecommerce.DataAccess.Abstractions;
using ecommerce.DataAccess.Concrete;
using ecommerce.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ecommerce.Domain.Services
{
    public class OrderService
    {
        private IRepository<Order> _repository;
        public OrderService()
        {
            _repository = new OrderRepository();
        }

        public ObservableCollection<Order> GetAllOrders()
        {
            var allOrders = _repository.GetAll();
            return allOrders;
        }

        public void AddOrder(Order order)
        {
            _repository.AddData(order);
        }
    }
}
