using InsuranceAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAPI.Domain.Interfaces
{
    public interface IInsuredRepository
    {
        Task<Insured?> GetByIdAsync(int id);
        Task<IEnumerable<Insured>> GetAllAsync();
        Task AddAsync(Insured insured);
        Task UpdateAsync(Insured insured);
        Task DeleteAsync(int id);
    }
}
