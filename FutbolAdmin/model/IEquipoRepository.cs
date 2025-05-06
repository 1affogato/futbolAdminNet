using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutbolAdmin.Model
{
    public interface IEquipoRepository
    {
        void Add(EquipoModel equipo);

        void Edit(EquipoModel equipo);

        void Remove(int id);

        EquipoModel GetById(int id);
    }
}
