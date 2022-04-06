namespace Serv.Data.Repo.Interfaces
{
    public interface IRepo<T>
    {
        Guid Add(T entity);

        T GetById(Guid id);

        bool Update(T entity);

        bool Delete(T entity);

        List<T> GetAll();
    }
}
