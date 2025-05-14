using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FutbolAdmin.Model;
using FutbolAdmin.Repositories;

namespace FutbolAdmin.ViewModel.Crud.Equipo
{
    public class ConsultarEquipoViewModel : ViewModelBase
    {
        RepositoryEquipo equipoRepository;

        public ICommand SearchCommand { get; }

        public ConsultarEquipoViewModel()
        {
            equipoRepository = new RepositoryEquipo();
            Equipos = new ObservableCollection<EquipoModel>(equipoRepository.GetAll());
            SearchCommand = new ComandoViewModel(execute => SearchEquiposPorNombre());
        }

        private ObservableCollection<EquipoModel> _equipos;

        public ObservableCollection<EquipoModel> Equipos
        {
            get => _equipos;
            set
            {
                _equipos = value;
                OnPropertyChanged(nameof(Equipos));
            }
        }

        private string _equipoSearchName;

        public string EquipoSearchName
        {
            get => _equipoSearchName;
            set
            {
                _equipoSearchName = value;
                OnPropertyChanged(nameof(EquipoSearchName));
            }
        }


        public void SearchEquiposPorNombre()
        {
            var filteredEquipos = equipoRepository.GetAll().Where(j => j.Nombre.ToLower().Contains(EquipoSearchName.ToLower()));
            Equipos = new ObservableCollection<EquipoModel>(filteredEquipos);
        }

    }
}
