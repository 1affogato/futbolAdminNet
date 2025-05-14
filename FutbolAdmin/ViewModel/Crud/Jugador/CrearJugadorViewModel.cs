using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FutbolAdmin.Model;
using FutbolAdmin.Repositories;

namespace FutbolAdmin.ViewModel.Crud.Jugador {
    public class CrearJugadorViewModel : ViewModelBase {
        RepositoryJugador jugadorRepository;
        RepositoryEquipo equipoRepository;

        private string _nombre;
        private int _edad;
        private ObservableCollection<EquipoModel> _equipos;
        private string _equipoSelected;

        public ICommand CrearJugador { get; }

        public string Nombre {
            get => _nombre;
            set {
                _nombre = value;
                OnPropertyChanged(nameof(Nombre));
            }
        }

        public int Edad {
            get => _edad;
            set {
                _edad = value;
                OnPropertyChanged(nameof(Edad));
            }
        }

        public string EquipoSelected {
            get => _equipoSelected;
            set {
                _equipoSelected = value;
                OnPropertyChanged(nameof(EquipoSelected));
            }
        }


        public ObservableCollection<string> Equipos {
            get => GetEquipos();
        }
        public ObservableCollection<string> GetEquipos() {
            IEnumerable<EquipoModel> equipos = equipoRepository.GetAll();
            ObservableCollection<string> nombresEquipos = new ObservableCollection<string>();
            foreach (var equipo in equipos) {
                nombresEquipos.Add(equipo.Nombre);
            }
            return nombresEquipos;
        }
        public void ExecuteCrearJugador(Object objeto) {

            JugadorModel nuevoJugador = new JugadorModel {
                Nombre = Nombre,
                Edad = Edad,
                Equipo = equipoRepository.GetByName(EquipoSelected)
            };
            jugadorRepository.Add(nuevoJugador);
        }
        public CrearJugadorViewModel() {
            jugadorRepository = new RepositoryJugador();
            equipoRepository = new RepositoryEquipo();
            CrearJugador = new ComandoViewModel(ExecuteCrearJugador);
        }


    }
}
