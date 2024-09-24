
namespace Demo_project.Domain.Interfaces
{
    public interface IDataRepository<T, T1>
    {
        T1 GetAll();
        T GetById(string id);
        void Add(T data);
        void Update(T data);
        void Delete(string id);
    }
}
