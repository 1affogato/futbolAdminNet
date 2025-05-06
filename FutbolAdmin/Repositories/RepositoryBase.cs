using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace FutbolAdmin.Repositories {
    internal class RepositoryBase {

        private readonly string _connectionString;

        public RepositoryBase() {
            // TODO: _connectionString = "";
        }

        protected SqlConnection GetConnection() {
            return new SqlConnection(_connectionString);
        }
    }
}
