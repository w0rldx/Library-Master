using System.Threading.Tasks;
using Library_Master.Core.Models;

namespace Library_Master.Core.Services.TransactionServices
{
    public interface IReturnService
    {
        Task<Account> ReturnBook(Account lender, Book book);
    }
}