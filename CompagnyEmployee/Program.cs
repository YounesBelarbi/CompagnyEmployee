using CompagnyEmployee.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
//variable builder de type WebApplicationBuilder. Cette class est responsanble de 4 elments principaux:
//Ajout de la configuration au projet � l'aide de la propri�t� builder.Configuration
//Enregistrement des services dans notre application avec la propri�t� builder.Services
//Configuration de la journalisation avec la propri�t� builder.Logging
//Autre configuration IHostBuilder et IWebHostBuilder

// Add services to the container.
//Les service qui ont �t� �crit dans la class ServiceExtensions seront charg� ici.
builder.Services.ConfigureCors(); // on rajout� cette configuration dans la class ServiceExtensions 
builder.Services.ConfigureIISIntegrations();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

//Cette m�thode enregistre uniquement les contr�leurs dans IServiceCollection et non dans les vues ou les pages car ils ne sont pas requis dans le projet d'API Web
builder.Services.AddControllers();

//avec la m�thode build on cr�� la variable de type WebApplication
var app = builder.Build();

// Configure the HTTP request pipeline.
//********** m�thodes obligatoires pour la configuration du pipeline de requ�te ************

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    //app.UseHsts() ajoutera un middleware pour l'utilisation de HSTS, qui ajoute l'en-t�te Strict-Transport-Security.
    app.UseHsts();

/********************************************************************************************/



//cette methode permet d'ajouter le middleware pour la redirection de HTTP vers HTTPS
app.UseHttpsRedirection();


//*********** m�thodes obligatoires pour la configuration du pipeline de requ�te ************

//app.UseStaticFiles() permet d'utiliser des fichiers statiques pour la requ�te
//Si le chemin vers le r�pertoire des fichiers statiques n'est pas d�fini, il utilisera un dossier wwwroot dans notre projet par d�faut
app.UseStaticFiles();

//app.UseForwardedHeaders() transmettra les en-t�tes proxy � la requ�te actuelle.
//Cela nous aidera lors du d�ploiement de l'application
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");

/*******************************************************************************************/


//m�thode UseAuthorization qui ajoute le middleware d'autorisation au IApplicationBuilder sp�cifi� pour activer les fonctionnalit�s d'autorisation
app.UseAuthorization();

//m�thode qui ajoute les endpoints des actions du contr�leur � IEndpointRouteBuilder
app.MapControllers();

//methode qui ex�cute l'application et bloque le thread appelant jusqu'� l'arr�t de l'h�te
app.Run();



//"Instructions de niveau sup�rieur" :
//signifie que le compilateur g�n�re les �l�ments d'espace de noms, 
//de classe et de m�thode pour le programme principal de notre application
//LogLevel bloc de class et la m�thod main seront g�n�r� par le compilateur
//on peut rajouter dautres fonctions � la class Propgram, elles seront cr��es en tant que fonctions locales imbriqu�es dans la m�thode Main g�n�r�e
//Les instructions de niveau sup�rieur sont destin�es � simplifier le point d'entr�e de l'application.


//Les "directives using implicites" :
//Signifient que le compilateur ajoute automatiquement diff�rentes directives using bas�es sur le type de projet. pas besoin de le faire manuellement
//Ces directives sont stock�es dans le dossier obj/Debug/net6.0  du projet, sous le nom CompanyEmployees.GlobalUsings.g.cs
//Cela signifie que nous pouvons utiliser diff�rentes classes de ces espaces de noms dans notre projet sans ajouter explicitement des directives using dans nos fichiers de projet.
//Ce type de comportement peut �tre d�sactiver dans le fichier projet(csproj) et en d�sactivant la balise ImplicitUsings�: <ImplicitUsings>disable</ImplicitUsings>