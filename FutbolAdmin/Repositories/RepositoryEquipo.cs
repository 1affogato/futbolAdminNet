using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutbolAdmin.Model;
using Oracle.ManagedDataAccess.Client;

namespace FutbolAdmin.Repositories
{
    public class RepositoryEquipo : RepositoryBase<EquipoModel>
    {
        public override void Add(EquipoModel entity)
        {
            using (var connection = GetConnection())
            using (var command = new OracleCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO EQUIPO (ID_EQUIPO, NOMBRE, VICTORIAS, DERROTAS, EMPATES, GOLES_FAVOR, GOLES_CONTRA) VALUES (:idEquipo, :nombre, :victorias, :derrotas, :empates, :goles_favor, :goles_contra)";
                command.Parameters.Add(new OracleParameter("idEquipo", entity.Id_Equipo));
                command.Parameters.Add(new OracleParameter("nombre", entity.Nombre));
                command.Parameters.Add(new OracleParameter("victorias", entity.Victorias));
                command.Parameters.Add(new OracleParameter("derrotas", entity.Derrotas));
                command.Parameters.Add(new OracleParameter("empates", entity.Empates));
                command.Parameters.Add(new OracleParameter("goles_favor", entity.GolesFavor));
                command.Parameters.Add(new OracleParameter("goles_contra", entity.GolesContra));
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
                command.CommandText = "DELETE FROM EQUIPO WHERE ID_CUENTA = :id";
                command.Parameters.Add(new OracleParameter("id", id));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public override IEnumerable<EquipoModel> GetAll()
        {
            using (var connection = GetConnection())
            using (var command = new OracleCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM EQUIPO";
                using (var reader = command.ExecuteReader())
                {
                    var equipos = new List<EquipoModel>();
                    while (reader.Read())
                    {
                        var equipo = new EquipoModel();
                        {
                            // Mapear cada jugador a lo que regrese el reader
                        };
                        equipos.Add(equipo);
                    }
                    return equipos;
                }
            }
        }

        public override EquipoModel GetById(int id)
        {
            using (var connection = GetConnection())
            using (var command = new OracleCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM EQUIPO WHERE ID_JUGADOR = :id";
                command.Parameters.Add(new OracleParameter("id", id));
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }
                    var equipo = new EquipoModel
                    {
                        // Mapear el jugador a lo que regrese el reader
                    };
                    return equipo;
                }
            }
        }

        public override void Update(EquipoModel entity)
        {
            using (var connection = GetConnection())
            using (var command = new OracleCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE EQUIPO SET NOMBRE = :nombre, VICTORIAS = :victorias, DERROTAS = :derrotas, EMPATES = :empates, GOLES_FAVOR = :goles_favor, GOLES_CONTRA = :goles_contra, ID_EQUIPO = :idEquipo WHERE ID_EQUIPO = :idEquipo";
                command.Parameters.Add(new OracleParameter("idEquipo", entity.Id_Equipo));
                command.Parameters.Add(new OracleParameter("nombre", entity.Nombre));
                command.Parameters.Add(new OracleParameter("victorias", entity.Victorias));
                command.Parameters.Add(new OracleParameter("derrotas", entity.Derrotas));
                command.Parameters.Add(new OracleParameter("empates", entity.Empates));
                command.Parameters.Add(new OracleParameter("goles_favor", entity.GolesFavor));
                command.Parameters.Add(new OracleParameter("goles_contra", entity.GolesContra));
                command.Parameters.Add(new OracleParameter("idEquipo", entity.Id_Equipo));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
