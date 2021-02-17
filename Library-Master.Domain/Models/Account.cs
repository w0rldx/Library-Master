using System.Collections.Generic;

namespace Library_Master.Core.Models
{
    public class Account : DefaultObject
    {
        public ICollection<Transaktion> Transaktionen { get; set; } = new List<Transaktion>();
        public User AccountHolder { get; set; }
    }
}