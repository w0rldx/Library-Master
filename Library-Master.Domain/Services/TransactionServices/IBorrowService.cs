using System.Threading.Tasks;
using Library_Master.Core.Models;

namespace Library_Master.Core.Services.TransactionServices
{
    public interface IBorrowService
    {
        Task<Account> BorrowBook(Account lender, Book book);
    }
}