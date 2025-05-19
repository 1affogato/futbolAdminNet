using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FutbolAdmin.Model;
using FutbolAdmin.Repositories;

namespace FutbolAdmin.ViewModel.VaciarPartidos {

    internal class VaciarPartidoViewModel : ViewModelBase {

        protected RepositoryPartido _repositoryPartido;
        protected RepositoryEquipo _repositoryEquipo;

        private ObservableCollection<PartidoModel> _partidos;
        private ObservableCollection<EquipoModel> _equipos;

        public VaciarPartidoViewModel() {
            _repositoryEquipo = new RepositoryEquipo();
            _repositoryPartido = new RepositoryPartido();
            _partidos = GetPartidos();
            _equipos = GetEquipos();
            SetFechasPartidos();
            SetEquiposNames();
            GuardarPartidoCommand = new ComandoViewModel(execute => GuardarPartido());
        }

        // Comandos

        public ICommand GuardarPartidoCommand { get; set; }
        public void GuardarPartido() {
            PartidoModel partidoNuevo = _partidos.Where(p => p.FechaString == FechaPartido).FirstOrDefault();
            Console.WriteLine("Partido: " + partidoNuevo.FechaString);
            partidoNuevo.Jornada = NumJornada;
            partidoNuevo.EquipoLocal = _equipos.Where(e => e.Nombre == EquipoLocal).FirstOrDefault();
            partidoNuevo.EquipoVisitante = _equipos.Where(e => e.Nombre == EquipoVisitante).FirstOrDefault();
            partidoNuevo.GolesLocal = GolesLocal;
            partidoNuevo.GolesVisitante = GolesVisitante;
            _repositoryPartido.Update(partidoNuevo);
        }

        // Bindings para ComboBox

        private ObservableCollection<string> _fechasPartidos;
        public ObservableCollection<string> FechasPartidos {
            get => _fechasPartidos;
            set {
                _fechasPartidos = value;
                OnPropertyChanged(nameof(FechasPartidos));
            }
        }

        private ObservableCollection<string> _equiposNames;
        public ObservableCollection<string> EquiposNames {
            get => _equiposNames;
            set {
                _equiposNames = value;
                OnPropertyChanged(nameof(EquiposNames));
            }
        }

        // Bindings para variables

        private string _fechaPartido;
        public string FechaPartido {
            get => _fechaPartido;
            set {
                _fechaPartido = value;
                OnPropertyChanged(nameof(FechaPartido));
            }
        }

        private int _numJornada;
        public int NumJornada {
            get => _numJornada;
            set {
                _numJornada = value;
                OnPropertyChanged(nameof(NumJornada));
            }
        }

        private string _equipoLocal;
        public string EquipoLocal {
            get => _equipoLocal;
            set {
                _equipoLocal = value;
                OnPropertyChanged(nameof(EquipoLocal));
            }
        }

        private string _equipoVisitante;
        public string EquipoVisitante {
            get => _equipoVisitante;
            set {
                _equipoVisitante = value;
                OnPropertyChanged(nameof(EquipoVisitante));
            }
        }

        private int _golesLocal;
        public int GolesLocal {
            get => _golesLocal;
            set {
                _golesLocal = value;
                OnPropertyChanged(nameof(GolesLocal));
            }
        }

        private int _golesVisitante;
        public int GolesVisitante {
            get => _golesVisitante;
            set {
                _golesVisitante = value;
                OnPropertyChanged(nameof(GolesVisitante));
            }
        }


        public ObservableCollection<PartidoModel> GetPartidos() {
            var partidos = _repositoryPartido.GetAll();
            return new ObservableCollection<PartidoModel>(partidos);
        }

        public void SetFechasPartidos() {
            FechasPartidos = new ObservableCollection<string>();
            foreach (var partido in _partidos) {
                if (partido.Fecha != null) {
                    FechasPartidos.Add(partido.FechaString);
                }
            }
        }

        public ObservableCollection<EquipoModel> GetEquipos() {
            var equipos = _repositoryEquipo.GetAll();
            return new ObservableCollection<EquipoModel>(equipos);
        }

        public void SetEquiposNames() {
            EquiposNames = new ObservableCollection<string>();
            foreach (var equipo in _equipos) {
                EquiposNames.Add(equipo.Nombre);
            }
        }
    }
}
