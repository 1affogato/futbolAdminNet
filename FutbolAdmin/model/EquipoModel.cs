using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutbolAdmin.Model
{
    public class EquipoModel
    {
        public int Id_Equipo { get; set; }
        public string Nombre { get; set; }
        public int Victorias { get; set; }
        public int Derrotas { get; set; }
        public int Empates { get; set; }
        public int GolesFavor {  get; set; }
        public int GolesContra { get; set; }
    }
}
