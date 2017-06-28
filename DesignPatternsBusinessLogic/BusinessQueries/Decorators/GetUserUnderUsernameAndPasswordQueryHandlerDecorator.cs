using DesignPatternsBusinessLogic.BusinessModel;
using DesignPatternsBusinessLogic.BusinessQueries.GetUserUnderUsernameAndPassword;
using DesignPatternsBusinessLogic.GetUserUnderUsernameAndPassword;
using DesignPatternsDAL.UowDesignPatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBusinessLogic.BusinessQueries.Decorators
{
        class GetUserUnderUsernameAndPasswordQueryHandlerDecorator : IQuery<GetUserUnderUsernameAndPasswordQuery>
        {
            private UnitOfWork _unitOfWork;
            private GetUserUnderUsernameAndPasswordQueryHandler _handler;
            private string _salt;

            public GetUserUnderUsernameAndPasswordQueryHandlerDecorator(GetUserUnderUsernameAndPasswordQueryHandler handler, string salt)
            {
                _handler = handler;
                _salt = salt;
            }

            public User Handle(GetUserUnderUsernameAndPasswordQuery query)
            {
                User returnUser;


                using (_unitOfWork = new UnitOfWork())
                {
                    query.User.Password = HashPassword.GenerateHash(query.User.Password, _salt);
                    returnUser = _handler.Handle(query);
                }

                return returnUser;
            }
        }
}

