using System;
using System.Threading.Tasks;
using Library_Master.Core.Models;
using Library_Master.Core.Services;

namespace Library_Master.Core.Caster
{
    public class BookCaster : ICasterService<Book>
    {
        public Task<Book> CastTo()
        {
            return null;
        }
        
        /// <summary>
        /// Cast a string to a Book object
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public async Task<Book> CastTo(string str)
        {
            var csvEntries = str.Split(';');
            Book book = new Book
            {
                StrMedium = csvEntries[0], Klasse = csvEntries[1], Fach = csvEntries[2], Kategorie = csvEntries[3],
                Nummer = csvEntries[4], Sparte = csvEntries[5], AutorKuerzel = csvEntries[6], Autor = csvEntries[7],
                Titel = csvEntries[8], Verlag = csvEntries[9],
                StrPreis = csvEntries[10], ErscheinungsJahr = csvEntries[11], StrAntolin = csvEntries[12],
                Bezugsquelle = csvEntries[13], Isbn = csvEntries[14],
                Informationen = csvEntries[15], Besonderheit = csvEntries[16], HinzufuegeDatum = DateTime.Now
            };
            book.GenerateQrCode();
            return book;
        }
        
        /// <summary>
        /// Cast a Book to a Book object
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public async Task<Book> CastTo(Book b)
        {
            Book book = new Book
            {
                StrMedium = b.StrMedium, Klasse = b.Klasse, Fach = b.Fach, Kategorie = b.Kategorie,
                Nummer = b.Nummer, Sparte = b.Sparte, AutorKuerzel = b.AutorKuerzel, Autor = b.Autor,
                Titel = b.Titel, Verlag = b.Verlag, StrPreis = b.StrPreis, 
                ErscheinungsJahr = b.ErscheinungsJahr, StrAntolin = b.StrAntolin, Bezugsquelle = b.Bezugsquelle, 
                Isbn = b.Isbn, Informationen = b.Informationen, Besonderheit = b.Besonderheit, 
                HinzufuegeDatum = DateTime.Now
            };
            book.GenerateQrCode();
            return book;
        }
    }
}