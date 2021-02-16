using System.Threading.Tasks;

namespace Library_Master.Core.Services
{
    public interface IExporterService
    {
        Task<bool> Export(string exportfile);
    }
}