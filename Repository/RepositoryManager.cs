using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// Cette class est chargée de créer pour nous les instances de repository et les enregistrer dans le conteneur d'injection de dépendances
    /// grâce à cela nous pourrons les injecter dasn nos services à travers les constructeurs.
    /// On peut grâce à cette class appeler n'importe quel repository dont nous avons besoin
    /// cette class se charger également de sauvergarder les modifications à la fin.
    /// On peut faire plusieurs actions differentes avant de sauvegarder.
    /// </summary>
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICompanyRepository> _companyRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _companyRepository = new Lazy<ICompanyRepository>(() => new
            CompanyRepository(repositoryContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new
            EmployeeRepository(repositoryContext));
        }
        public ICompanyRepository Company => _companyRepository.Value;
        public IEmployeeRepository Employee => _employeeRepository.Value;
        public void Save() => _repositoryContext.SaveChanges();
    }

}


//nous créons des propriétés qui exposeront les référentiels concrets et nous avons également la méthode Save ()
//    à utiliser une fois toutes les modifications terminées sur un certain objet. 
//    C'est une bonne pratique car nous pouvons désormais, par exemple, ajouter deux sociétés,
//    modifier deux employés et supprimer une société, le tout en une seule action, puis appeler la méthode Save une seule fois. 
//    Toutes les modifications seront appliquées ou si quelque chose échoue, toutes les modifications seront annulées

//Lazy:
//Lazy pour assurer l'initialisation paresseuse de nos référentiels. Cela signifie que nos instances de référentiel ne seront créées que lorsque nous y accéderons pour la première fois, et pas avant.