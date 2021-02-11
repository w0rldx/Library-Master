using System.IO;
using System.Threading.Tasks;

namespace Library_Master.Core.Services
{
    public interface IImporterService
    {
        Task<bool> Import(string filepath);
    }
}