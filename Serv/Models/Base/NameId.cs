namespace Serv.Models.Base
{
    public class NameId: GuidID
    {
        public string Name { get; set; }

        public NameId()
        {
            Name = string.Empty;
        }
    }
}
