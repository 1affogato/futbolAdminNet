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
    /// Interaction logic for ConsultarJugadorWindow.xaml
    /// </summary>
    public partial class ConsultarJugadorWindow : Window {
        ConsultarJugadorViewModel _viewModel = new ConsultarJugadorViewModel();

        public ConsultarJugadorWindow() {
            InitializeComponent();

            _viewModel = new ConsultarJugadorViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.CloseWindow(this);
        }
    }
}
