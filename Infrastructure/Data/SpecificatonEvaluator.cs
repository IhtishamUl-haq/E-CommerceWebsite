using Core.Entites;
using Core.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SpecificatonEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery( IQueryable<TEntity> inputQuery, ISpecification<TEntity> specificaton)
        {
            var query = inputQuery;
            if(specificaton.Criteria != null)
            {
                query=query.Where(specificaton.Criteria);
            }
            if (specificaton.OrderBy != null)
            {
                query = query.OrderBy(specificaton.OrderBy);
            }
            if (specificaton.OrderByDescending != null)
            {
                query = query.OrderBy(specificaton.OrderByDescending);
            }

            if (specificaton.IsPagingEnabled)
            {
                query = query.Skip(specificaton.Skip).Take(specificaton.Take);
            }

            query = specificaton.Includes.Aggregate(query,(current,includes)=>current.Include(includes));
            return query;

        }
    }
}
