using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutbolAdmin.Repositories;

namespace FutbolAdmin.ViewModel.Crud.Jugador {
    public class CrearJugadorViewModel {
        RepositoryJugador jugadorRepository;

        public CrearJugadorViewModel() {
            jugadorRepository = new RepositoryJugador();
        }


    }
}
