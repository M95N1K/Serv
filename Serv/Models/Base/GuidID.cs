namespace Serv.Models.Base
{
    public class GuidID
    {
        public Guid ID { get; set; }

        public GuidID()
        {
            ID = Guid.NewGuid();
        }
    }
}
