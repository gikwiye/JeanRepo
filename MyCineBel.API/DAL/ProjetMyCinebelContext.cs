using Microsoft.EntityFrameworkCore;
using MyCineBel.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.DAL
{
    public class ProjetMyCinebelContext : DbContext
    {
        public ProjetMyCinebelContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Acteur> Acteurs { get; set; }

        public DbSet<ActeurFilm> ActeurFilms { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Compte> Comptes { get; set; }

        public DbSet<ComptesRole> ComptesRoles { get; set; }

        public DbSet<Role> Roles { get; set; }


        public DbSet<Film> Films { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Realisateur> Realisateurs { get; set; }

        public DbSet<Salle> Salles { get; set; }
    
        public DbSet<Seance> Seances { get; set; }

        public DbSet<Tarif> Tarifs { get; set; }

        public DbSet<TarifSeance> TarifSeances { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

    
    }
}
