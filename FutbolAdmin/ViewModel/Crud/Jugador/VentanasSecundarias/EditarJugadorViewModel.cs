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

        private string _equipoSeleccionado;

        public string EquipoSeleccionado {
            get { return _equipoSeleccionado; }
            set {
                _equipoSeleccionado = value;
                OnPropertyChanged(nameof(EquipoSeleccionado));
            }
        }
        public JugadorModel JugadorSeleccionado {
            get { return _jugadorSeleccionado; }
            set {
                _jugadorSeleccionado = value;
                OnPropertyChanged(nameof(Jugador));
            }
        }

        public ICommand ModificarJugadorCommand { get; }

        public EditarJugadorViewModel(JugadorModel jugador) {
            JugadorSeleccionado = jugador;
            _jugadorRepository = new RepositoryJugador();
            _equipoRepository = new RepositoryEquipo();
            ModificarJugadorCommand = new ComandoViewModel(ExecuteModificarJugador);
            NombreJugador = JugadorSeleccionado.Nombre;
            EdadJugador = JugadorSeleccionado.Edad;
            PartidosJugados = JugadorSeleccionado.PartidosJugados;
            Goles = JugadorSeleccionado.Goles;
            Asistencias = JugadorSeleccionado.Asistencias;
            TarjetasAmarillas = JugadorSeleccionado.TarjetasAmarillas;
            TarjetasRojas = JugadorSeleccionado.TarjetasRojas;
            EquipoSeleccionado = JugadorSeleccionado.Equipo.Nombre;
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


        //Bindings de jugador
        private int _partidosJugados;
        private int _goles;
        private int _asistencias;
        private int _tarjetasAmarillas;
        private int _tarjetasRojas;

        public int PartidosJugados
        {
            get { return _partidosJugados; }
            set
            {
                _partidosJugados = value;
                OnPropertyChanged(nameof(PartidosJugados));
            }
        }

        public int Goles
        {
            get { return _goles; }
            set
            {
                _goles = value;
                OnPropertyChanged(nameof(Goles));
            }
        }

        public int Asistencias
        {
            get { return _asistencias; }
            set
            {
                _asistencias = value;
                OnPropertyChanged(nameof(Asistencias));
            }
        }

        public int TarjetasAmarillas
        {
            get { return _tarjetasAmarillas; }
            set
            {
                _tarjetasAmarillas = value;
                OnPropertyChanged(nameof(TarjetasAmarillas));
            }
        }

        public int TarjetasRojas
        {
            get { return _tarjetasRojas; }
            set
            {
                _tarjetasRojas = value;
                OnPropertyChanged(nameof(TarjetasRojas));
            }
        }


        public ObservableCollection<string> Equipos {
            get => GetEquipos();
        }

        public ObservableCollection<string> GetEquipos() {
            IEnumerable<EquipoModel> equipos = _equipoRepository.GetAll();
            ObservableCollection<string> nombresEquipos = new ObservableCollection<string>();
            foreach (var equipo in equipos) {
                nombresEquipos.Add(equipo.Nombre);
            }
            return nombresEquipos;
        }

        public void ExecuteModificarJugador(Object objecto) {
            JugadorModel jugador = new JugadorModel();
            jugador.Id_Jugador = JugadorSeleccionado.Id_Jugador;
            jugador.Nombre = NombreJugador;
            jugador.Edad = EdadJugador;
            jugador.PartidosJugados = PartidosJugados;
            jugador.Goles = Goles;
            jugador.Asistencias = Asistencias;
            jugador.TarjetasRojas = TarjetasRojas;
            jugador.TarjetasAmarillas = TarjetasAmarillas;
            jugador.Equipo = _equipoRepository.GetByName(EquipoSeleccionado);

            _jugadorRepository.Update(jugador);
        }
    }
}
