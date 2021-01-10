using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Master.Desktop.Entities
{
    public class QrCode
    {
        public int QrCodeId { get; set; }
        public string Titel { get; set; }
        public string Kuerzel { get; set; }
        public string Isbn { get; set; }
        public string Besonderheit { get; set; }
        public string QrCodeString { get; set; }

        public QrCode(string titel, string kuerzel, string isbn, string besonderheit)
        {
            Titel = titel;
            Kuerzel = kuerzel;
            Isbn = isbn;
            Besonderheit = besonderheit;
            QrCodeString = CreateQrCodeText();
        }

        public string CreateQrCodeText()
        {
            return $"{Titel}, {Kuerzel}, {Isbn}, {Besonderheit}";
        }
    }
}