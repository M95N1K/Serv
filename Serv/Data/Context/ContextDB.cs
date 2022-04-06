using Microsoft.EntityFrameworkCore;
using Serv.Models;

namespace Serv.Data.Context
{
    public class ContextDB: DbContext
    {
        private readonly TypeDB _type;
        private readonly string _conectionString;

        public ContextDB():this(TypeDB.Memory,"Memory")
        {}
        public ContextDB(TypeDB type, string conectionString)
        {
            _type = type;
            _conectionString = conectionString;
            if(this.Database.EnsureCreated())
            {
                this.Users.Add(new User() { Name = "Igor", Email = "sss@fff.ccc" });
                this.SaveChanges();
            }
        }

        public DbSet<User>? Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            switch (_type)
            {
                case TypeDB.Memory:
                    optionsBuilder.UseInMemoryDatabase(_conectionString);
                    break;
                case TypeDB.SQL:
                    optionsBuilder.UseSqlServer(_conectionString);
                    break;
                case TypeDB.SQLite:
                    optionsBuilder.UseSqlite(_conectionString);
                    break;
                default:
                    optionsBuilder.UseInMemoryDatabase(_conectionString);
                    break;
            }
        }
    }
}
