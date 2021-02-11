using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using Library_Master.Core.Services;
using Library_Master.EntityFramework;
using Library_Master.EntityFramework.Services;

namespace Library_Master.Core.Exporter.Book
{
    public class JsonExporter : IExporterService
    {
        private readonly Library_MasterDbContextFactory _contextFactory;

        public JsonExporter(Library_MasterDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<bool> Export(string exportfile)
        {
            Console.WriteLine(exportfile);
            IDataService<Models.Book> bookService =
                new GenericDataService<Models.Book>(_contextFactory);
            
            IEnumerable<Models.Book> list = await bookService.GetAll();
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All, UnicodeRanges.All)
                };
                
                using FileStream createStream = File.Create(exportfile);
                await JsonSerializer.SerializeAsync(createStream, list, options);
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