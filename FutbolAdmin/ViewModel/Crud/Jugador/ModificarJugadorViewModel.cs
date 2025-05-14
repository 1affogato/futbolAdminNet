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

    public class ModificarJugadorViewModel : ViewModelBase {
        protected RepositoryJugador _repositorioJugador;

        public ICommand SearchCommand { get; }

        public ICommand SearchTeamCommand { get; }

        public ModificarJugadorViewModel() {
            _repositorioJugador = new RepositoryJugador();
            SearchTeamCommand = new ComandoViewModel(execute => SearchJugadoresPorEquipo());
            SearchCommand = new ComandoViewModel(execute => SearchJugadores());
            Jugadores = new ObservableCollection<JugadorModel>(_repositorioJugador.GetAll());
        }

        public string _playerSearchName;
        public string PlayerSearchName {
            get => _playerSearchName;
            set {
                _playerSearchName = value;
                OnPropertyChanged(nameof(PlayerSearchName));
            }
        }


        private string _equipoSearchName;

        public string EquipoSearchName
        {
            get => _equipoSearchName;
            set
            {
                _equipoSearchName = value;
                OnPropertyChanged(nameof(EquipoSearchName));
            }
        }


        protected ObservableCollection<JugadorModel> _jugadores;
        public ObservableCollection<JugadorModel> Jugadores {
            get => _jugadores;
            set {
                _jugadores = value;
                OnPropertyChanged(nameof(Jugadores));
            }
        }


        public void SearchJugadoresPorEquipo()
        {
            var filteredJugadores = _repositorioJugador.GetAll().Where(j => j.Equipo.Nombre.ToLower().Contains(EquipoSearchName.ToLower()));
            Jugadores = new ObservableCollection<JugadorModel>(filteredJugadores);
            PlayerSearchName = string.Empty;
        }

        public void SearchJugadores() {
            var jugadores = _repositorioJugador.GetAll();
            var filteredJugadores = jugadores.Where(j => j.Nombre.ToLower().Contains(PlayerSearchName.ToLower()));
            Jugadores = new ObservableCollection<JugadorModel>(filteredJugadores);
            EquipoSearchName = string.Empty;
        }
    }
}
