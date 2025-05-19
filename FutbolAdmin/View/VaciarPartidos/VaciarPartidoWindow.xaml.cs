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
using FutbolAdmin.ViewModel.VaciarPartidos;

namespace FutbolAdmin.View.VaciarPartidos {
    /// <summary>
    /// Interaction logic for VaciarPartidoWindow.xaml
    /// </summary>
    public partial class VaciarPartidoWindow : Window {
        public VaciarPartidoWindow() {
            DataContext = new VaciarPartidoViewModel();
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.CloseWindow(this);
        }
    }
}
