using Core.Entites;
using Core.Interfaces;
using Core.Specification;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<T>> AllListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        } 

        public async Task<T> GetByIdAsync(int id)
        {
                return await _context.Set<T>().FindAsync(id);
            
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> specificaton)
        {
             return await ApplySpecification(specificaton).AsQueryable().FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetListWithSpecAsync(ISpecification<T> specificaton)
        {
            return await ApplySpecification(specificaton).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specificaton)
        {
            return SpecificatonEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(),specificaton);
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }
    }
}
