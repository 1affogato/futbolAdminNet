using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutbolAdmin.Model;
using FutbolAdmin.Repositories;

namespace FutbolAdmin.ViewModel.Crud.Jugador {
    public class CrearJugadorViewModel : ViewModelBase{
        RepositoryJugador jugadorRepository;
        RepositoryEquipo equipoRepository;

        private string _nombre;
        private int _edad;
        private ObservableCollection<EquipoModel> _equipos;

        public string Nombre
        {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged(nameof(Nombre));
            }
        }

        public int Edad
        {
            get => _edad;
            set
            {
                _edad = value;
                OnPropertyChanged(nameof(Edad));
            }
        }

        

        public ObservableCollection<EquipoModel> Equipos
        {
            get => GetEquipos();
        }
        public ObservableCollection<EquipoModel> GetEquipos() {
            IEnumerable<EquipoModel> equipos = equipoRepository.GetAll();
            return new ObservableCollection<EquipoModel>(equipos);
        }

        public CrearJugadorViewModel() {
            jugadorRepository = new RepositoryJugador();
            equipoRepository = new RepositoryEquipo();
        }


    }
}
