using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutbolAdmin.Model;
using FutbolAdmin.Repositories;

namespace FutbolAdmin.ViewModel.Crud.Jugador {

    public class ModificarJugadorViewModel : ViewModelBase {
        protected RepositoryJugador _repositorioJugador;

        public ModificarJugadorViewModel() {
            _repositorioJugador = new RepositoryJugador();
        }

        public string _playerSearchName;
        public string PlayerSearchName {
            get => _playerSearchName;
            set {
                _playerSearchName = value;
                OnPropertyChanged(nameof(PlayerSearchName));
            }
        }

        public ObservableCollection<JugadorModel> Jugadores {
            get => new ObservableCollection<JugadorModel>(_repositorioJugador.GetAll());
        }

        public ObservableCollection<JugadorModel> SearchJugadores() {
            var jugadores = _repositorioJugador.GetAll();
            var filteredJugadores = jugadores.Where(j => j.Nombre.ToLower().Contains(PlayerSearchName.ToLower()));
            return new ObservableCollection<JugadorModel>(_repositorioJugador.GetAll());
        }
    }
}
