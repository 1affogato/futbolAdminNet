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
using FutbolAdmin.ViewModel.Visitantes;

namespace FutbolAdmin.View.Visitantes {
    /// <summary>
    /// Interaction logic for ConsultarResultadosWindow.xaml
    /// </summary>
    public partial class ConsultarResultadosWindow : Window {
        public ConsultarResultadosWindow() {
            DataContext = new ConsultarResultadosViewModel();
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e) {
            NavigationHelper.ShowWindowAndHideParent(new MainWindow(), this);
        }
    }
}
