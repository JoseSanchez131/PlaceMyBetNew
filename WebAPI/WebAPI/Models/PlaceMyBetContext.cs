using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebApplication2.Models
{
    public class PlaceMyBetContext : DbContext
    {
        public DbSet<Cuenta> Cuentas { get; set; } //Taula
        public DbSet<Usuario> Usuarios { get; set; } //Taula
        public DbSet<Apuesta> Apuestas { get; set; } //Taula
        public DbSet<Mercado> Mercados { get; set; } //Taula
        public DbSet<Evento> Eventos { get; set; } //Taula
        

        public PlaceMyBetContext()
        {
        }

        public PlaceMyBetContext(DbContextOptions options)
        : base(options)
        {
        }

        //Mètode de configuració
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=ejercicio2_accesodatos;Uid=root;password='';SslMode=none");//màquina retos

            }
        }

        //Inserció inicial de dades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Evento>().HasData(new Evento(1, "Madrid", "Barcelona",2));
            /*modelBuilder.Entity<Eventos>().HasData(new Eventos(2, "Valencia", "Betis", 2));
            modelBuilder.Entity<Eventos>().HasData(new Eventos(3, "Sevilla", "Deportivo", 3));*/
           // modelBuilder.Entity<Mercado>().HasData(new Mercado(1, 1, 2, 1,2,2,2));
           // modelBuilder.Entity<Apuesta>().HasData(new Apuesta(1, 1, "Jose.sanchez.gimenez@gmail.com",1,2,50));



        }
    }
}