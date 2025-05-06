using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutbolAdmin.Model
{
    public class JugadorModel
    {
        public int Id_Jugador { get; set; }
        public string Nombre { get; set; }
        public int Edad {  get; set; }
        public int PartidosJugados { get; set; }
        public int Goles {  get; set; }
        public int Asistencias { get; set; }
        public int TarjetasRojas { get; set; }
        public int TarjetasAmarillas { get; set; }
        public EquipoModel Equipo { get; set; }
    }
}
