using System;
using Microsoft.EntityFrameworkCore;
using EGG.Domain.Entities;
using EGG.Domain.Entities.Base;
using EGG.Infra.Data.Configurations;
using prmToolkit.NotificationPattern;

namespace EGG.Infra.Data.Context
{
    public class EGGContext : DbContext
    {
        //EF
        public EGGContext() { }

        public EGGContext(DbContextOptions<EGGContext> options) : base(options) { }

        public DbSet<Empresa> EmpresaSet{ get; set; }
        public DbSet<Produto> ProdutoSet { get; set; }
        public DbSet<Categoria> CategoriaSet { get; set; }
        public DbSet<Pais> PaisSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var stringConnection = "server=localhost;port=3306;database=EGGMediator;uid=root;password=123456";
            optionsBuilder.UseMySql(stringConnection, ServerVersion.AutoDetect(stringConnection)); 
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new PaisConfiguration());

            modelBuilder.Ignore<Notification>();
            modelBuilder.Ignore<EntityBase<Guid>>();
            modelBuilder.Ignore<EntityBase<int>>();

            base.OnModelCreating(modelBuilder);
        }
    }
}