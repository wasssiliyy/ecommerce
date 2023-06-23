using ecommerce.Commands;
using ecommerce.Domain.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.ViewModels
{
    public class AdminWindowViewModel : BaseViewModel
    {
        public RelayCommand OrdersButton { get; set; }
        public RelayCommand ProductsButton { get; set; }

        public AdminWindowViewModel()
        {
            OrdersButton = new RelayCommand((obj) =>
            {
                OrdersWindow ordersWindow = new OrdersWindow();
                ordersWindow.ShowDialog();
            });

            ProductsButton = new RelayCommand((obj) =>
            {
                InsertUpdateWindow productsWindow = new InsertUpdateWindow();
                productsWindow.ShowDialog();
            });
        }
    }
}
