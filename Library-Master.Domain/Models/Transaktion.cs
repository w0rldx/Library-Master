using System;

namespace Library_Master.Core.Models
{
    public class Transaktion : DefaultObject
    {
        public DateTime EntliehenAm { get; set; }
        public DateTime AbgabeAm { get; set; }
        public virtual Book Book { get; set; }
    }
}