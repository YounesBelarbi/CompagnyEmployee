using Contracts;
using LoggerService;

namespace CompagnyEmployee.Extensions
{
    /// <summary>
    /// afin d'organiser le code et ne pas encombrer le fichier Program on separe en methodes d'extension dans cette class
    /// Ce type de méthode étend le comportement d'un type dans .NET
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// configuration CORS
        /// pour accorder oue restreindre les droits d'accés
        /// si on veut envoyer des requêtes d'un domaine différent à notre appli. alors la config CORS est obligatoire
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyOrigin() //reste comme ça pour le dev, mais en prod cette méthode sera remplacé par WithOrigins("https://example.com") qui n'autorise les requêtes qu'a partir de la source
                .AllowAnyMethod() //reste comme ça pour le dev, mais en prod cette méthode sera remplacé par WithOrigins("POST", "GET") pour definir les method http autorisé
                .AllowAnyHeader()); // en prod on peut remplacer par la méthode WithHeaders("accept", "contenttype") pour n'autoriser que des en-têtes spécifiques
            });

        /// <summary>
        /// Les applications ASP.NET Core sont par défaut auto-hébergées
        /// et si nous voulons héberger notre application sur IIS, 
        /// nous devons configurer une intégration IIS qui nous aidera éventuellement avec le déploiement sur IIS
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureIISIntegrations(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });

        /// <summary>
        /// permet de rajouter le service dans .net core ioc container (voir le fichier explication supplementaire
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();
    }
}


//Une méthode d'extension est par nature une méthode statique
//premier paramètre this qui représente type de données de l'objet qui utilisera cette méthode d'extension