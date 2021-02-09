using System;

namespace Library_Master.Core.Models
{
    public class Transaktion : DefaultObject
    {
        public DateTime EntliehenAm { get; set; }
        public Account EntliehenVon { get; set; }
        public DateTime AbgabeAm { get; set; }
        public Book Book { get; set; }
    }
}