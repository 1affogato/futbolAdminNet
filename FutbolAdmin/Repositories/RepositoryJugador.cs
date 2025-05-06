using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutbolAdmin.Model;
using Oracle.ManagedDataAccess.Client;

namespace FutbolAdmin.Repositories {
    internal class RepositoryJugador : RepositoryBase, ICrud<JugadorModel> {
        public void Add(JugadorModel entity) {
            using (var connection = GetConnection())
            using (var command = new OracleCommand()) {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO JUGADORES (ID_JUGADOR, NOMBRE, EDAD, PARTIDOS_JUGADOS, GOLES, ASISTENCIAS, TARJETAS_ROJAS, TARJETAS_AMARILLAS, ID_EQUIPO) VALUES (:idJugador, :nombre, :edad, :partidosJugados, :goles, :asistencias, :tarjetasRojas, :tarjetasAmarillas, :idEquipo)";
                command.Parameters.Add(new OracleParameter("idJugador", entity.Id_Jugador));
                command.Parameters.Add(new OracleParameter("nombre", entity.Nombre));
                command.Parameters.Add(new OracleParameter("edad", entity.Edad));
                command.Parameters.Add(new OracleParameter("partidosJugados", entity.PartidosJugados));
                command.Parameters.Add(new OracleParameter("goles", entity.Goles));
                command.Parameters.Add(new OracleParameter("asistencias", entity.Asistencias));
                command.Parameters.Add(new OracleParameter("tarjetasRojas", entity.TarjetasRojas));
                command.Parameters.Add(new OracleParameter("tarjetasAmarillas", entity.TarjetasAmarillas));
                command.Parameters.Add(new OracleParameter("idEquipo", entity.Equipo.Id_Equipo));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Delete(int id) {
            using (var connection = GetConnection())
            using (var command = new OracleCommand()) {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM JUGADORES WHERE ID_JUGADOR = :id";
                command.Parameters.Add(new OracleParameter("id", id));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public IEnumerable<JugadorModel> GetAll() {
            using (var connection = GetConnection())
            using (var command = new OracleCommand()) {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM JUGADORES";
                using (var reader = command.ExecuteReader()) {
                    var jugadores = new List<JugadorModel>();
                    while (reader.Read()) {
                        var jugador = new JugadorModel {
                            // Mapear cada jugador a lo que regrese el reader
                        };
                        jugadores.Add(jugador);
                    }
                    return jugadores;
                }
            }
        }

        public JugadorModel GetById(int id) {
            using (var connection = GetConnection())
            using (var command = new OracleCommand()) {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM JUGADORES WHERE ID_JUGADOR = :id";
                command.Parameters.Add(new OracleParameter("id", id));
                using (var reader = command.ExecuteReader()) {
                    if (!reader.Read()) {
                        return null;
                    }
                    var jugador = new JugadorModel {
                        // Mapear el jugador a lo que regrese el reader
                    };
                    return jugador;
                }
            }
        }

        public void Update(JugadorModel entity) {
            using (var connection = GetConnection())
            using (var command = new OracleCommand()) {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE JUGADORES SET NOMBRE = :nombre, EDAD = :edad, PARTIDOS_JUGADOS = :partidosJugados, GOLES = :goles, ASISTENCIAS = :asistencias, TARJETAS_ROJAS = :tarjetasRojas, TARJETAS_AMARILLAS = :tarjetasAmarillas, ID_EQUIPO = :idEquipo WHERE ID_JUGADOR = :idJugador";
                command.Parameters.Add(new OracleParameter("idJugador", entity.Id_Jugador));
                command.Parameters.Add(new OracleParameter("nombre", entity.Nombre));
                command.Parameters.Add(new OracleParameter("edad", entity.Edad));
                command.Parameters.Add(new OracleParameter("partidosJugados", entity.PartidosJugados));
                command.Parameters.Add(new OracleParameter("goles", entity.Goles));
                command.Parameters.Add(new OracleParameter("asistencias", entity.Asistencias));
                command.Parameters.Add(new OracleParameter("tarjetasRojas", entity.TarjetasRojas));
                command.Parameters.Add(new OracleParameter("tarjetasAmarillas", entity.TarjetasAmarillas));
                command.Parameters.Add(new OracleParameter("idEquipo", entity.Equipo.Id_Equipo));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
