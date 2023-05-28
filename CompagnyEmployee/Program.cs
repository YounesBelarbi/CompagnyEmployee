using CompagnyEmployee.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
//variable builder de type WebApplicationBuilder. Cette class est responsanble de 4 elments principaux:
//Ajout de la configuration au projet à l'aide de la propriété builder.Configuration
//Enregistrement des services dans notre application avec la propriété builder.Services
//Configuration de la journalisation avec la propriété builder.Logging
//Autre configuration IHostBuilder et IWebHostBuilder

// Add services to the container.
//Les service qui ont été écrit dans la class ServiceExtensions seront chargé ici.
builder.Services.ConfigureCors(); // on rajouté cette configuration dans la class ServiceExtensions 
builder.Services.ConfigureIISIntegrations();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
//********** méthodes obligatoires pour la configuration du pipeline de requête ************

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    //app.UseHsts() ajoutera un middleware pour l'utilisation de HSTS, qui ajoute l'en-tête Strict-Transport-Security.
    app.UseHsts();

/********************************************************************************************/




app.UseHttpsRedirection();

//*********** méthodes obligatoires pour la configuration du pipeline de requête ************

//app.UseStaticFiles() permet d'utiliser des fichiers statiques pour la requête
//Si le chemin vers le répertoire des fichiers statiques n'est pas défini, il utilisera un dossier wwwroot dans notre projet par défaut
app.UseStaticFiles();

//app.UseForwardedHeaders() transmettra les en-têtes proxy à la requête actuelle.
//Cela nous aidera lors du déploiement de l'application
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");

/*******************************************************************************************/


app.UseAuthorization();

app.MapControllers();

app.Run();



//"Instructions de niveau supérieur" :
//signifie que le compilateur génère les éléments d'espace de noms, 
//de classe et de méthode pour le programme principal de notre application
//LogLevel bloc de class et la méthod main seront généré par le compilateur
//on peut rajouter dautres fonctions à la class Propgram, elles seront créées en tant que fonctions locales imbriquées dans la méthode Main générée
//Les instructions de niveau supérieur sont destinées à simplifier le point d'entrée de l'application.


//Les "directives using implicites" :
//Signifient que le compilateur ajoute automatiquement différentes directives using basées sur le type de projet. pas besoin de le faire manuellement
//Ces directives sont stockées dans le dossier obj/Debug/net6.0  du projet, sous le nom CompanyEmployees.GlobalUsings.g.cs
//Cela signifie que nous pouvons utiliser différentes classes de ces espaces de noms dans notre projet sans ajouter explicitement des directives using dans nos fichiers de projet.
//Ce type de comportement peut être désactiver dans le fichier projet(csproj) et en désactivant la balise ImplicitUsings : <ImplicitUsings>disable</ImplicitUsings>