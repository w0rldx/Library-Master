using System.Collections.Generic;

namespace Library_Master.Core.Models
{
    public class Account : DefaultObject
    {
        public virtual ICollection<Transaktion> Transaktionen { get; set; } = new List<Transaktion>();
        public virtual User AccountHolder { get; set; }
    }
}