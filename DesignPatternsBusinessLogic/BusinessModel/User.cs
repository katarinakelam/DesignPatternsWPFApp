using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBusinessLogic.BusinessModel
{
    public class User
    {
        public string Username { get; set; }

        public string Password { get; set; }

        //defaultna vrijednost - defaultna rola je 1 - "guest"
        public int RoleId { get; set; } = 1;

        public string Salt { get; set; } 

    }
}
