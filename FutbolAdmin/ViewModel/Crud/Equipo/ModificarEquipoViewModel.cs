using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FutbolAdmin.Model;
using FutbolAdmin.Repositories;

namespace FutbolAdmin.ViewModel.Crud.Equipo {
    public class ModificarEquipoViewModel : ViewModelBase {
        protected RepositoryEquipo _repositorioEquipo;

        public ICommand SearchCommand { get; }
        public ICommand SearchTeamCommand { get; }

        protected ObservableCollection<EquipoModel> _equipos;
        public ObservableCollection<EquipoModel> Equipos {
            get => _equipos;
            set {
                _equipos = value;
                OnPropertyChanged(nameof(Equipos));
            }
        }

        public string _equipoSearchName;
        public string EquipoSearchName {
            get => _equipoSearchName;
            set {
                _equipoSearchName = value;
                OnPropertyChanged(nameof(EquipoSearchName));
            }
        }

        public ModificarEquipoViewModel() {
            _repositorioEquipo = new RepositoryEquipo();
            SearchCommand = new ComandoViewModel(execute => SearchEquipos());
            SearchTeamCommand = new ComandoViewModel(execute => SearchEquiposPorNombre());
            Equipos = new ObservableCollection<EquipoModel>(_repositorioEquipo.GetAll());
            _equipoSearchName = "";
        }

        public void SearchEquiposPorNombre() {
            var filteredEquipos = _repositorioEquipo.GetAll().Where(e => e.Nombre.ToLower().Contains(EquipoSearchName.ToLower()));
            Equipos = new ObservableCollection<EquipoModel>(filteredEquipos);
            EquipoSearchName = string.Empty;
        }

        public void SearchEquipos() {
            var filteredEquipos = _repositorioEquipo.GetAll().Where(e => e.Nombre.ToLower().Contains(EquipoSearchName.ToLower()));
            Equipos = new ObservableCollection<EquipoModel>(filteredEquipos);
            EquipoSearchName = string.Empty;
        }
    }
}
