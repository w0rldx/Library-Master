using System.Windows;
using System.Windows.Data;

namespace Library_Master.Desktop.UI
{
    public partial class TestWindow : Window
    {
        private CollectionViewSource bookViewSource;

        public TestWindow()
        {
            InitializeComponent();
            bookViewSource =
                (CollectionViewSource) FindResource(nameof(bookViewSource));
        }

        private void TestWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            // // this is for demo purposes only, to make it easier
            // // to get up and running
            // _context.Database.EnsureCreated();
            //
            // // load the entities into EF Core
            // _context.Books.Load();
            //
            // // bind to the source
            // bookViewSource.Source =
            //     _context.Books.Local.ToObservableCollection();
        }
    }
}