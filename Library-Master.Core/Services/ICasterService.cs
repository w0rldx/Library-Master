using System.Threading.Tasks;

namespace Library_Master.Core.Services
{
    public interface ICasterService<T>
    {
        Task<T> CastTo();
        Task<T> CastTo(string str);
    }
}