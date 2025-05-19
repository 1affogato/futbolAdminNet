using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FutbolAdmin.Model;
using FutbolAdmin.Repositories;

namespace FutbolAdmin.ViewModel.Calendarizacion
{
    public class CalendarizacionAgregarViewModel : ViewModelBase
    {
        private RepositoryPartido _partidoRepository;
        private RepositoryEquipo _equipoRepository;


        private ObservableCollection<PartidoModel> _partidos;
        private List<EquipoModel> _equipos;

        public ICommand GenerarCalendarizacion { get; }

        public CalendarizacionAgregarViewModel()
        {
            _partidoRepository = new RepositoryPartido();
            _equipoRepository = new RepositoryEquipo();
            Equipos = new List<EquipoModel>(_equipoRepository.GetAll());
            Partidos = new ObservableCollection<PartidoModel>(_partidoRepository.GetAll());
            GenerarCalendarizacion = new ComandoViewModel(execute => GenerarPartidos());
        }

        public ObservableCollection<PartidoModel> Partidos
        {
            get => _partidos;
            set
            {
                _partidos = value;
                OnPropertyChanged(nameof(Partidos));
            }
        }

        public List<EquipoModel> Equipos
        {
            get => _equipos;
            set
            {
                _equipos = value;
                OnPropertyChanged(nameof(Equipos));
            }
        }



        //atributos para generador de partidos
        private readonly int MAX_MATCHES_PER_DAY = 3;
        private readonly string REST_TEAM = "REST";
        private readonly int INITIAL_HOUR = 19;
        private readonly int INITIAL_MINUTE = 0;
        private int numMatches = 0;
        private int numRounds = 0;
        private int numMatchesPerRound = 0;
        private int numTeams = 0;
        public void GenerarPartidos()
        {
            var partidos = new List<PartidoModel>();
            List<EquipoModel> equipos = _equipos.ToList();
            this.numTeams = equipos.Count;
            bool odd = numMatches % 2 == 1;
            if (odd)
            {
                equipos.Add(new EquipoModel(0,REST_TEAM,0,0,0,0,0));
                numTeams++;
            }
            numMatches = numTeams * (numTeams - 1) / 2;
            numRounds = numTeams - 1;
            numMatchesPerRound = numMatches / numRounds;
            if (odd)
            {
                numMatchesPerRound--;
            }

            List<DateTime> fechas = GenerarFechas();


            List<EquipoModel> equiposRotativos = new List<EquipoModel>(equipos);

            EquipoModel equipoFijo = equiposRotativos[0];
            equiposRotativos.RemoveAt(0);
            int iteradorFechas = 0;
            int countPartidos = 0;

            PartidoModel partido;
            EquipoModel equipoLocal;
            EquipoModel equipoVisitante;
            for (int i = 0; i < numRounds; i++)
            {
                equipoLocal = equipoFijo;
                equipoVisitante = equiposRotativos[equiposRotativos.Count - 1];
                //partido entre el equipo fijo y el ultimo equipo rotativo
                if ((equipoLocal.Nombre == REST_TEAM || equipoVisitante.Nombre == REST_TEAM) == false)
                {
                    partido = new PartidoModel(countPartidos, fechas[iteradorFechas], equipoLocal, equipoVisitante, i+1);
                    partidos.Add(partido);
                    countPartidos++;
                    iteradorFechas++;
                }
                //Partidos de los equipos rotativos
                for (int j = 0; j < equiposRotativos.Count; j++)
                {
                    equipoLocal = equiposRotativos[j];
                    equipoVisitante = equiposRotativos[equiposRotativos.Count - 2 - j];
                    if ((equipoLocal.Nombre == REST_TEAM || equipoVisitante.Nombre == REST_TEAM) == false)
                    {
                        partido = new PartidoModel(countPartidos, fechas[iteradorFechas], equipoLocal, equipoVisitante, i + 1);
                        partidos.Add(partido);
                        countPartidos++;
                        iteradorFechas++;
                    }
                }
                //rotar equipos
                var equipoTemp = equiposRotativos[equiposRotativos.Count - 1];
                equiposRotativos.RemoveAt(equiposRotativos.Count - 1);
                equiposRotativos.Insert(0, equipoTemp);


            }

            Partidos = new ObservableCollection<PartidoModel>(partidos);
        }
        
        private List<DateTime> GenerarFechas()
        {
            
            List<DateTime> fechas = new List<DateTime>();
            DateTime fechaActual = DateTime.Now;
            DateTime fechaSiguienteViernes = fechaActual.AddDays((int)DayOfWeek.Friday - (int)fechaActual.DayOfWeek + 7);
            DateTime fechaPrimerPartido = new DateTime(fechaSiguienteViernes.Year, fechaSiguienteViernes.Month, fechaSiguienteViernes.Day, INITIAL_HOUR, INITIAL_MINUTE, 0);
            int daySum = -1;
            DateTime fechaPrimerPartidoJornada = fechaPrimerPartido;
            DateTime fecha;
            for (int i = 0; i < numRounds; i++)
            {
                fechaPrimerPartidoJornada = fechaPrimerPartidoJornada.AddDays(7 * i);
                for (int j = 0; j < numMatchesPerRound; j++)
                {
                    if (i%MAX_MATCHES_PER_DAY == 0)
                    {
                        daySum++;
                    }
                    fecha = fechaPrimerPartidoJornada.AddDays(daySum);
                    fecha = fecha.AddMinutes(40 * i);
                    fechas.Add(fecha);
                }
            }
            return fechas;



        }
    }
}
