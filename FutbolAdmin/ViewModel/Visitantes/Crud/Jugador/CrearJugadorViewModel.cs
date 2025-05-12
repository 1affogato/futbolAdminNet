using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FutbolAdmin.Model;
using FutbolAdmin.Repositories;

namespace FutbolAdmin.ViewModel.Crud.Jugador {
    public class CrearJugadorViewModel : ViewModelBase {
        protected RepositoryJugador _jugadorRepository;
        protected RepositoryEquipo _equipoRepository;

        public ICommand CrearJugadorCommand;

        public CrearJugadorViewModel() {
            _jugadorRepository = new RepositoryJugador();
            _equipoRepository = new RepositoryEquipo();
            CrearJugadorCommand = new ComandoViewModel(execute => CrearJugador());
        }

        private string _errorMessage;
        public string ErrorMessage {
            get { return _errorMessage; }
            set {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
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

        private int _equipoJugador;
        public int EquipoJugador {
            get { return _equipoJugador; }
            set {
                _equipoJugador = value;
                OnPropertyChanged(nameof(EquipoJugador));
            }
        }

        public void CrearJugador() {
            if (string.IsNullOrEmpty(NombreJugador) || EdadJugador <= 0 || EquipoJugador <= 0) {
                ErrorMessage = "Por favor, complete todos los campos correctamente.";
                return;
            }
            var nuevoJugador = new JugadorModel {
                Nombre = NombreJugador,
                Edad = EdadJugador,
                Equipo = _equipoRepository.GetById(EquipoJugador),
            };
            _jugadorRepository.Add(nuevoJugador);
            MessageBox.Show("Jugador creado exitosamente.");
        }
    }
}
