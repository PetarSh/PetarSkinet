using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core1.Entities;
using core1.Interfaces;
using core1.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Structura.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext contexts;
        public GenericRepository(StoreContext context)
        {
            contexts = context;
        }

        public void Add(T entity)
        {
            contexts.Set<T>().Add(entity);
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public void Delete(T entity)
        {
            contexts.Set<T>().Remove(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await contexts.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await contexts.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            var query = ApplySpecification(spec);

            return await query.ToListAsync();
        }

        public void Update(T entity)
        {
            contexts.Set<T>().Attach(entity);
            contexts.Entry(entity).State = EntityState.Modified;
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(contexts.Set<T>().AsQueryable(), spec);
        }
    }
}