using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutbolAdmin.Model;
using Oracle.ManagedDataAccess.Client;

namespace FutbolAdmin.Repositories
{
    public class RepositoryTipoEvento : RepositoryBase<TipoEventoModel>
    {
        public override void Add(TipoEventoModel entity)
        {
            using (var connection = GetConnection())
            using (var command = new OracleCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO TIPO_EVENTO (ID_TIPOEVENTO, DESCRIPCION) VALUES (:idTipoEvento, :descripcion)";
                command.Parameters.Add(new OracleParameter("idTipoEvento", entity.Id_TipoEvento));
                command.Parameters.Add(new OracleParameter("descripcion", entity.descripcion));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public override void Delete(int id)
        {
            using (var connection = GetConnection())
            using (var command = new OracleCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM TIPO_EVENTO WHERE ID_TIPOEVENTO = :id";
                command.Parameters.Add(new OracleParameter("id", id));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public override IEnumerable<TipoEventoModel> GetAll()
        {
            using (var connection = GetConnection())
            using (var command = new OracleCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM TIPO_EVENTO";
                using (var reader = command.ExecuteReader())
                {
                    var tipos = new List<TipoEventoModel>();
                    while (reader.Read())
                    {
                        var tipo = new TipoEventoModel
                        {
                            Id_TipoEvento = reader.GetInt32(0),
                            descripcion = reader.GetString(1)
                        };
                        tipos.Add(tipo);
                    }
                    return tipos;
                }
            }
        }

        public override TipoEventoModel GetById(int id)
        {
            using (var connection = GetConnection())
            using (var command = new OracleCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM TIPO_EVENTO WHERE ID_TIPOEVENTO = :id";
                command.Parameters.Add(new OracleParameter("id", id));
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }
                    var tipo = new TipoEventoModel
                    {
                        Id_TipoEvento = reader.GetInt32(0),
                        descripcion = reader.GetString(1)
                    };
                    return tipo;
                }
            }
        }

        public override void Update(TipoEventoModel entity)
        {
            using (var connection = GetConnection())
            using (var command = new OracleCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE TIPO_EVENTO SET DESCRIPCION = :descripcion WHERE ID_TIPOEVENTO = :idTipoEvento";
            }
        }
    }
}
