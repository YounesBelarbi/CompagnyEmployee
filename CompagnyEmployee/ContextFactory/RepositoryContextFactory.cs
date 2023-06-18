using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace CompagnyEmployee.ContextFactory
{
    /// <summary>
    /// Étant donné que notre classe RepositoryContext est dans un projet Repository et non dans le projet principal, cette classe aidera notre application à créer une instance DbContext dérivée au moment de la conception, 
    /// ce qui nous aidera dans nos migrations.
    /// Nous utilisons l'interface IDesignTimeDbContextFactory<out TContext> qui permet aux services de conception de découvrir les implémentations de cette interface. Bien sûr, le paramètre TContext est notre classe RepositoryContext.
    /// </summary>
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            //on specifie le app setting qui doit être utilisé
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //nous pouvons utiliser la méthode GetConnectionString pour accéder à la chaîne de connexion à partir du fichier appsettings.json.
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(configuration.GetConnectionString("sqlConnection"));

            //nous renvoyons une nouvelle instance de notre classe RepositoryContext avec les options fournies.
            return new RepositoryContext(builder.Options);
        }
    }
}
