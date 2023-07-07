classDiagram

    %% realisation ou implementation
    IRepositoryBase <|.. RepositoryBase 
    IRepositoryDuModel1 <|.. RepositoryDuModel1
    IRepositoryDuModel2 <|.. RepositoryDuModel2
    IDesignTimeDbContextFactory <|.. RepositoryContextFactory
    IRepositoryManager <|.. RepositoryManager
    IServiceManager <|.. IModel1Service
    IServiceManager <|.. IModel2Service

    %% generalisation ou heritage:
    RepositoryBase <|-- RepositoryDuModel1
    RepositoryBase <|-- RepositoryDuModel2    
    DBcontext <|--RepositoryContext 
    Model1Service <|-- IModel1Service
    Model2Service <|-- IModel2Service

    %% agregation: on a une instance de la class dans l'autre class
    RepositoryContextFactory o-- RepositoryContext
    RepositoryDuModel1 o-- RepositoryContext
    RepositoryDuModel2 o-- RepositoryContext
    RepositoryManager o-- RepositoryContext
    Model1Service o-- IRepositoryManager
    Model2Service o-- IRepositoryManager


    %% etant donne que le RepositoryContext ne se trouve pas dans le projet principal
    %% cette classe aidera notre application à créer une instance DbContext dérivée au moment de la conception, 
    %% ce qui nous aidera dans nos migrations
    %% on implementera  de cette façon : IDesignTimeDbContextFactory<RepositoryContext>
    %% dans le dossier ContextFactory dans le projet principale
    class RepositoryContextFactory {
        CreateDbContext()
    }

    %% class systeme
    class IDesignTimeDbContextFactory {
        <<interface>>
    }


    %% dans le projet Models
    class Model1 {
        prop1
        prop2
        ICollection du Model2 %%liste des Model2 lié

    }


    %% dans le projet Models
    class Model2 {
        prop1
        prop2
        Model1 %% model parent 

    }
    

    %% class systeme
    %% cette class class est issue de EntityFrameworkCore
    class DBcontext {
    }


    %% dans le projet Repository  
    %% composant middleware pour la communication avec la base de données  
    class RepositoryContext {
        %%propriété de ef core utilisation: public DbSet<Model1> Model1 { get; set; }
        DbSet
    }


    %% dans le projet Contracts
    %% class avec les methodes des base
     class IRepositoryBase{
        <<interface>>
        find()
        findAll()
        FindByCiondition()
        create()
        delete()
        update()
    }


    %% dans le projet Repository
    class RepositoryBase{
        <<abstract>>
        %% RepositoryContext sera injecter dans le contructeur à partir des class enfant
        RepositoryContext
        <<interface>>
        find()
        findAll()
        FindByCiondition()
        create()
        delete()
        update()
    }


    %% dans le projet Contracts
    %% class avec les methodes qpécifiques au model
    class IRepositoryDuModel1{
        <<interface>>
    }


    %% dans le projet Contracts
    %% class avec les methodes qpécifiques au model
    class IRepositoryDuModel2{
        <<interface>>
    }
    

    %% dans le projet Repository
    class RepositoryDuModel1{
        %% RepositoryContext sera injecter dans le constructeur et transmis au constructeur de la class mère
        %% public RepositoryDuModel1(RepositoryContext repositoryContext) : base(repositoryContext)
    }
    

    %% dans le projet Repository
    class RepositoryDuModel2{
        %% RepositoryContext sera injecter dans le constructeur et transmis au constructeur de la class mère
        %% public RepositoryDuModel2(RepositoryContext repositoryContext) : base(repositoryContext)
    }
   
    
    %% dans le projet Contracts
    class IRepositoryManager{
        <<interface>>
        IRepositoryDuModel1
        IRepositoryDuModel2
        save()
    }

    %% dasn le projet Repository
    class RepositoryManager {
        repositoryContext
        IRepositoryDuModel1
        IRepositoryDuModel2
        save()
    }

    %% dans le projet Contracts.Service
    class IServiceManager{
        <<interface>>
        IServiceDuModel1
        IServiceDuModel2
    }

    %% dans le projet Contracts.Service
    class IModel1Service{
        <<interface>>
    }

    %% dans le projet Contracts.Service
    class IModel2Service{
        <<interface>>
    }

     %% dans le projet Service
    class Model1Service{
    }

    %% dans le projet Service
    class Model2Service{
    }
    


