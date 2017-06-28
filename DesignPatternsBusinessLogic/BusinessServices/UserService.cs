using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsBusinessLogic.BusinessModel;
using DesignPatternsDAL.UowDesignPatterns;
using DesignPatternsBusinessLogic.BusinessCommands.RegisterUser;
using DesignPatternsBusinessLogic.BusinessQueries.GetUserUnderUsername;
using DesignPatternsBusinessLogic.BusinessQueries.GetUserUnderUsernameAndPassword;
using DesignPatternsBusinessLogic.BusinessQueries.GetSaltUnderUsername;
using DesignPatternsBusinessLogic.BusinessCommands.Decorators;
using DesignPatternsBusinessLogic.BusinessQueries.Decorators;
using DesignPatternsBusinessLogic.GetSaltUnderUsername;
using DesignPatternsBusinessLogic.GetUserUnderUsernameAndPassword;

namespace DesignPatternsBusinessLogic.BusinessServices
{
    public class UserService
    {
        public void RegisterUser(User user)
        {
            UnitOfWork uow;
            User returnUser;

            GetUserUnderUsernameQuery query = new GetUserUnderUsernameQuery { User = user };

            using (uow = new UnitOfWork())
            {
                GetUserUnderUsernameQueryHandler getUserUnderUsernameHandler = new GetUserUnderUsernameQueryHandler(uow);
                returnUser = getUserUnderUsernameHandler.Handle(query);
            }

            RegisterUserCommandHandler handler;
            using (uow = new UnitOfWork())
            {
                handler = new RegisterUserCommandHandler(uow);


                if (returnUser == null)
                {
                    RegisterUserCommand command = new RegisterUserCommand { User = user };
                    RegisterUserCommandHandlerDecorator decorator = new RegisterUserCommandHandlerDecorator(handler);
                    decorator.Handle(command);
                }
                else
                {
                    throw new Exception("Korisnik pod tim imenom već postoji");

                }
            }
        }

        public string LoginUser(User user)
        {
            UnitOfWork uow;
            User returnUser;

            GetSaltUnderUsernameQuery saltQuery = new GetSaltUnderUsernameQuery { User = user };
            GetUserUnderUsernameAndPasswordQuery query = new GetUserUnderUsernameAndPasswordQuery { User = user };

            GetSaltUnderUsernameQueryHandler saltHandler;
            GetUserUnderUsernameAndPasswordQueryHandler handler;
            using (uow = new UnitOfWork())
            {
                saltHandler = new GetSaltUnderUsernameQueryHandler(uow);

                string salt = saltHandler.Handle(saltQuery);

                handler = new GetUserUnderUsernameAndPasswordQueryHandler(uow);

                GetUserUnderUsernameAndPasswordQueryHandlerDecorator decorator = new GetUserUnderUsernameAndPasswordQueryHandlerDecorator(handler, salt);
                returnUser = decorator.Handle(query);
                //bool

                if (returnUser != null)
                {
                    return "OK";
                }
                else
                {
                    return "Korisničko ime ili lozinka je kriva";
                }
            }
        }
    }
}
