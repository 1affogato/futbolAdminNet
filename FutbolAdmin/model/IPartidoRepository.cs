using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutbolAdmin.Model
{
    public interface IPartidoRepository
    {
        void Add(PartidoModel partido);

        void Edit(PartidoModel partido);

        void Remove(int id);

        PartidoModel GetById(int id);
    }
}
