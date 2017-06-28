using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DesignPatternsBusinessLogic.BusinessModel;
using DesignPatternsBusinessLogic.DataTransferObjects;

namespace DesignPatternsBusinessLogic.AutoMapper.Profiles
{
    public class UserDTOToUserLoginProfile : Profile
    {
        public UserDTOToUserLoginProfile()
        {
            CreateMap<UserDTO, User>()
               .ForMember(dest => dest.Username,
                           opt => opt.PreCondition(src => src.Username != null))
               .ForMember(dest => dest.Password,
                           opt => opt.PreCondition(src => src.Password != null));

        }
    }
}
