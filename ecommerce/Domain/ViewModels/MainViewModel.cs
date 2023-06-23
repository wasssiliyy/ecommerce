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

namespace ecommerce.Domain.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        public RelayCommand ToLowerCommand { get; set; }
        public RelayCommand SelectProductCommand { get; set; }
        public RelayCommand AdminButton { get; set; }
        public RelayCommand RefreshButton { get; set; }


        private ProductService _productService;

        public MainViewModel()
        {
            _productService = new ProductService();
            FilterText = "Higher To Lower";

            AllProducts = _productService.GetFromHigherToLower(IsLower);


            ToLowerCommand = new RelayCommand((obj) =>
            {
                IsLower = !IsLower;
                if (!IsLower)
                {
                    FilterText = "Lower To Higher";
                }
                else
                {
                    FilterText = "Higher To Lower";
                }
                AllProducts = _productService.GetFromHigherToLower(IsLower);
            });

            RefreshButton = new RelayCommand((obj) =>
            {
                _productService = new ProductService();
                AllProducts = _productService.GetFromHigherToLower(IsLower);
            });


            SelectProductCommand = new RelayCommand((obj) =>
            {
                var vm = new ProductInfoViewModel();
                vm.ProductInfo = SelectedProduct;
                var view = new ProductWindow();
                view.DataContext = vm;
                view.ShowDialog();
            });

            AdminButton = new RelayCommand((obj) =>
            {
                AdminInputWindow adminInputWindow = new AdminInputWindow();
                adminInputWindow.ShowDialog();
                //var ad = _productService.AdminUserAndPasswords(UserName, Password);
                //if (ad)
                //{
                //    AdminWindow adminWindow = new AdminWindow();
                //    adminWindow.ShowDialog();
                //}
                //else
                //{
                //    MessageBox.Show("NO!!!!!!");
                //}
            });
        }

        public bool IsLower { get; set; } = true;

        private string filterText;

        public string FilterText
        {
            get { return filterText; }
            set { filterText = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Product> allProducts;

        public ObservableCollection<Product> AllProducts
        {
            get { return allProducts; }
            set { allProducts = value; OnPropertyChanged(); }
        }


        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged(); }
        }

    }
}
