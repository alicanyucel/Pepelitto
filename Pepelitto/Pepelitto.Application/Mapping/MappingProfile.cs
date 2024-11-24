using AutoMapper;
using Pepelitto.Application.Features.User.Createuser;
using Pepelitto.Application.Features.User.UpdateUsers;
using Pepelitto.Domain.Entities;

namespace Pepelitto.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, AppUser>().ReverseMap();
            CreateMap<UpdateUserCommand, AppUser>().ReverseMap();

        }
    }
}
