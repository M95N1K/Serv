using System.ComponentModel.DataAnnotations;

namespace Serv.Models.Base
{
    public class GuidID
    {
        [Key]
        public Guid ID { get; set; }

        public GuidID()
        {
            ID = Guid.NewGuid();
        }
    }
}
