using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutbolAdmin.Model;
using FutbolAdmin.Repositories;
using Remotion.Linq.Collections;

namespace FutbolAdmin.ViewModel.Visitantes {
    public class ConsultarResultadosViewModel : ViewModelBase {

        protected RepositoryPartido _repositoryPartidos;

        protected ObservableCollection<PartidoModel> _partidos;
        public ObservableCollection<PartidoModel> Partidos {
            get { return _partidos; }
            set {
                _partidos = value;
                OnPropertyChanged(nameof(Partidos));
            }
        }

        public ConsultarResultadosViewModel() {
            _repositoryPartidos = new RepositoryPartido();
            Partidos = new ObservableCollection<PartidoModel>(_repositoryPartidos.GetAll());
        }
    }
}
