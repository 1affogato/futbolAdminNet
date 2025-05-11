using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using FutbolAdmin.Model;
using Oracle.ManagedDataAccess.Client;

namespace FutbolAdmin.Repositories {
    internal class RepositoryCuentaAdmin : RepositoryBase<CuentaAdminModel> {
        public override void Add(CuentaAdminModel entity) {
            using (var connection = GetConnection())
            using (var command = new OracleCommand()) {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO CUENTAS_ADMIN (ID_CUENTA, NOMBRE, CONTRASENA) VALUES (:idCuenta, :nombre, :contrasena)";
                command.Parameters.Add(new OracleParameter("idCuenta", entity.Id_Cuenta));
                command.Parameters.Add(new OracleParameter("nombre", entity.Nombre));
                command.Parameters.Add(new OracleParameter("contrasena", entity.Contraseña));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public override void Delete(int id) {
            using (var connection = GetConnection())
            using (var command = new OracleCommand()) {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM CUENTAS_ADMIN WHERE ID_CUENTA = :id";
                command.Parameters.Add(new OracleParameter("id", id));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        protected SecureString ToSecureString(string s) {
            SecureString secureString = new SecureString();
            foreach (char c in s) {
                secureString.AppendChar(c);
            }
            secureString.MakeReadOnly();
            return secureString;
        }

        public override IEnumerable<CuentaAdminModel> GetAll() {
            using (var connection = GetConnection())
            using (var command = new OracleCommand()) {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM CUENTAS_ADMIN";
                using (var reader = command.ExecuteReader()) {
                    var cuentas = new List<CuentaAdminModel>();
                    while (reader.Read()) {
                        var cuenta = new CuentaAdminModel {
                            Id_Cuenta = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Contraseña = ToSecureString(reader.GetString(2))
                        };
                        cuentas.Add(cuenta);
                    }
                    return cuentas;
                }
            }
        }

        public override CuentaAdminModel GetById(int id) {
            using (var connection = GetConnection())
            using (var command = new OracleCommand()) {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM CUENTAS_ADMIN WHERE ID_CUENTA = :id";
                command.Parameters.Add(new OracleParameter("id", id));
                using (var reader = command.ExecuteReader()) {
                    if (!reader.Read()) {
                        return null;
                    }
                    var cuenta = new CuentaAdminModel {
                        Id_Cuenta = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Contraseña = ToSecureString(reader.GetString(2))
                    };
                    return cuenta;
                }
            }
        }

        public override void Update(CuentaAdminModel entity) {
            using (var connection = GetConnection())
            using (var command = new OracleCommand()) {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE CUENTAS_ADMIN SET NOMBRE = :nombre, CONTRASENA = :contrasena WHERE ID_CUENTA = :idCuenta";
                command.Parameters.Add(new OracleParameter("nombre", entity.Nombre));
                command.Parameters.Add(new OracleParameter("contrasena", entity.Contraseña));
                command.Parameters.Add(new OracleParameter("idCuenta", entity.Id_Cuenta));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
