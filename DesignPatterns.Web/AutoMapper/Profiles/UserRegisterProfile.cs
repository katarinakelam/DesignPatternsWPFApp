using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsWeb.AutoMapper.Profiles;
using DesignPatternsBusinessLogic.BusinessModel;
using AutoMapper;

using DesignPatternsWeb.AutoMapper.Resolvers;

namespace DesignPatternsWeb.AutoMapper.Profiles
{
    public class UserRegisterProfile : Profile
    {
        public UserRegisterProfile()
        {
            CreateMap<ViewModels.User.UserRegister, User>()
                .ForMember(dest => dest.Username,
                            opt => opt.PreCondition(src => src.Username != null))
                .ForMember(dest => dest.Password,
                            opt => opt.PreCondition(src => src.Password != null))
                .ForMember(dest => dest.Password,
                            opt => opt.ResolveUsing<UserRegisterResolver>()); // ako su lozinke iste
        }
    }
}
