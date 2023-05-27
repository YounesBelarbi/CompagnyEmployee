namespace CompagnyEmployee.Extensions
{
    /// <summary>
    /// afin d'organiser le code et ne pas encombrer le fichier Program on separe en methodes d'extension dans cette class
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
    }
}


//Une méthode d'extension est par nature une méthode statique
//premier paramètre this qui représente type de données de l'objet qui utilisera cette méthode d'extension