using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutbolAdmin.Model;
using FutbolAdmin.Repositories;

namespace FutbolAdmin.ViewModel.Crud.Jugador {
    public class EliminarJugadorViewModel : ViewModelBase {

        protected RepositoryJugador _repository;

        public EliminarJugadorViewModel() {
            _repository = new RepositoryJugador();
            Jugadores = GetJugadores();
        }

        protected ObservableCollection<JugadorModel> _jugadores;
        public ObservableCollection<JugadorModel> Jugadores {
            get => _jugadores;
            set {
                _jugadores = value;
                OnPropertyChanged(nameof(Jugadores));
            }
        }

        protected ObservableCollection<JugadorModel> GetJugadores() {
            return new ObservableCollection<JugadorModel>(_repository.GetAll());
        }

        public void EliminarJugador(JugadorModel jugador) {
            int idJugador = jugador.Id_Jugador;

            var repository = new RepositoryJugador();
            repository.Delete(idJugador);

            // Refrescar el DataGrid
            Jugadores = new ObservableCollection<JugadorModel>(_repository.GetAll());
        }
    }
}
