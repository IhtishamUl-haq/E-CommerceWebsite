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
        public static IQueryable<TEntity> GetQuery( IQueryable<TEntity> inputQuery, ISpecificaton<TEntity> spac)
        {
            var query = inputQuery;
            if(spac.Criteria != null)
            {
                query=query.Where(spac.Criteria);
            }

            query=spac.Includes.Aggregate(query,(current,includes)=>current.Include(includes));
            return query;

        }
    }
}
