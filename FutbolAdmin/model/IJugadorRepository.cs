using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutbolAdmin.Model
{
    public interface IJugadorRepository
    {
        void Add(JugadorModel jugador);

        void Edit(JugadorModel jugador);

        void Remove(int id);

        JugadorModel GetById(int id);
    }
}
