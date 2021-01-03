using AutoMapper;
using EvalTask.Domain.Entities;
using EvalTask.Dto.Accounts;

namespace EvalTask.Services.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}