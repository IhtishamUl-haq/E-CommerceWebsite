using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ProductWithTypesAndBrandsSpecification:BaseSpecificaton<Product>
    {
        public ProductWithTypesAndBrandsSpecification()
        {
            AddIndcudes(x => x.productType);
            AddIndcudes(x => x.ProductBrand);
        }

        public ProductWithTypesAndBrandsSpecification(int id) : base(x=>x.Id==id)
        {
            AddIndcudes(x => x.productType);
            AddIndcudes(x => x.ProductBrand);
        }
    }
}
