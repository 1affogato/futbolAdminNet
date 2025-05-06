using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data.Entity;

using FutbolAdmin.Model;

namespace FutbolAdmin.Repositories {
    internal class RepositoryBase : DbContext {

        // La string de conexión está en App.config en la raíz del proyecto
        public RepositoryBase() : base("name=RepositoryBase") {
            // TODO: _connectionString = "";
        }

        public DbSet<EquipoModel> Equipos { get; set; }
        public DbSet<JugadorModel> Jugadores { get; set; }
        public DbSet<PartidoModel> Partidos { get; set; }
        public DbSet<EventoModel> Eventos { get; set; }
        public DbSet<TipoEventoModel> TiposEventos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema("MYSCHEMA");


        }
    }
}
