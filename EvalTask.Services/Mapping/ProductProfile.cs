using AutoMapper;
using EvalTask.Domain.Entities;
using EvalTask.Dto.Accounts;
using EvalTask.Dto.Products;

namespace EvalTask.Services.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.Creator, src => src.MapFrom(x => x.Creator));
        }
    }
}