using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    /// <summary>
    /// cette class sera implémenté par le RepositoryManager qui sera chargé de gérer les different repository
    /// </summary>
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }
        void Save();
    }
}
