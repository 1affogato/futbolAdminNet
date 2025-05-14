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
using FutbolAdmin.Model;
using FutbolAdmin.ViewModel.Crud.Equipo;

namespace FutbolAdmin.View.Crud.Equipo {
    /// <summary>
    /// Interaction logic for EliminarEquipoWindow.xaml
    /// </summary>
    public partial class EliminarEquipoWindow : Window {

        protected EliminarEquipoViewModel _viewModel;

        public EliminarEquipoWindow() {
            _viewModel = new EliminarEquipoViewModel();
            DataContext = _viewModel;

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.CloseWindow(this);
        }

        private void EquposDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (EquiposDataGrid.SelectedItem is EquipoModel equipo) {
                _viewModel.EliminarEquipo(equipo);
            }
        }
    }
}
