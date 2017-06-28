using DesignPatternsBusinessLogic.BusinessQueries;
using DesignPatternsBusinessLogic.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBusinessLogic.GetSaltUnderUsername
{
    public class GetSaltUnderUsernameQuery : IQuery<string>
    {
        public User User { get; set; }
    }
}
