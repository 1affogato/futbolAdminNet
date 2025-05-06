using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutbolAdmin.Repositories {
    internal interface ICrud<T> {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
