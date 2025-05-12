using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutbolAdmin.Model;
using FutbolAdmin.Repositories;

namespace FutbolAdmin.ViewModel.Visitantes {

    public class ConsultarEquiposViewModel : ViewModelBase {
        protected RepositoryEquipo _repositoryEquipo;

        protected EquipoModel _equipo;

        public ConsultarEquiposViewModel(EquipoModel equipo) {
            _repositoryEquipo = new RepositoryEquipo();
            _equipo = equipo;
        }

        protected string _nombreEquipo;
        public string NombreEquipo {
            get => _nombreEquipo;
            set {
                _nombreEquipo = value;
                OnPropertyChanged(nameof(NombreEquipo));
            }
        }

        public string VictoriasText {
            get => $"V: {_equipo.Victorias}";
        }

        public string DerrotasText {
            get => $"D: {_equipo.Derrotas}";
        }

        public string EmpatesText {
            get => $"E: {_equipo.Empates}";
        }

        public string GolesFavorText {
            get => $"GF: {_equipo.GolesFavor}";
        }

        public string GolesContraText {
            get => $"GC: {_equipo.GolesContra}";
        }

        public string DiferenciaGolesText {
            get => $"DG: {_equipo.DiferenciaGoles}";
        }

        public string PuntosText {
            get => $"P: {_equipo.Puntos}";
        }

        public string PosicionText {
            get => $"Pos: {_equipo.Posicion}";
        }

        public ObservableCollection<JugadorModel> Jugadores {
            get => GetJugadores();
        }

        public ObservableCollection<JugadorModel> GetJugadores() {
            IEnumerable<JugadorModel> jugadores = _repositoryEquipo.GetJugadoresByEquipoId(_equipo.Id_Equipo);
            return new ObservableCollection<JugadorModel>(jugadores);
        }
    }
}
