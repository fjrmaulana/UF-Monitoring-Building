using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I_HUB.Maintenance
{
    public class Post_User_Params
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public List<string> UserRolesId { get; set; }
        public bool Active { get; set; }
        public string UserCreated { get; set; }
        public string UserUpdated { get; set; }
        public string Token { get; set; }
        public string entry { get; set; }
        public string org { get; set; }
        public Post_User_Params()
        {

        }
    }
}
