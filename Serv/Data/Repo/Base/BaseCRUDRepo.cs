using Microsoft.EntityFrameworkCore;
using Serv.Data.Context;
using Serv.Data.Repo.Interfaces;
using Serv.Models.Base;

namespace Serv.Data.Repo.Base
{
    public class BaseCRUDRepo<T> : IDisposable, IRepo<T> where T : GuidID
    {
        protected readonly ContextDB _context;
        protected readonly DbSet<T> _table;

        public BaseCRUDRepo(ContextDB context)
        {
            _context = context;
            _table = _context.Set<T>();

        }
        public Guid Add(T entity)
        {
            _table.Add(entity);
            if (SaveChange())
                return entity.ID;
            else
                return Guid.Empty;
        }

        public bool Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            return SaveChange();
        }

        public bool Delete(Guid id)
        {
            T? entity = _table.Find(id);
            if(entity == null)
                return false;
            return Delete(entity);
        }

        public void Dispose()
        {
            SaveChange();
        }

        public List<T> GetAll()
        {
            return _table.ToList();
        }

        public T? GetById(Guid id)
        {
            return _table.FirstOrDefault(t => t.ID == id);
        }

        public bool Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return SaveChange();
        }

        private bool SaveChange()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
