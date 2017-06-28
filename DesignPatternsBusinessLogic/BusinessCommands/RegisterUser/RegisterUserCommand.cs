using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsBusinessLogic.BusinessModel;

namespace DesignPatternsBusinessLogic.BusinessCommands.RegisterUser
{
    class RegisterUserCommand : ICommand
    {
        public User User { get; set; }

    }
}
