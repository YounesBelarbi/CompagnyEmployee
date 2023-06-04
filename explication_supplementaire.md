2.4 Configuration Logger Service for Logging Messages
pour rajouter un service dans le .Net core ioc container. par exemple le logger service
il y a 3 moyens diff�rents:

� En appelant la m�thode services.AddSingleton, nous pouvons cr�er un service la premi�re fois que nous le demandons, 
puis chaque demande ult�rieure appellera la m�me instance du service. Cela signifie que tous les composants partagent 
le m�me service chaque fois qu'ils en ont besoin et que la m�me instance sera utilis�e pour chaque appel de m�thode. 

� En appelant la m�thode services.AddScoped, nous pouvons cr�er un service une fois par requ�te. Cela signifie que chaque 
fois que nous envoyons une requ�te HTTP � l'application, une nouvelle instance du service sera cr��e. 

� En appelant la m�thode services.AddTransient, nous pouvons cr�er un service chaque fois que l'application le demande. 
Cela signifie que si plusieurs composants ont besoin du service, il sera recr�� pour chaque demande de composant

pour le logger service ce sera la methode services.AddSingleton qui sera utilis�. voir la m�thode ConfigureLoggerService 
dans /Extensions/ServiceExtensions.cs + dans program.cs la ligne builder.Services.ConfigureLoggerService();

resultat:
Chaque fois que nous voulons utiliser un service de log, il nous suffit de l'injecter dans le constructeur de la classe qui en a besoin. 
.NET Core r�soudra ce service et les fonctionnalit�s de journalisation seront disponibles. c'est l'injection de d�pendances


