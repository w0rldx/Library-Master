using System;
using System.Linq;
using System.Threading.Tasks;
using Library_Master.Core.Exceptions;
using Library_Master.Core.Models;
using Library_Master.Core.Services.TransactionServices;

namespace Library_Master.Core.Services
{
    public class ReturnService : IReturnService
    {
        private readonly IDataService<Account> _accountService;
        private readonly IDataService<Book> _bookService;
        private readonly IDataService<Transaktion> _transactionService;

        public ReturnService(IDataService<Account> accountService, IDataService<Book> bookService, IDataService<Transaktion> transactionService)
        {
            _accountService = accountService;
            _bookService = bookService;
            _transactionService = transactionService;
        }

        public async Task<Account> ReturnBook(Account lender, Book book)
        {
            var borrowBook = await _bookService.Get(book.Id);
            var lenderAcc = await _accountService.Get(lender.Id);
            try
            {
                if (borrowBook != null || lenderAcc != null)
                {
                    if (borrowBook.Entliehen != false)
                    {
                        //TODO:Check for last book if that is that last book
                        var last = lenderAcc.Transaktionen.Last();
                        lenderAcc.Transaktionen.Remove(last);
                        last.AbgabeAm = DateTime.Now;
                        book.Entliehen = false;
                        lenderAcc.Transaktionen.Add(last);
                    }
                    else
                    {
                        throw new NotBorrowedException();
                    }
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            await _bookService.Update(book.Id, book);
            await _accountService.Update(lender.Id, lenderAcc);

            return lenderAcc;
        }
    }
}