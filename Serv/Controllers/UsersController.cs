using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serv.Data.Context;
using Serv.Data.Repo.Base;
using Serv.Models;

namespace Serv.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ContextDB _context;
        private readonly BaseCRUDRepo<User> _table;

        public UsersController(ContextDB context)
        {
            _context = context;
            _table = new BaseCRUDRepo<User>(_context);
        }

        [HttpGet(Name ="Users")]
        public List<User>? GetAll()
        {
            var result = _table.GetAll();
            return result;
        }

        [HttpPost]
        public Guid Add([FromBody] User user)
        {
            user.ID = Guid.Empty;
            return _table.Add(user);
        }

        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            return _table.Delete(id);
        }

        [HttpPut]
        public bool Update([FromBody] User user)
        {
            if (user == null)
                return false;
            return _table.Update(user);
        }
    }
}
