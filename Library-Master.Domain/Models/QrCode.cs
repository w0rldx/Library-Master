namespace Library_Master.Core.Models
{
    public class QrCode : DefaultObject
    {
        private string titel;
        private string verlag;
        private string author;
        private string isbn;
        private string info;

        public string Titel
        {
            get => titel;
            private set => titel = value;
        }

        public string Verlag
        {
            get => verlag;
            private set => verlag = value;
        }

        public string Author
        {
            get => author;
            private set => author = value;
        }

        public string Isbn
        {
            get => isbn;
            private set => isbn = value;
        }

        public string Info
        {
            get => info;
            private set => info = value;
        }

        public string QrCodeString { get => GenerateQrCodeAsText(); }

        public QrCode(string titel, string verlag, string author, string isbn, string info)
        {
            Titel = titel;
            Verlag = verlag;
            Author = author;
            Isbn = isbn;
            Info = info;
        }

        private string GenerateQrCodeAsText() => "";
    }
}