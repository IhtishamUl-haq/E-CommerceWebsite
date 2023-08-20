using API.DTO;
using AutoMapper;
using Core.Entites;

namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductReturnDto>()
                .ForMember(d => d.productType, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}
