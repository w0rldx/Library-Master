using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Master.Core.Services;
using Library_Master.EntityFramework;
using Library_Master.EntityFramework.Services;
using Microsoft.EntityFrameworkCore;

namespace Library_Master.Core.Exporter.Book
{
    public class CsvExporter : IExporterService
    {
        private readonly Library_MasterDbContextFactory _contextFactory;

        public CsvExporter(Library_MasterDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<bool> Export(string exportfile)
        {
            Console.WriteLine(exportfile);
            IDataService<Models.Book> bookService =
                new GenericDataService<Models.Book>(_contextFactory);
            StringBuilder sbOutput = new StringBuilder();

            IEnumerable<Models.Book> list = await bookService.GetAll();
            try
            {
                foreach (var book in list)
                {
                    sbOutput.AppendLine(book.ReturnCsvString());
                }
                await File.WriteAllTextAsync(exportfile, sbOutput.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }
    }
}