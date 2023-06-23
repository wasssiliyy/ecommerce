using ecommerce.Commands;
using ecommerce.DataAccess.SqlServer;
using ecommerce.Domain.Services;
using ecommerce.Domain.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ecommerce.Domain.ViewModels
{
    public class InsertUpdateWindowViewModel : BaseViewModel
    {
        public RelayCommand InsertButton { get; set; }
        public RelayCommand UpdateButton { get; set; }
        public RelayCommand SelectionChanged { get; set; }
        public RelayCommand RefreshButton { get; set; }


        private ObservableCollection<Product> productsItemSource;

        public ObservableCollection<Product> ProductsItemSource
        {
            get { return productsItemSource; }
            set { productsItemSource = value; OnPropertyChanged(); }
        }


        private Product selectedItemProduct;

        public Product SelectedItemProduct
        {
            get { return selectedItemProduct; }
            set { selectedItemProduct = value; OnPropertyChanged(); }
        }

        private ProductService _productService;

        public InsertUpdateWindowViewModel()
        {
            _productService = new ProductService();

            ProductsItemSource = _productService.GetAllProducts();

            //SelectionChanged = new RelayCommand((obj) =>
            //{
            //    MessageBox.Show($"{SelectedItemProduct.Name}");
            //});

            InsertButton = new RelayCommand((obj) =>
            {
                InsertWindow insertWindow = new InsertWindow();
                insertWindow.ShowDialog();
            });

            UpdateButton = new RelayCommand((obj) =>
            {
                if (SelectedItemProduct != null)
                {
                    UpdateWindowViewModel updateWindowView = new UpdateWindowViewModel();
                    UpdateWindow updateWindow = new UpdateWindow();
                    updateWindowView.ProductId = SelectedItemProduct.Id;
                    updateWindowView.OldProductName = SelectedItemProduct.Name;
                    updateWindowView.OldProductPrice = SelectedItemProduct.Price;
                    updateWindowView.OldProductQuantity = SelectedItemProduct.Quantity;
                    updateWindowView.OldProductDiscount = (float)SelectedItemProduct.Discount;
                    updateWindowView.OldProductDescription = SelectedItemProduct.Description;
                    updateWindow.DataContext = updateWindowView;
                    updateWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"After selecting the item you want to change from the table above, click the update button");
                }
            });

            RefreshButton = new RelayCommand((obj) =>
            {
                _productService = new ProductService();
                ProductsItemSource = _productService.GetAllProducts();
            });
        }
    }
}
