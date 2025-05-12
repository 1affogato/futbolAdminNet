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
            // Descomentar cuando exista el repositorio
            // Teams =  _repositoryEquipo.GetAll();
            // Regresando equipos de prueba
            Equipos = new ObservableCollection<EquipoModel> {
                new EquipoModel(1, "Madri", 12, 8, 10, 80, 33),
                new EquipoModel(2, "Barça", 10, 10, 10, 67, 33),
            };

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
