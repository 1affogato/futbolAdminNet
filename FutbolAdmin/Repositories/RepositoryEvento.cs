using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutbolAdmin.Model;
using Oracle.ManagedDataAccess.Client;

namespace FutbolAdmin.Repositories {
    public class RepositoryEvento : RepositoryBase<EventoModel> {
        public override void Add(EventoModel entity) {
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

        public override void Delete(int id) {
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

        public override IEnumerable<EventoModel> GetAll() {
            using (var connection = GetConnection())
            using (var command = new OracleCommand()) {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM EVENTOS";
                using (var reader = command.ExecuteReader()) {
                    var eventos = new List<EventoModel>();
                    while (reader.Read()) {
                        var evento = new EventoModel {
                            Id_Evento = reader.GetInt32(0),
                            // TipoEvento = new RepositoryTipoEvento().GetById(reader.GetInt32(1)),
                            JugadorPrincipal = new RepositoryJugador().GetById(reader.GetInt32(2)),
                            JugadorSecundario = new RepositoryJugador().GetById(reader.GetInt32(3)),
                            Minuto = reader.GetInt32(4),
                            // Partido = new RepositoryPartido().GetById(reader.GetInt32(5))
                        };
                        eventos.Add(evento);
                    }
                    return eventos;
                }
            }
        }

        public override EventoModel GetById(int id) {
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
                        Id_Evento = reader.GetInt32(0),
                        // TipoEvento = new RepositoryTipoEvento().GetById(reader.GetInt32(1)),
                        JugadorPrincipal = new RepositoryJugador().GetById(reader.GetInt32(2)),
                        JugadorSecundario = new RepositoryJugador().GetById(reader.GetInt32(3)),
                        Minuto = reader.GetInt32(4),
                        // Partido = new RepositoryPartido().GetById(reader.GetInt32(5))
                    };
                    return evento;
                }
            }
        }

        public override void Update(EventoModel entity) {
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
