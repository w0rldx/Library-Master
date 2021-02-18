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

        public ReturnService(IDataService<Account> accountService, IDataService<Book> bookService)
        {
            _accountService = accountService;
            _bookService = bookService;
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
                        var last = lenderAcc.Transaktionen.First();
                        if (last != null)
                        {
                            lender.Transaktionen.Remove(last);
                            last.AbgabeAm = DateTime.Now;
                            lender.Transaktionen.Add(last);
                        }

                        book.Entliehen = false;
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
            await _accountService.Update(lender.Id, lender);

            return lender;
        }
    }
}