using InsuranceAPI.Application.Interfaces;
using InsuranceAPI.Domain.Interfaces;
using InsuranceAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAPI.Application.Services
{
    public class InsuranceProductService : IInsuranceProductService
    {
        private readonly IInsuranceProductRepository _productRepository;

        public InsuranceProductService(IInsuranceProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<InsuranceProduct>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<InsuranceProduct?> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(InsuranceProduct product)
        {
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateAsync(InsuranceProduct product)
        {
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}
