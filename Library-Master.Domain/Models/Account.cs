using System.Collections.Generic;

namespace Library_Master.Core.Models
{
    public class Account : DefaultObject
    {
        public IEnumerable<Transaktion> Transaktionen { get; set; }
        public User AccountHolder { get; set; }
    }
}