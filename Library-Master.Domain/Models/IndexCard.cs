using System.Collections;

namespace Library_Master.Core.Models
{
    public enum IndexCardType
    {
        Books,
        Students,
        Ausgeliehen,
    }

    public class IndexCard
    {
        public int Anzahl { get; set; }
        public IndexCardType Type { get; set; }

        public IndexCard(int anzahl, IndexCardType type)
        {
            Anzahl = anzahl;
            Type = type;
        }
    }
}