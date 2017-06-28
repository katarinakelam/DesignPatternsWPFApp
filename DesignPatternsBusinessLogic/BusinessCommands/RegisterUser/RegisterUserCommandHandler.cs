using DesignPatternsDAL.UowDesignPatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using DesignPatternsBusinessLogic.AutoMapper.Profiles;
using DesignPatternsBusinessLogic.DataTransferObjects;

namespace DesignPatternsBusinessLogic.BusinessCommands.RegisterUser
{
    class RegisterUserCommandHandler : ICommand<RegisterUserCommand>
    {
        private UnitOfWork _unitOfWork;
        
        public RegisterUserCommandHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Handle(RegisterUserCommand command)
        {
            User newUser = new User
            {
                Username = command.User.Username,
                Password = command.User.Password,
                RoleId = command.User.RoleId,
                Salt = command.User.Salt
            };

            if (!new EmailAddressAttribute().IsValid(newUser.Username))
            {
                throw new Exception("E-mail format nije valjan");
            }

            _unitOfWork.UserRepository.Insert(newUser);
            _unitOfWork.SaveChanges();
            // throw new NotImplementedException();
        }
    }
}
