using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DesignPatternsBusinessLogic.BusinessModel;
using DesignPatternsWeb.ViewModels;

namespace DesignPatternsWeb.AutoMapper.Resolvers
{
    public class UserRegisterResolver : IValueResolver<ViewModels.User.UserRegister, User, string>
    {
        public string Resolve(ViewModels.User.UserRegister source, User destination, string destMember, ResolutionContext context)
        {
            string password = source.Password;
            string repeatedPassword = source.PasswordRepeated;

            if (password == repeatedPassword)
            {
                destination.RoleId = 1;
                return password;
            }
            else
            {
                throw new Exception("Passwords are not matching");
            }
        }
    }
}
