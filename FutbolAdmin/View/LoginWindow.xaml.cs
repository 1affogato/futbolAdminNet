using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using FutbolAdmin.View.Visitantes;
using FutbolAdmin.ViewModel;

namespace FutbolAdmin.View {
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        protected readonly LoginViewModel _viewModel;

        public LoginWindow()
        {
            InitializeComponent();

            _viewModel = new LoginViewModel();
            _viewModel.IsViewVisible = true;
            DataContext = _viewModel;

            _viewModel.PropertyChanged += IsViewVisibleChanged;
        }

        private void IsViewVisibleChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.IsViewVisible) && !_viewModel.IsViewVisible) {
                
                // Se cierra la ventana de login y se procede a la de admin
                // new AdminWindow().Show();

                // Close();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.CloseWindow(this);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            if (_viewModel.ExecuteLogin()) {
                NavigationHelper.ShowWindowAndHideParent(new AdminWindow(), this);
            }
        }
    }
}
