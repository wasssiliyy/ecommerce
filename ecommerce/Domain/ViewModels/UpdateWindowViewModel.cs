using ecommerce.Commands;
using ecommerce.DataAccess.SqlServer;
using ecommerce.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ecommerce.Domain.ViewModels
{
    public class UpdateWindowViewModel : BaseViewModel
    {
        public int ProductId { get; set; }

        private string oldProductName;

        public string OldProductName
        {
            get { return oldProductName; }
            set { oldProductName = value; OnPropertyChanged(); }
        }

        private string oldProductDescription;

        public string OldProductDescription
        {
            get { return oldProductDescription; }
            set { oldProductDescription = value; OnPropertyChanged(); }
        }

        private decimal oldProductPrice;

        public decimal OldProductPrice
        {
            get { return oldProductPrice; }
            set { oldProductPrice = value; OnPropertyChanged(); }
        }

        private float oldProductDiscount;

        public float OldProductDiscount
        {
            get { return oldProductDiscount; }
            set { oldProductDiscount = value; OnPropertyChanged(); }
        }

        private int oldProductQuantity;

        public int OldProductQuantity
        {
            get { return oldProductQuantity; }
            set { oldProductQuantity = value; OnPropertyChanged(); }
        }

        public RelayCommand UpdateButton { get; set; }

        private ProductService _productService;

        public UpdateWindowViewModel()
        {
            _productService = new ProductService();

            UpdateButton = new RelayCommand((obj) =>
            {
                Product product = new Product();
                product.Id = ProductId;
                product.Name = OldProductName;
                product.Price = OldProductPrice;
                product.Quantity = OldProductQuantity;
                product.Description = OldProductDescription;
                product.Discount = OldProductDiscount;
                _productService.UpdateProduct(product);
                MessageBox.Show($"Product updated successfully.");
            });
        }
    }
}
