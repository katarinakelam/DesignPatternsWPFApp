using DesignPatternsBusinessLogic.BusinessCommands.RegisterUser;
using DesignPatternsDAL.UowDesignPatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBusinessLogic.BusinessCommands.Decorators
{
    class RegisterUserCommandHandlerDecorator : ICommand<RegisterUserCommand>
    {
        private UnitOfWork _unitOfWork;
        private RegisterUserCommandHandler _handler;
        public RegisterUserCommandHandlerDecorator(RegisterUserCommandHandler handler)
        {
            _handler = handler;
        }

        public void Handle(RegisterUserCommand command)
        {
           // command.User.Salt = HashPassword.GenerateSalt(50);
           // command.User.Password = HashPassword.GenerateHash(command.User.Password, command.User.Salt);
            using (_unitOfWork = new UnitOfWork())
            {
                command.User.Salt = "000000";
                _handler.Handle(command);

            }
        }
    }
}
