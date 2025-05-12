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
        public int DifrerenciaGoles { get => GetDiferenciaDeGol(); }
        public int Puntos { get => GetPuntos(); }
        public int Posicion { get; set; }

        public List<JugadorModel> Jugadores { get; }

        public EquipoModel() {
            Id_Equipo = 0;
            Nombre = string.Empty;
            Victorias = 0;
            Derrotas = 0;
            Empates = 0;
            GolesFavor = 0;
            GolesContra = 0;
            Posicion = 0;
        }

        public EquipoModel(int id_Equipo, string nombre, int victorias, int derrotas, int empates, int golesFavor, int golesContra) {
            Id_Equipo = id_Equipo;
            Nombre = nombre;
            Victorias = victorias;
            Derrotas = derrotas;
            Empates = empates;
            GolesFavor = golesFavor;
            GolesContra = golesContra;
            Posicion = 0;
        }

        public int GetDiferenciaDeGol() {
            return GolesFavor - GolesContra;
        }

        public int GetPuntos() {
            return (Victorias * 3) + Empates;
        }
    }
}
