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
    public class InsuranceProductRepository : IInsuranceProductRepository
    {
        private readonly AppDbContext _context;

        public InsuranceProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<InsuranceProduct?> GetByIdAsync(int id)
        {
            return await _context.InsuranceProducts
                .Include(p => p.Insured)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<InsuranceProduct>> GetAllAsync()
        {
            using var connection = _context.GetDbConnection();
            const string query = "SELECT * FROM InsuranceProduct";
            return await connection.QueryAsync<InsuranceProduct>(query);
        }

        public async Task AddAsync(InsuranceProduct product)
        {
            _context.InsuranceProducts.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(InsuranceProduct product)
        {
            _context.InsuranceProducts.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.InsuranceProducts.FindAsync(id);
            if (product != null)
            {
                _context.InsuranceProducts.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

    }
}
