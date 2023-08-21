using Core.Entites;
using Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity

    {
        Task<T> GetByIdAsync (int id);

        Task<IReadOnlyList<T>> AllListAsync ();

        Task<T> GetEntityWithSpec(ISpecification<T> specificaton);

        Task<IReadOnlyList<T>> GetListWithSpecAsync(ISpecification<T> specificaton);

        Task<int> CountAsync(ISpecification<T> spec);
    }
}
