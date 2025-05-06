using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutbolAdmin.Model;
using Oracle.ManagedDataAccess.Client;

namespace FutbolAdmin.Repositories {
    internal class RepositoryEvento : RepositoryBase, ICrud<EventoModel> {
        public void Add(EventoModel entity) {
            using (var connection = GetConnection())
            using (var command = new OracleCommand()) {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO EVENTOS (ID_EVENTO, TIPO_EVENTO, JUGADOR_PRINCIPAL, JUGADOR_SECUNDARIO, MINUTO, PARTIDO) VALUES (:idEvento, :tipoEvento, :jugadorPrincipal, :jugadorSecundario, :minuto, :partido)";
                command.Parameters.Add(new OracleParameter("idEvento", entity.Id_Evento));
                command.Parameters.Add(new OracleParameter("tipoEvento", entity.TipoEvento.Id_TipoEvento));
                command.Parameters.Add(new OracleParameter("jugadorPrincipal", entity.JugadorPrincipal.Id_Jugador));
                command.Parameters.Add(new OracleParameter("jugadorSecundario", entity.JugadorSecundario.Id_Jugador));
                command.Parameters.Add(new OracleParameter("minuto", entity.Minuto));
                command.Parameters.Add(new OracleParameter("partido", entity.Partido.Id_Partido));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Delete(int id) {
            using (var connection = GetConnection())
            using (var command = new OracleCommand()) {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM EVENTOS WHERE ID_EVENTO = :id";
                command.Parameters.Add(new OracleParameter("id", id));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public IEnumerable<EventoModel> GetAll() {
            using (var connection = GetConnection())
            using (var command = new OracleCommand()) {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM EVENTOS";
                using (var reader = command.ExecuteReader()) {
                    var eventos = new List<EventoModel>();
                    while (reader.Read()) {
                        var evento = new EventoModel {
                            // Mapear cada evento a lo que regrese el reader
                        };
                        eventos.Add(evento);
                    }
                    return eventos;
                }
            }
        }

        public EventoModel GetById(int id) {
            using (var connection = GetConnection())
            using (var command = new OracleCommand()) {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM EVENTOS WHERE ID_EVENTO = :id";
                command.Parameters.Add(new OracleParameter("id", id));
                using (var reader = command.ExecuteReader()) {
                    if (!reader.Read()) {
                        return null;
                    }
                    var evento = new EventoModel {
                        // Mapear cada evento a lo que regrese el reader
                    };
                    return evento;
                }
            }
        }

        public void Update(EventoModel entity) {
            using (var connection = GetConnection())
            using (var command = new OracleCommand()) {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE EVENTOS SET TIPO_EVENTO = :tipoEvento, JUGADOR_PRINCIPAL = :jugadorPrincipal, JUGADOR_SECUNDARIO = :jugadorSecundario, MINUTO = :minuto, PARTIDO = :partido WHERE ID_EVENTO = :evento";
                command.Parameters.Add(new OracleParameter("tipoEvento", entity.TipoEvento.Id_TipoEvento));
                command.Parameters.Add(new OracleParameter("jugadorPrincipal", entity.JugadorPrincipal.Id_Jugador));
                command.Parameters.Add(new OracleParameter("jugadorSecundario", entity.JugadorSecundario.Id_Jugador));
                command.Parameters.Add(new OracleParameter("minuto", entity.Minuto));
                command.Parameters.Add(new OracleParameter("partido", entity.Partido.Id_Partido));
                command.Parameters.Add(new OracleParameter("evento", entity.Id_Evento));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
