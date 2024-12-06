using Dapper;
using InsuranceAPI.Domain.Interfaces;
using InsuranceAPI.Domain.Models;
using InsuranceAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAPI.Infrastructure.Repositories
{
    public class InsuredRepository : IInsuredRepository
    {
        private readonly AppDbContext _context;

        public InsuredRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Insured?> GetByIdAsync(int id)
        {
            return await _context.Insureds
                .Include(i => i.InsuranceProducts)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Insured>> GetAllAsync()
        {
            return await _context.Insureds
                .Include(i => i.InsuranceProducts)
                .ToListAsync();
        }

        public async Task AddAsync(Insured insured)
        {
            _context.Insureds.Add(insured);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Insured insured)
        {
            _context.Insureds.Update(insured);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var insured = await _context.Insureds.FindAsync(id);
            if (insured != null)
            {
                _context.Insureds.Remove(insured);
                await _context.SaveChangesAsync();
            }
        }
    }
}
