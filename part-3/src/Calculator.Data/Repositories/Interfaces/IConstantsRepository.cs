using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calculator.Data.Repositories.Interfaces
{
    public interface IConstantsRepository
    {
        Task AddConstant(string name, string value);
        Task<List<Entities.Constant>> GetConstants();
        Task<Entities.Constant> GetConstant(string name);
    }
}