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
using FutbolAdmin.ViewModel.Crud.Equipo;

namespace FutbolAdmin.View.Crud.Equipo
{
    /// <summary>
    /// Lógica de interacción para ModificarEquipoWindow.xaml
    /// </summary>
    public partial class ModificarEquipoWindow : Window
    {
        public ModificarEquipoWindow()
        {
            DataContext = new ModificarEquipoViewModel();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.CloseWindow(this);
        }

        private void EquiposDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e) {
            NavigationHelper.CloseWindow(this);
        }
    }
}
