using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace FutbolAdmin.Repositories {
    internal class RepositoryBase {

        private readonly string _connectionString;

        public RepositoryBase() {
            _connectionString = "User Id=TU_USUARIO;Password=TU_CONTRASEÑA_DEL_USUARIO;Data Source=localhost:1521/ORCLPDB1;";
        }

        public OracleConnection GetConnection() {
            return new OracleConnection(_connectionString);
        }
    }
}
