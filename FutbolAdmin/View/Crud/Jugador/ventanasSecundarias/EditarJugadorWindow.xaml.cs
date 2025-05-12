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

namespace FutbolAdmin.View.Crud.Jugador.ventanasSecundarias
{
    /// <summary>
    /// Lógica de interacción para EditarJugadorWindow.xaml
    /// </summary>
    public partial class EditarJugadorWindow : Window
    {
        private int idJugador;

        public EditarJugadorWindow(int idJugador)
        {
            InitializeComponent();
            this.idJugador = idJugador;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.CloseWindow(this);
        }
    }
}
