using DesignPatternsBusinessLogic.GetSaltUnderUsername;
using DesignPatternsBusinessLogic.DataTransferObjects;
using DesignPatternsDAL.UowDesignPatterns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBusinessLogic.BusinessQueries.GetSaltUnderUsername
{
    class GetSaltUnderUsernameQueryHandler : IQueryHandler<GetSaltUnderUsernameQuery, string>
    {
        private UnitOfWork _unitOfWork;

        public GetSaltUnderUsernameQueryHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public string Handle(GetSaltUnderUsernameQuery query)
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
                        Salt = s.Salt
                    })
                    .Where(b => b.Username == query.User.Username).FirstOrDefault();

                return user.Salt;
            }
        }
    }
}
