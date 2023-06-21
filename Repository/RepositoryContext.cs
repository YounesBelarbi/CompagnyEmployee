using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
    /// <summary>
    /// cette classe de contexte sera un composant middleware pour la communication avec la base de données.
    /// elle doit hériter de la classe DbContext d'Entity Framework Core et se compose de propriétés DbSet, qu'EF Core va utiliser pour la communication avec la base de données
    /// </summary>
    public class RepositoryContext : DbContext

    {
        public RepositoryContext(DbContextOptions options) : base (options) 
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }

        //les table qui seront créées sont les suivantes basé sur les models (entities)
        public DbSet<Company>? Compagnies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}