using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutbolAdmin.Model
{
    public interface IEventoRepository
    {
        void Add(EventoModel evento);

        void Edit(EventoModel evento);

        void Remove(int id);

        EventoModel GetById(int id);

    }
}
