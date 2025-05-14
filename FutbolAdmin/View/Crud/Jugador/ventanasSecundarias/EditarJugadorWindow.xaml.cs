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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FutbolAdmin.Model;
using FutbolAdmin.ViewModel.Crud.Jugador;
using FutbolAdmin.ViewModel.Crud.Jugador.VentanasSecundarias;

namespace FutbolAdmin.View.Crud.Jugador.ventanasSecundarias {
    /// <summary>
    /// Lógica de interacción para EditarJugadorWindow.xaml
    /// </summary>
    public partial class EditarJugadorWindow : Window {
        protected EditarJugadorViewModel _viewModel;

        public EditarJugadorWindow(JugadorModel jugador) {
            _viewModel = new EditarJugadorViewModel(jugador);
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            this.Owner.DataContext = new ModificarJugadorViewModel();
            NavigationHelper.CloseWindow(this);
        }
    }
}
