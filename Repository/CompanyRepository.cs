using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// la class implemente repository base pour avoir acces au methodes de base
    /// et implemente egalement une interface qui lui ai propre dans laquel on pourra mettre des methodes specifiques au model
    /// </summary>
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
