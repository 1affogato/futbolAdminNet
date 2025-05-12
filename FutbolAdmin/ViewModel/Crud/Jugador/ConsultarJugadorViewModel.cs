using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutbolAdmin.Model;
using FutbolAdmin.Repositories;

namespace FutbolAdmin.ViewModel.Crud.Jugador {
    public class ConsultarJugadorViewModel {
        protected RepositoryJugador _repositorioJugador;

        public ConsultarJugadorViewModel() {
            _repositorioJugador = new RepositoryJugador();
        }

        public string _playerSearchName { get; set; }
        public string PlayerSearchName {
            get => _playerSearchName;
            set {
                _playerSearchName = value;
                // NotifyPropertyChanged("PlayerSearchName");
            }
        }

        public ObservableCollection<JugadorModel> Jugadores {
            get => SearchJugadores();
        }

        public ObservableCollection<JugadorModel> SearchJugadores() {
            var jugadores = _repositorioJugador.GetAll();
            var filteredJugadores = jugadores.Where(j => j.Nombre.ToLower().Contains(PlayerSearchName.ToLower()));
            return new ObservableCollection<JugadorModel>(filteredJugadores);
        }
    }
}
