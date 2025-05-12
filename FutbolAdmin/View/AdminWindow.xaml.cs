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
using FutbolAdmin.View.Calendarizacion;
using FutbolAdmin.View.Crud;
using FutbolAdmin.View.VaciarPartidos;
using FutbolAdmin.View.Visitantes;

namespace FutbolAdmin.View {
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window {
        public AdminWindow() {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.CloseWindow(this);
        }

        private void CalendarizacionButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.ShowWindowAndHideParent(new CalendarizacionAgregar(), this);
        }

        private void GestionarCatalogosButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.ShowWindowAndHideParent(new CatalogosCrudWindow(), this);
        }

        private void VaciarPartidoButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.ShowWindowAndHideParent(new VaciarPartidoWindow(), this);
        }
    }
}
