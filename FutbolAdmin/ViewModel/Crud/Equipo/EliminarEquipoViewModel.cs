using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutbolAdmin.Model;
using FutbolAdmin.Repositories;
using System.Windows.Input;

namespace FutbolAdmin.ViewModel.Crud.Equipo {
    public class EliminarEquipoViewModel : ViewModelBase {

        protected RepositoryEquipo _repositorioEquipo;

        public ICommand SearchCommand { get; }

        public EliminarEquipoViewModel() {
            _repositorioEquipo = new RepositoryEquipo();
            SearchCommand = new ComandoViewModel(execute => SearchEquipos());
            Equipos = GetEquipos();
        }

        public string _equipoSearchName;
        public string EquipoSearchName {
            get => _equipoSearchName;
            set {
                _equipoSearchName = value;
                OnPropertyChanged(nameof(EquipoSearchName));
            }
        }

        protected ObservableCollection<EquipoModel> _equipos;
        public ObservableCollection<EquipoModel> Equipos {
            get => _equipos;
            set {
                _equipos = value;
                OnPropertyChanged(nameof(Equipos));
            }
        }

        public void SearchEquipos() {
            var filteredEquipos = _repositorioEquipo.GetAll().Where(j => j.Nombre.ToLower().Contains(EquipoSearchName.ToLower()));
            Equipos = new ObservableCollection<EquipoModel>(filteredEquipos);
            EquipoSearchName = string.Empty;
        }

        protected ObservableCollection<EquipoModel> GetEquipos() {
            return new ObservableCollection<EquipoModel>(_repositorioEquipo.GetAll());
        }

        public void EliminarEquipo(EquipoModel equipo) {
            int id = equipo.Id_Equipo;

            _repositorioEquipo.Delete(id);

            // Refrescar el DataGrid
            Equipos = new ObservableCollection<EquipoModel>(_repositorioEquipo.GetAll());
        }
    }
}
