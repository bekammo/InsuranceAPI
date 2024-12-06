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
    public class InsuredService : IInsuredService
    {
        private readonly IInsuredRepository _insuredRepository;

        public InsuredService(IInsuredRepository insuredRepository)
        {
            _insuredRepository = insuredRepository;
        }

        public async Task<IEnumerable<Insured>> GetAllAsync()
        {
            return await _insuredRepository.GetAllAsync();
        }

        public async Task<Insured?> GetByIdAsync(int id)
        {
            return await _insuredRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Insured insured)
        {
            await _insuredRepository.AddAsync(insured);
        }

        public async Task UpdateAsync(Insured insured)
        {
            await _insuredRepository.UpdateAsync(insured);
        }

        public async Task DeleteAsync(int id)
        {
            await _insuredRepository.DeleteAsync(id);
        }
    }
}
