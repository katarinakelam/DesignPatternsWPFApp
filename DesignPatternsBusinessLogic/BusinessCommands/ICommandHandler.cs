using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBusinessLogic.BusinessCommands
{
    public interface ICommand<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
