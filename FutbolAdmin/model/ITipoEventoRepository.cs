using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutbolAdmin.Model
{
    public interface ITipoEventoRepository
    {
        void Add(TipoEventoModel tipoEvento);

        void Edit(TipoEventoModel tipoEvento);

        void Remove(int id);

        TipoEventoModel GetById(int id);
    }
}
