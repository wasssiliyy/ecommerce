using ecommerce.DataAccess.SqlServer;
using ecommerce.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ecommerce.Domain.ViewModels
{
    public class OrdersWindowViewModel : BaseViewModel
    {
        private ObservableCollection<Order> allOrders;

        public ObservableCollection<Order> AllOrders
        {
            get { return allOrders; }
            set { allOrders = value; OnPropertyChanged(); }
        }

        //private string customerName;

        //public string CustomerName
        //{
        //    get { return customerName; }
        //    set { customerName = value; OnPropertyChanged(); }
        //}


        private readonly OrderService _OrderService;

        public OrdersWindowViewModel()
        {
            _OrderService = new OrderService();

            AllOrders = _OrderService.GetAllOrders();
        }

    }
}
