using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutbolAdmin.Model;
using FutbolAdmin.Repositories;

namespace FutbolAdmin.ViewModel.Crud.Jugador.VentanasSecundarias {
    public class EditarJugadorViewModel : ViewModelBase {

        protected RepositoryJugador _jugadorRepository;
        protected RepositoryEquipo _equipoRepository;

        private JugadorModel _jugadorSeleccionado;
        public JugadorModel JugadorSeleccionado {
            get { return _jugadorSeleccionado; }
            set {
                _jugadorSeleccionado = value;
                OnPropertyChanged(nameof(Jugador));
            }
        }

        public EditarJugadorViewModel(JugadorModel jugador) {
            JugadorSeleccionado = jugador;
            _jugadorRepository = new RepositoryJugador();
            _equipoRepository = new RepositoryEquipo();
        }

        private string _nombreJugador;
        public string NombreJugador {
            get { return _nombreJugador; }
            set {
                _nombreJugador = value;
                OnPropertyChanged(nameof(NombreJugador));
            }
        }
    }
}
