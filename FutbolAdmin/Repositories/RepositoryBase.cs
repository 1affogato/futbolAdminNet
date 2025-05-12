using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace FutbolAdmin.Repositories {
    public abstract class RepositoryBase<T> : ICrud<T> {

        private readonly string _connectionString;

        public RepositoryBase() {
            _connectionString = "User Id=TU_USUARIO;Password=TU_CONTRASEÑA_DEL_USUARIO;Data Source=localhost:1521/ORCLPDB1;";
        }

        public OracleConnection GetConnection() {
            return new OracleConnection(_connectionString);
        }

        public abstract void Add(T entity);
        public abstract void Delete(int id);
        public abstract IEnumerable<T> GetAll();
        public abstract T GetById(int id);
        public abstract void Update(T entity);
    }
}
