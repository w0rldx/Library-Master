using System;
using System.Diagnostics;
using Library_Master.Desktop.Enums;

namespace Library_Master.Desktop.Entities
{
    public class Book
    {
        private TypeOfMedium _medium;
        public int BookId { get; set; }

        public string Medium
        {
            get => _medium.ToString();
            set => _medium = SelectMedium(value);
        }

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

        public string StrPreis
        {
            set => Preis = ConvertPreis(value);
        }

        public string Informationen { get; set; }
        public string Nummer { get; set; }
        public string AutorKuerzel { get; set; }
        public string Autor { get; set; }

        public string StrAntolin
        {
            set => Antolin = SetAntolinStatus(value);
        }

        public bool Antolin { get; set; }
        public string Bezugsquelle { get; set; }
        public string Isbn { get; set; }
        public string ErscheinungsJahr { get; set; }
        public virtual QrCode QrCode { get; set; }
        public DateTime ZuletztEntliehen { get; set; }
        public string ZuletztEntliehenVon { get; set; }

        public Book()
        {
            QrCode = new QrCode(Titel, AutorKuerzel, Isbn, Besonderheit);
        }

        public virtual TypeOfMedium SelectMedium(string medium)
        {
            switch (medium)
            {
                case "CD":
                    return TypeOfMedium.Cd;

                case "DVD":
                    return TypeOfMedium.Dvd;

                case "Hörbuch":
                    return TypeOfMedium.Hoerbuch;

                case "HöBu":
                    return TypeOfMedium.Hoerbuch;

                case "Spiele":
                    return TypeOfMedium.Spiel;

                case "Video":
                    return TypeOfMedium.Video;

                case "Buch":
                    return TypeOfMedium.Buch;

                default:
                    return TypeOfMedium.Unknown;
            }
        }

        private double ConvertPreis(string betrag)
        {
            try
            {
                betrag = betrag.Replace("€", "").Replace("?", "").Replace(" ", string.Empty);
                if (betrag.Contains("DM"))
                {
                    betrag = betrag.Replace("DM", "");
                    return Convert.ToDouble(betrag) / 2;
                }

                if (betrag != string.Empty) return Convert.ToDouble(betrag);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Fehler bei BetragUmwandlung!");
                Debug.WriteLine(Titel);
            }

            return 0;
        }

        public string CreateQrCodeText()
        {
            return $"{Titel}, {Autor}, {AutorKuerzel}, {Isbn}, {Besonderheit}";
        }

        private bool SetAntolinStatus(string antolin)
        {
            if (antolin == "Antolin Buch" || antolin == "ja" || antolin == "Ja")
                return true;
            return false;
        }

        public string ReturnCsvString()
        {
            return
                $"{Medium};{Klasse};{Fach};{Kategorie};{Nummer};{Sparte};{AutorKuerzel};" +
                $"{Autor};{Titel};{Verlag};{Preis};{ErscheinungsJahr};{Antolin};" +
                $"{Bezugsquelle};{Isbn};{Informationen};{Besonderheit};{HinzufuegeDatum};" +
                $"{QrCode};{Entliehen};{ZuletztEntliehen};{ZuletztEntliehenVon}";
        }
    }
}