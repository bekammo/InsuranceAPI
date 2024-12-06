using InsuranceAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAPI.Domain.Interfaces
{
    public interface IInsuranceProductRepository
    {
        Task<InsuranceProduct?> GetByIdAsync(int id);
        Task<IEnumerable<InsuranceProduct>> GetAllAsync();
        Task AddAsync(InsuranceProduct product);
        Task UpdateAsync(InsuranceProduct product);
        Task DeleteAsync(int id);
    }
}
