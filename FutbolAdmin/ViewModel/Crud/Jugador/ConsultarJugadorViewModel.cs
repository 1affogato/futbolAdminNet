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

        public ICommand SearchCommand { get; }

        public ConsultarJugadorViewModel() {
            _repositorioJugador = new RepositoryJugador();
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
        
        protected ObservableCollection<JugadorModel> _jugadores;
        public ObservableCollection<JugadorModel> Jugadores {
            get => _jugadores;
            set {
                _jugadores = value;
                OnPropertyChanged(nameof(Jugadores));
            }
        }

        public void SearchJugadores() {
            var filteredJugadores = _repositorioJugador.GetAll().Where(j => j.Nombre.ToLower().Contains(PlayerSearchName.ToLower()));
            Jugadores = new ObservableCollection<JugadorModel>(filteredJugadores);
        }
    }
}
