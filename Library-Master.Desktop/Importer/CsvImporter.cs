using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using Library_Master.Desktop.EF;
using Microsoft.Win32;

namespace Library_Master.Desktop.Importer
{
    public class CsvImporter : Importer
    {
        public CsvImporter(string file) : base(file)
        {
            Importing(file);
        }

        public void Importing(string file)
        {
            if (!string.IsNullOrEmpty(file))
            {
                using (var db = new LibraryContext())
                {
                    var bookAsCsvArray = File.ReadAllLines(file);
                    var i = 0;
                    foreach (var line in bookAsCsvArray)
                    {
                        try
                        {
                            db.Books.Add(CastToBookObject(line));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            //throw;
                        }
#if DEBUG
                        if (i >= 100)
                            break;
                        i++;
#endif
                    }
                    db.SaveChanges();
                    MessageBox.Show("Successfully");
                }
            }
        }
    }
}