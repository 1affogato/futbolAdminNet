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

namespace FutbolAdmin.View.Crud.Equipo {
    /// <summary>
    /// Interaction logic for CrudEquipoWIndow.xaml
    /// </summary>
    public partial class CrudEquipoWIndow : Window {
        public CrudEquipoWIndow() {
            InitializeComponent();
        }

        private void ModificarButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.ShowWindowAndHideParent(new ModificarEquipoWindow(), this);
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.ShowWindowAndHideParent(new ConsultarEquipoWindow(), this);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.ShowWindowAndHideParent(new EliminarEquipoWindow(), this);
        }

        private void CrearButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.ShowWindowAndHideParent(new CrearEquipoWindow(), this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.CloseWindow(this);
        }
    }
}
