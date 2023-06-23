using ecommerce.Commands;
using ecommerce.Domain.Services;
using ecommerce.Domain.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ecommerce.Domain.ViewModels
{
    public class AdminInputWindowViewModel : BaseViewModel
    {
        public RelayCommand LoginButton { get; set; }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; OnPropertyChanged(); }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }

        private readonly AdminService _adminService;


        public AdminInputWindowViewModel()
        {
            _adminService = new AdminService();

            LoginButton = new RelayCommand((obj) =>
            {
                var admin = _adminService.GetAdminByNameAndPassword(UserName, Password);
                if (admin != null)
                {
                    UserName = string.Empty;
                    Password = string.Empty;
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password !!!");
                }
            });
        }
    }
}
