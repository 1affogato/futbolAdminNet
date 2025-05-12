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
using FutbolAdmin.Repositories;
using FutbolAdmin.View;

namespace FutbolAdmin {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        //RepositoryEquipo _repositoryEquipo;
        public MainWindow() {
            //_repositoryEquipo = new RepositoryEquipo();
            
            
            // Nomás pa testear
            //new View.Visitantes.ConsultarEquiposWindow(_repositoryEquipo.GetById(1)).Show();
            new View.Visitantes.MainWindow().Show();

            Close();
        }
    }
}
