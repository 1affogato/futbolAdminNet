using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

        ICommand ModificarJugadorCommand;

        public EditarJugadorViewModel(JugadorModel jugador) {
            JugadorSeleccionado = jugador;
            _jugadorRepository = new RepositoryJugador();
            _equipoRepository = new RepositoryEquipo();
            ModificarJugadorCommand = new ComandoViewModel(execute => ModificarJugador());
        }

        private string _nombreJugador;
        public string NombreJugador {
            get { return _nombreJugador; }
            set {
                _nombreJugador = value;
                OnPropertyChanged(nameof(NombreJugador));
            }
        }

        private int _edadJugador;
        public int EdadJugador {
            get { return _edadJugador; }
            set {
                _edadJugador = value;
                OnPropertyChanged(nameof(EdadJugador));
            }
        }

        public ObservableCollection<EquipoModel> Equipos {
            get { return GetEquipos(); }
        }

        public ObservableCollection<EquipoModel> GetEquipos() {
            return new ObservableCollection<EquipoModel>(_equipoRepository.GetAll());
        }

        public void ModificarJugador() {

        }
    }
}
