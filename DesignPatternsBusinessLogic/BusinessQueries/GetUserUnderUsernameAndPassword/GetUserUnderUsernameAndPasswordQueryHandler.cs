using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsBusinessLogic.BusinessModel;
using DesignPatternsDAL.UowDesignPatterns;
using AutoMapper;
using System.Data.Entity;
using DesignPatternsBusinessLogic.AutoMapper.Profiles;
using DesignPatternsBusinessLogic.DataTransferObjects;
using System.ComponentModel.DataAnnotations;
using DesignPatternsBusinessLogic.BusinessQueries;
using DesignPatternsBusinessLogic.BusinessQueries.GetUserUnderUsernameAndPassword;

namespace DesignPatternsBusinessLogic.GetUserUnderUsernameAndPassword
{
    class GetUserUnderUsernameAndPasswordQueryHandler : IQueryHandler<GetUserUnderUsernameAndPasswordQuery, User>
    {
            private UnitOfWork _unitOfWork;

        public GetUserUnderUsernameAndPasswordQueryHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public User Handle(GetUserUnderUsernameAndPasswordQuery query)
        {
            if (!new EmailAddressAttribute().IsValid(query.User.Username))
            {
                throw new Exception("E-mail format nije valjan");
            }
            else
            {
                UserDTO user = _unitOfWork.UserRepository.Get()
                    .Select(s => new UserDTO
                    {
                        Username = s.Username,
                        Password = s.Password,
                        Salt = s.Salt
                    })
                    .Where(b => b.Username == query.User.Username && b.Password == query.User.Password).FirstOrDefault();

                var config = new MapperConfiguration(cfg =>
                   cfg.AddProfile<UserDTOToUserLoginProfile>()
                );
                var mapper = new Mapper(config);

                User returnUser = mapper.DefaultContext.Mapper.Map<User>(user);

                return returnUser;
            }

        }
    }
}
