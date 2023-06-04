2.4 Configuration Logger Service for Logging Messages
pour rajouter un service dans le .Net core ioc container. par exemple le logger service
il y a 3 moyens différents:

• En appelant la méthode services.AddSingleton, nous pouvons créer un service la première fois que nous le demandons, 
puis chaque demande ultérieure appellera la même instance du service. Cela signifie que tous les composants partagent 
le même service chaque fois qu'ils en ont besoin et que la même instance sera utilisée pour chaque appel de méthode. 

• En appelant la méthode services.AddScoped, nous pouvons créer un service une fois par requête. Cela signifie que chaque 
fois que nous envoyons une requête HTTP à l'application, une nouvelle instance du service sera créée. 

• En appelant la méthode services.AddTransient, nous pouvons créer un service chaque fois que l'application le demande. 
Cela signifie que si plusieurs composants ont besoin du service, il sera recréé pour chaque demande de composant

pour le logger service ce sera la methode services.AddSingleton qui sera utilisé. voir la méthode ConfigureLoggerService 
dans /Extensions/ServiceExtensions.cs + dans program.cs la ligne builder.Services.ConfigureLoggerService();

resultat:
Chaque fois que nous voulons utiliser un service de log, il nous suffit de l'injecter dans le constructeur de la classe qui en a besoin. 
.NET Core résoudra ce service et les fonctionnalités de journalisation seront disponibles. c'est l'injection de dépendances


