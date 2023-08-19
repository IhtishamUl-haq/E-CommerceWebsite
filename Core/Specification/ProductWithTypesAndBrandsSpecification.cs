using Core.Entites;
 

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
