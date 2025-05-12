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
    public class ConsultarJugadorViewModel : ViewModelBase {
        protected RepositoryJugador _repositorioJugador;

        public ICommand SearchCommand;

        public ConsultarJugadorViewModel() {
            _repositorioJugador = new RepositoryJugador();
            SearchCommand = new ComandoViewModel(execute => SearchJugadores());
        }

        private string _playerSearchName;
        public string PlayerSearchName {
            get => _playerSearchName;
            set {
                _playerSearchName = value;
                OnPropertyChanged(nameof(PlayerSearchName));
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
