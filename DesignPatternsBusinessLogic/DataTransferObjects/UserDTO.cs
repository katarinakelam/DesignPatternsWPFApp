using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBusinessLogic.DataTransferObjects
{
    public class UserDTO
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public string Salt { get; set; }

    }
}
