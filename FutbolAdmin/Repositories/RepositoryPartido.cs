using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutbolAdmin.Model;
using Oracle.ManagedDataAccess.Client;

namespace FutbolAdmin.Repositories
{
    public class RepositoryPartido : RepositoryBase<PartidoModel>
    {
        protected RepositoryEquipo _repositoryEquipo = new RepositoryEquipo();
        public override void Add(PartidoModel entity)
        {
            using (var connection = GetConnection())
            using (var command = new OracleCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO PARTIDO (ID_PARTIDO, FECHA, EQUIPO_LOCAL, EQUIPO_VISITANTE, JORNADA, COMPLETADO, GOLES_LOCAL, GOLES_VISITANTE) VALUES (:idPartido, :fecha, :equipo_local, :equipo_visitante, :jornada, :completado, :goles_local, :goles_visitante)";
                command.Parameters.Add(new OracleParameter("idPartido", entity.Id_Partido));
                command.Parameters.Add(new OracleParameter("fecha", entity.Fecha));
                command.Parameters.Add(new OracleParameter("equipo_local", entity.EquipoLocal.Id_Equipo));
                command.Parameters.Add(new OracleParameter("equipo_visitante", entity.EquipoVisitante.Id_Equipo));
                command.Parameters.Add(new OracleParameter("jornada", entity.Jornada));
                command.Parameters.Add(new OracleParameter("completado", entity.Completado));
                command.Parameters.Add(new OracleParameter("goles_local", entity.GolesLocal));
                command.Parameters.Add(new OracleParameter("goles_visitantes", entity.GolesVisitante));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void AddAll(IEnumerable<PartidoModel> partidos)
        {
            foreach (var item in partidos)
            {
                Add(item);
            }
        }

        public override void Delete(int id)
        {
            using (var connection = GetConnection())
            using (var command = new OracleCommand())
            {
                connection.Open();
                command.Connection = connection;


                command.CommandText = "UPDATE EVENTO SET ID_PARTIDO = NULL WHERE ID_PARTIDO = :id";
                command.Parameters.Add(new OracleParameter("id", id));
                command.ExecuteNonQuery();

                command.CommandText = "DELETE FROM PARTIDO WHERE ID_PARTIDO = :id";
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteAll()
        {
            var partidos = GetAll();
            foreach (var item in partidos)
            {
                Delete(item.Id_Partido);
            }
        }



        public override IEnumerable<PartidoModel> GetAll()
        {
            using (var connection = GetConnection())
            using (var command = new OracleCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM PARTIDO";
                using (var reader = command.ExecuteReader())
                {
                    var partidos = new List<PartidoModel>();
                    while (reader.Read())
                    {
                        var partido = new PartidoModel
                        {
                            Id_Partido = reader.GetInt32(0),
                            Fecha = reader.IsDBNull(1) ? (DateTime?)null : reader.GetDateTime(1),
                            EquipoLocal = _repositoryEquipo.GetById(reader.GetInt32(2)),
                            EquipoVisitante = _repositoryEquipo.GetById(reader.GetInt32(3)),
                            Jornada = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4),
                            Completado = reader.GetInt32(5),
                            GolesLocal = reader.GetInt32(6),
                            GolesVisitante = reader.GetInt32(7)
                        };
                        partidos.Add(partido);
                    }
                    return partidos;
                }
            }
        }

        public override PartidoModel GetById(int id)
        {
            using (var connection = GetConnection())
            using (var command = new OracleCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM PARTIDO WHERE ID_PARTIDO = :id;";
                command.Parameters.Add(new OracleParameter("id", id));
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }
                    var partido = new PartidoModel
                    {
                        Id_Partido = reader.GetInt32(0),
                        Fecha = reader.GetDateTime(1),
                        EquipoLocal = _repositoryEquipo.GetById(reader.GetInt32(2)),
                        EquipoVisitante = _repositoryEquipo.GetById(reader.GetInt32(3)),
                        Jornada = reader.GetInt32(4),
                        Completado = reader.GetInt32(5),
                        GolesLocal = reader.GetInt32(6),
                        GolesVisitante = reader.GetInt32(7)
                    };
                    return partido;
                }
            }
        }

        public override void Update(PartidoModel entity)
        {
            using (var connection = GetConnection())
            using (var command = new OracleCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE PARTIDO SET FECHA = :fecha, EQUIPO_LOCAL = :equipo_local, EQUIPO_VISITANTE = :equipo_visitante,  JORNADA = :jornada, COMPLETADO = :completado, GOLES_LOCAL = :goles_local, GOLES_VISITANTE = :goles_visitante WHERE ID_PARTIDO = :id_Partido";
                command.Parameters.Add(new OracleParameter("fecha", entity.Fecha));
                command.Parameters.Add(new OracleParameter("equipo_local", entity.EquipoLocal.Id_Equipo));
                command.Parameters.Add(new OracleParameter("equipo_visitante", entity.EquipoVisitante.Id_Equipo));
                command.Parameters.Add(new OracleParameter("jornada", entity.Jornada));
                command.Parameters.Add(new OracleParameter("completado", entity.Completado));
                command.Parameters.Add(new OracleParameter("goles_local", entity.GolesLocal));
                command.Parameters.Add(new OracleParameter("goles_visitantes", entity.GolesVisitante));
                command.Parameters.Add(new OracleParameter("id_Partido", entity.Id_Partido));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
