using Serv.Models.Base;

namespace Serv.Models
{
    public class User: NameId
    {
        public string Email { get; set; }
        public User()
        {
            Email = "";
        }
    }
}
