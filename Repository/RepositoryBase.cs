using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// cette class ainsi que l'interface qu'elle implemente fonctionnent avec le type T. Ce type T donne encore plus de réutilisabilité à la classe RepositoryBase. 
    /// Cela signifie que nous n'avons pas besoin de spécifier le modèle exact (classe) pour le moment pour que RepositoryBase fonctionne avec. Nous pouvons le faire plus tard.
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext)        
           => RepositoryContext = repositoryContext;

        /// <summary>
        /// utilisationn du paramètre trackChanges, pour améliorer la vitesse des requête,
        /// Lorsqu'il est défini sur false, nous attachons la méthode AsNoTracking à notre requête pour informer EF Core qu'il n'a pas besoin de suivre les modifications pour les entités requises
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public IQueryable<T> FindAll(bool trackChanges) 
            => !trackChanges ?
            RepositoryContext.Set<T>()
            .AsNoTracking() :
            RepositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
            => !trackChanges ?
            RepositoryContext.Set<T>()
            .Where(expression)
            .AsNoTracking() :
            RepositoryContext.Set<T>()
            .Where(expression);

        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);         
    }
}



//AsNoTracking:
//Lorsque nous récupérons des entités à l'aide d'une requête d'objet,
//Entity Framework place ces entités dans un cache et suit les modifications apportées à ces entités jusqu'à ce que la méthode savechanges soit appelée.
//Parfois, nous ne souhaitons pas suivre certaines entités car les données ne sont utilisées qu'à des fins de visualisation et d'autres opérations telles que l'insertion,
//la mise à jour et la suppression ne sont pas effectuées. Par exemple, les données d'affichage dans une grille en lecture seule.