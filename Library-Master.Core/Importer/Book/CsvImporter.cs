using System;
using System.IO;
using System.Threading.Tasks;
using Library_Master.Core.Caster;
using Library_Master.Core.Models;
using Library_Master.Core.Services;
using Library_Master.EntityFramework;
using Library_Master.EntityFramework.Services;

namespace Library_Master.Core.BookImporter
{
    public class CsvImporter : IImporterService
    {
        private readonly Library_MasterDbContextFactory _contextFactory;

        public CsvImporter(Library_MasterDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<bool> Import(string filepath)
        {
            IDataService<Book> bookService = new GenericDataService<Book>(_contextFactory);
            BookCaster castingService = new BookCaster();

            if (File.Exists(filepath))
            {
                //TODO:FIX AWAIT
                //var bookAsCsvArray = await File.ReadAllLinesAsync(filepath);
                var bookAsCsvArray = File.ReadAllLines(filepath);
                var i = 0;

                foreach (var line in bookAsCsvArray)
                {
                    try
                    {
                        await bookService.Create(await castingService.CastTo(line));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        //throw;
                    }
#if DEBUG
                    if (i >= 20)
                        break;
                    i++;
#endif
                }
            }

            return true;
        }
    }
}