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
        public DateTime Fecha { get; set; }
        public EquipoModel EquipoLocal { get; set; }
        public EquipoModel EquipoVisitante { get; set; }
        public int Jornada {  get; set; }
        public int Cmpletado { get; set; }
        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }
    }
}
