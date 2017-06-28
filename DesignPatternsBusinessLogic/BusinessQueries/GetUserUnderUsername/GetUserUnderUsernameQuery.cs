using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsBusinessLogic.BusinessModel;
using DesignPatternsBusinessLogic.BusinessQueries;

namespace DesignPatternsBusinessLogic.BusinessQueries.GetUserUnderUsername
{
    public class GetUserUnderUsernameQuery : IQuery<User>
    {
        public User User { get; set; }

    }
}
