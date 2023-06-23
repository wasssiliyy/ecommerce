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
    public class InsertWindowViewModel : BaseViewModel
    {
        public RelayCommand InsertButton { get; set; }
        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; OnPropertyChanged(); }
        }

        private string productDescription;

        public string ProductDescription
        {
            get { return productDescription; }
            set { productDescription = value; OnPropertyChanged(); }
        }

        private decimal productPrice;

        public decimal ProductPrice
        {
            get { return productPrice; }
            set { productPrice = value; OnPropertyChanged(); }
        }

        private int productDiscount;

        public int ProductDiscount
        {
            get { return productDiscount; }
            set { productDiscount = value; OnPropertyChanged(); }
        }

        private int productQuantity;

        public int ProductQuantity
        {
            get { return productQuantity; }
            set { productQuantity = value; OnPropertyChanged(); }
        }


        private readonly ProductService _productService;
        public InsertWindowViewModel()
        {
            _productService = new ProductService();
            InsertButton = new RelayCommand((obj) =>
            {
                try
                {
                    if (ProductQuantity > 0)
                    {
                        Product product = new Product();
                        product.Name = ProductName;
                        product.Description = ProductDescription;
                        product.Price = ProductPrice;
                        product.Discount = ProductDiscount;
                        product.Quantity = ProductQuantity;
                        _productService.AddProduct(product);
                        MessageBox.Show($"Your product has been successfully added");
                    }
                    else
                    {
                        MessageBox.Show("Product quantity cannot be 0 or less than 0 !!!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }
            });
        }
    }
}
