using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STS_AU_NewGen_Siemens
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public object RoleId { get; set; }
    }

    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}
