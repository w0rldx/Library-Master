using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading;
using System.Threading.Tasks;
using Library_Master.Core.Caster;
using Library_Master.Core.Models;
using Library_Master.Core.Services;
using Library_Master.EntityFramework;
using Library_Master.EntityFramework.Services;

namespace Library_Master.Core.BookImporter
{
    public class JsonImporter : IImporterService
    {
        private readonly Library_MasterDbContextFactory _contextFactory;

        public JsonImporter(Library_MasterDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<bool> Import(string filepath)
        {
            IDataService<Book> bookService = new GenericDataService<Book>(_contextFactory);
            BookCaster castingService = new BookCaster();

            if (File.Exists(filepath))
            {
                try
                {
                    using (FileStream openStream = File.OpenRead(filepath))
                    {
                        
                        //TODO:FIX AWAIT
                        // List<Book> a = await JsonSerializer.DeserializeAsync<List<Book>>(openStream);
                        // Console.WriteLine(a);
                        string jsonString = File.ReadAllText(filepath);
                        var list = JsonSerializer.Deserialize<List<Book>>(jsonString);

#if DEBUG
                        var i = 0;
#endif
                        if (list != null)
                        {
                            foreach (var book in list)
                            {
                                await bookService.Create(await castingService.CastTo(book));
#if DEBUG
                                if (i >= 20)
                                    break;
                                i++;
#endif
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }

            return true;
        }
    }
}