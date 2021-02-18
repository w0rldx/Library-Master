using System;
using System.Threading.Tasks;
using Library_Master.Core.Exceptions;
using Library_Master.Core.Models;
using Library_Master.Core.Services.TransactionServices;

namespace Library_Master.Core.Services
{
    public class BorrowService : IBorrowService
    {
        private readonly IDataService<Account> _accountService;
        private readonly IDataService<Book> _bookService;

        public BorrowService(IDataService<Account> accountService, IDataService<Book> bookService)
        {
            _accountService = accountService;
            _bookService = bookService;
        }

        public async Task<Account> BorrowBook(Account lender, Book book)
        {
            try
            {
                var borrowBook = await _bookService.Get(book.Id);
                var lenderAcc = await _accountService.Get(lender.Id);

                if (borrowBook != null || lenderAcc != null)
                {
                    if (borrowBook.Entliehen != true)
                    {
                        lender.Transaktionen.Add(new Transaktion()
                        {
                            EntliehenAm = DateTime.Now,
                            Book = book
                        });
                        book.Entliehen = true;
                    }
                    else
                    {
                        throw new AlreadyBorrowedException();
                    }
                }
                else
                {
                    throw new NullReferenceException();
                }

                await _bookService.Update(book.Id, book);
                await _accountService.Update(lender.Id, lender);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return lender;
        }
    }
}