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
using FutbolAdmin.ViewModel.Visitantes;

namespace FutbolAdmin.View.Visitantes
{
    /// <summary>
    /// Interaction logic for ConsultarEquiposWindow.xaml
    /// </summary>
    public partial class ConsultarEquiposWindow : Window
    {
        private ConsultarEquiposViewModel _viewModel;

        public ConsultarEquiposWindow(EquipoModel equipo)
        {
            _viewModel = new ConsultarEquiposViewModel(equipo);
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.CloseWindow(this);
        }
    }
}