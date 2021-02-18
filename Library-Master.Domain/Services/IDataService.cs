using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library_Master.Core.Services
{
    public interface IDataService<T>
    {
        Task<ICollection<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Update(int id, T t);
        Task<T> Create(T t);
        Task<bool> Delete(int id);
    }
}