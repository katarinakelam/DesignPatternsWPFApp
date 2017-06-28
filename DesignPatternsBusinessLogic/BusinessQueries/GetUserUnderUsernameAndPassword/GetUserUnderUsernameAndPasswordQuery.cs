using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsBusinessLogic.BusinessModel;
using DesignPatternsBusinessLogic.BusinessQueries;

namespace DesignPatternsBusinessLogic.BusinessQueries.GetUserUnderUsernameAndPassword
{
    class GetUserUnderUsernameAndPasswordQuery : IQuery<User>
    {
        public User User { get; set; }

    }
}
