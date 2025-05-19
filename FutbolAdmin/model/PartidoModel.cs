using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutbolAdmin.Model
{
    public class PartidoModel
    {
        public int Id_Partido {  get; set; }
        public DateTime? Fecha { get; set; }
        public string FechaString {
            get => Fecha?.ToString("dd/MM/yyyy");
        }
        public EquipoModel EquipoLocal { get; set; }
        public EquipoModel EquipoVisitante { get; set; }
        public int? Jornada {  get; set; }
        public int Completado { get; set; }
        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }

        public PartidoModel()
        {

        }
        public PartidoModel(int id_Partido, DateTime? fecha, EquipoModel equipoLocal, EquipoModel equipoVisitante, int? jornada)
        {
            Id_Partido = id_Partido;
            Fecha = fecha;
            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
            Jornada = jornada;
            Completado = 0;
            GolesLocal = 0;
            GolesVisitante = 0;
        }
    }
}
