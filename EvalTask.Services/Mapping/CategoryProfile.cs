using AutoMapper;
using EvalTask.Domain.Entities;
using EvalTask.Dto.Categories;

namespace EvalTask.Services.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}