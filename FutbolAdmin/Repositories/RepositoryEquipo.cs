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
                        var equipo = new EquipoModel(
                            reader.GetInt32(0), // ID_EQUIPO
                            reader.GetString(1), // NOMBRE  
                            reader.GetInt32(2), // VICTORIAS
                            reader.GetInt32(3), // DERROTAS
                            reader.GetInt32(4), // EMPATES
                            reader.GetInt32(5), // GOLES_FAVOR
                            reader.GetInt32(6)  // GOLES_CONTRA
                        );
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
                    var equipo = new EquipoModel(
                        reader.GetInt32(0), // ID_EQUIPO
                        reader.GetString(1), // NOMBRE  
                        reader.GetInt32(2), // VICTORIAS
                        reader.GetInt32(3), // DERROTAS
                        reader.GetInt32(4), // EMPATES
                        reader.GetInt32(5), // GOLES_FAVOR
                        reader.GetInt32(6)  // GOLES_CONTRA
                    );
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
                command.CommandText = "UPDATE EQUIPO SET NOMBRE = :nombre, VICTORIAS = :victorias, DERROTAS = :derrotas, EMPATES = :empates, GOLES_FAVOR = :goles_favor, GOLES_CONTRA = :goles_contra, WHERE ID_EQUIPO = :idEquipo";
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

        public IEnumerable<JugadorModel> GetJugadoresByEquipoId(int id) {
            using (var connection = GetConnection())
            using (var command = new OracleCommand()) {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM JUGADOR WHERE ID_EQUIPO = :id";
                command.Parameters.Add(new OracleParameter("id", id));
                using (var reader = command.ExecuteReader()) {
                    var jugadores = new List<JugadorModel>();
                    while (reader.Read()) {
                        var jugador = new JugadorModel {
                            Id_Jugador = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Edad = reader.GetInt32(2),
                            PartidosJugados = reader.GetInt32(3),
                            Goles = reader.GetInt32(4),
                            Asistencias = reader.GetInt32(5),
                            TarjetasRojas = reader.GetInt32(6),
                            TarjetasAmarillas = reader.GetInt32(7),
                            // Si no jala quitar a otra cosa
                            Equipo = new RepositoryEquipo().GetById(reader.GetInt32(8)), 
                        };
                        jugadores.Add(jugador);
                    }
                    return jugadores;
                }
            }
        }
    }
}
