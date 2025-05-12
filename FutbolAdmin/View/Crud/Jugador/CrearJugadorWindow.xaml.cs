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
using FutbolAdmin.ViewModel.Crud.Jugador;

namespace FutbolAdmin.View.Crud.Jugador {
    /// <summary>
    /// Interaction logic for CrearJugadorWindow.xaml
    /// </summary>
    public partial class CrearJugadorWindow : Window {

        protected CrearJugadorViewModel _viewModel;

        public CrearJugadorWindow() {
            InitializeComponent();

            _viewModel = new CrearJugadorViewModel();
            DataContext = _viewModel;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.CloseWindow(this);
        }

        private void BackButton_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
