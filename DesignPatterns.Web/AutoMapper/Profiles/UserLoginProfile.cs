using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsWeb.AutoMapper.Profiles;
using DesignPatternsBusinessLogic.BusinessModel;
using AutoMapper;


namespace DesignPatternsWeb.AutoMapper.Profiles
{
    public class UserLoginProfile : Profile
    {
        public UserLoginProfile()
        {
            CreateMap<DesignPatternsWeb.ViewModels.User.UserLogin, User>()
                .ForMember(dest => dest.Username,
                            opt => opt.PreCondition(src => src.Username != null))
                .ForMember(dest => dest.Password,
                            opt => opt.PreCondition(src => src.Password != null));

        }
    }
}