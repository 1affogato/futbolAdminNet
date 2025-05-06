using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutbolAdmin.Model
{
    public class EventoModel
    {
        public int Id_Evento {  get; set; }
        public TipoEventoModel TipoEvento { get; set; }
        public JugadorModel JugadorPrincipal { get; set; }
        public JugadorModel JugadorSecundario { get; set; }
        public int Minuto {get; set; }
        public PartidoModel Partido { get; set; }

    }
}
