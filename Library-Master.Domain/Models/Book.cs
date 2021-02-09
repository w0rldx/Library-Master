using System;
using System.Collections.Generic;

namespace Library_Master.Core.Models
{
    public class Book : DefaultObject
    {
        private TypeOfMedium _medium;
        
        public string Medium { get; set; }
        public string Titel { get; set; }
        public string Fach { get; set; }
        public string Verlag { get; set; }
        public string Besonderheit { get; set; }
        public bool Entliehen { get; set; }
        public DateTime HinzufuegeDatum { get; set; }
        public string Sparte { get; set; }
        public string Klasse { get; set; }
        public string Kategorie { get; set; }
        public double Preis { get; set; }
        public string StrPreis { get; set; }
        public string Informationen { get; set; }
        public string Nummer { get; set; }
        public string AutorKuerzel { get; set; }
        public string Autor { get; set; }
        public string StrAntolin { get; set; }
        public bool Antolin { get; set; }
        public string Bezugsquelle { get; set; }
        public string Isbn { get; set; }
        public string ErscheinungsJahr { get; set; }
        public virtual QrCode QrCode { get; set; }
        public DateTime ZuletztEntliehen { get; set; }
        public Account ZuletztEntliehenVon { get; set; }
        public IEnumerable<Transaktion> Transaktionen { get; set; }
    }
}