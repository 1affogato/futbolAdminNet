using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutbolAdmin.Model;
using FutbolAdmin.Repositories;

namespace FutbolAdmin.ViewModel.Visitantes {
    public class MainWindowViewModel : ViewModelBase {
        protected RepositoryEquipo _repositoryEquipo;

        protected ObservableCollection<EquipoModel> _equipos;
        public ObservableCollection<EquipoModel> Equipos {
            get => _equipos;
            set {
                _equipos = value;
                OnPropertyChanged(nameof(Equipos));
            }
        }

        public MainWindowViewModel() {
            _repositoryEquipo = new RepositoryEquipo();
            Equipos =  new ObservableCollection<EquipoModel>(_repositoryEquipo.GetAll().OrderByDescending(e => e.Puntos));

            AsignarPosiciones();
        }

        protected void AsignarPosiciones() {
            int posicion = 1;
            foreach (var equipo in Equipos.OrderByDescending(e => e.Puntos)) {
                equipo.Posicion = posicion++;
            }
        }
    }
}
