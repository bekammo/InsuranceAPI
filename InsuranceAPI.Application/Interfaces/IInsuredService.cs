using InsuranceAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAPI.Application.Interfaces
{
    public interface IInsuredService
    {
        Task<IEnumerable<Insured>> GetAllAsync();
        Task<Insured?> GetByIdAsync(int id);
        Task AddAsync(Insured insured);
        Task UpdateAsync(Insured insured);
        Task DeleteAsync(int id);
    }
}
