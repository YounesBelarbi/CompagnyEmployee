using Entities.Models;
using Microsoft.EntityFrameworkCore;

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

        public DbSet<Company>? Compagnies { get; set; }
        public DbSet<Employee> MyProperty { get; set; }
    }
}