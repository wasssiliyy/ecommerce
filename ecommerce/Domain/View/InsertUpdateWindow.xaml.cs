using ecommerce.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ecommerce.Domain.View
{
    /// <summary>
    /// Interaction logic for InsertUpdateWindow.xaml
    /// </summary>
    public partial class InsertUpdateWindow : Window
    {
        public InsertUpdateWindow()
        {
            InitializeComponent();
            InsertUpdateWindowViewModel insertUpdateWindow = new InsertUpdateWindowViewModel();
            this.DataContext = insertUpdateWindow;
        }
    }
}
