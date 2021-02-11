using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Library_Master.Core.Models
{
    public class Book : DefaultObject
    { 
        [JsonIgnore] public TypeOfMedium Medium { get; set; }

        [JsonPropertyName("Medium")]
        public string StrMedium
        {
            get => Medium.ToString();
            set => Medium = SelectMedium(value);
        }

        public string Titel { get; set; }
        public string Fach { get; set; }
        public string Verlag { get; set; }
        public string Besonderheit { get; set; }
        [JsonIgnore] public bool Entliehen { get; set; }
        [JsonIgnore] public DateTime HinzufuegeDatum { get; set; }
        public string Sparte { get; set; }
        public string Klasse { get; set; }
        public string Kategorie { get; set; }
        [JsonIgnore] public double Preis { get; set; }

        [JsonPropertyName("Preis")]
        public string StrPreis
        {
            set => Preis = ConvertPreis(value);
            get => Preis.ToString();
        }

        public string Informationen { get; set; }
        public string Nummer { get; set; }
        public string AutorKuerzel { get; set; }
        public string Autor { get; set; }

        public string StrAntolin
        {
            set => Antolin = SetAntolinStatus(value);
            get
            {
                if (Antolin)
                {
                    return "Antolin Buch";
                }
                else
                {
                    return "";
                }
            }
        }
        [JsonIgnore] public bool Antolin { get; set; }
        public string Bezugsquelle { get; set; }
        public string Isbn { get; set; }
        public string ErscheinungsJahr { get; set; }
        [JsonIgnore] public virtual QrCode QrCode { get; set; }
        [JsonIgnore] public DateTime ZuletztEntliehen { get; set; }
        [JsonIgnore] public Account ZuletztEntliehenVon { get; set; }
        [JsonIgnore] public IEnumerable<Transaktion> Transaktionen { get; set; }

        private TypeOfMedium SelectMedium(string medium)
        {
            switch (medium)
            {
                case "CD":
                    return TypeOfMedium.CD;

                case "DVD":
                    return TypeOfMedium.DVD;

                case "Hörbuch":
                    return TypeOfMedium.Hoerbuch;  
                
                case "Hoerbuch":
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

        private bool SetAntolinStatus(string antolin)
        {
            if (antolin == "Antolin Buch" || antolin == "ja" || antolin == "Ja")
                return true;
            return false;
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

        public void GenerateQrCode()
        {
            QrCode = new QrCode(Titel, Verlag, Autor, Isbn, Informationen);
        }

        public string ReturnCsvString()
        {
            string output = $"{StrMedium};{Klasse};{Fach};{Kategorie};{Nummer};{Sparte};{AutorKuerzel};" +
                            $"{Autor};{Titel};{Verlag};{StrPreis};{ErscheinungsJahr};{StrAntolin};" +
                            $"{Bezugsquelle};{Isbn};{Informationen};{Besonderheit};";
            return output;
        }
    }
}