using System;
using System.ComponentModel;
using Library_Master.Desktop.Entities;

namespace Library_Master.Desktop.Importer
{
    public abstract class Importer
    {
        protected string file;
        
        protected Importer(string file)
        {
            this.file = file;
        }
        
        public virtual Book CastToBookObject(string csvString)
        {
            //TODO:FIX CREATION
            var csvEntries = csvString.Split(';');
            var book = new Book
            {
                Medium = csvEntries[0], Klasse = csvEntries[1], Fach = csvEntries[2], Kategorie = csvEntries[3],
                Nummer = csvEntries[4], Sparte = csvEntries[5], AutorKuerzel = csvEntries[6], Autor = csvEntries[7],
                Titel = csvEntries[8], Verlag = csvEntries[9],
                StrPreis = csvEntries[10], ErscheinungsJahr = csvEntries[11], StrAntolin = csvEntries[12],
                Bezugsquelle = csvEntries[13], Isbn = csvEntries[14],
                Informationen = csvEntries[15], Besonderheit = csvEntries[16], HinzufuegeDatum = DateTime.Now
            };
            book.GenerateQrCode();
            return book;
        }
    }
}