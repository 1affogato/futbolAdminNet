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
using FutbolAdmin.View.Visitantes;
using FutbolAdmin.ViewModel.Crud.Equipo;

namespace FutbolAdmin.View.Crud.Equipo {
    /// <summary>
    /// Interaction logic for ConsultarEquipoWindow.xaml
    /// </summary>
    public partial class ConsultarEquipoWindow : Window {
        public ConsultarEquipoWindow() {
            DataContext = new ConsultarEquipoViewModel();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.CloseWindow(this);
        }

        private void EquiposDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EquiposDataGrid.SelectedItem is Model.EquipoModel equipoSeleccionado)
            {
                NavigationHelper.ShowWindowAndHideParent(new ConsultarEquiposWindow(equipoSeleccionado), this);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.CloseWindow(this);
        }
    }
}
