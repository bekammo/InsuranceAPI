using InsuranceAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAPI.Application.Interfaces
{
    public interface IInsuranceProductService
    {
        Task<IEnumerable<InsuranceProduct>> GetAllAsync();
        Task<InsuranceProduct?> GetByIdAsync(int id);
        Task AddAsync(InsuranceProduct product);
        Task UpdateAsync(InsuranceProduct product);
        Task DeleteAsync(int id);
    }
}
