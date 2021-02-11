using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Library_Master.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Master.Desktop.UI
{
    public partial class Dataview : Window
    {
        private CollectionViewSource _bookViewSource;

        public Dataview()
        {
            InitializeComponent();
            _bookViewSource =
                (CollectionViewSource) FindResource(nameof(_bookViewSource));
        }

        private void Dataview_OnLoaded(object sender, RoutedEventArgs e)
        {
            //var objects = _context.BookList.ToList();
            //var objects2 = _context.LibraryList
            //    .Include(dep => dep.Dependency)
            //    .ThenInclude(qr => qr.QrCodeText)
            //    .ToList();
            //DataGrid.ItemsSource = objects;

            //if (objects.Count == 0)
            //    MessageBox.Show("Liste ist leer");
            //else
            //    MessageBox.Show(objects.Count.ToString());


            // load the entities into EF Core
            // _context.Books.Load();

            // bind to the source
            // _bookViewSource.Source =
            //     _context.Books.Local.ToObservableCollection();
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            // _context.SaveChanges();
            MessageBox.Show("Gespeichert!");
            DataGrid.Items.Refresh();
        }

        private void Searchbutton_OnClick(object sender, RoutedEventArgs e)
        {
            Searching();
        }

        private void Searching()
        {
            var textBoxName = SearchBox;
            var filterText = textBoxName.Text;
            var cv = CollectionViewSource.GetDefaultView(DataGrid.ItemsSource);

            if (TitelRadio.IsChecked == true)
            {
                if (!string.IsNullOrEmpty(filterText))
                    cv.Filter = o =>
                    {
                        var p = o as Book;
                        return p.Titel.ToUpper().Contains(filterText.ToUpper());
                    };
                else
                    cv.Filter = null;
            }
            else if (IsbnRadio.IsChecked == true)
            {
                if (!string.IsNullOrEmpty(filterText))
                    cv.Filter = o =>
                    {
                        var p = o as Book;
                        return p.Isbn.ToUpper().Contains(filterText.ToUpper());
                    };
                else
                    cv.Filter = null;
            }
            else if (AuthorRadio.IsChecked == true)
            {
                if (!string.IsNullOrEmpty(filterText))
                    cv.Filter = o =>
                    {
                        var p = o as Book;
                        return p.Autor.ToUpper().Contains(filterText.ToUpper());
                    };
                else
                    cv.Filter = null;
            }
            else
            {
                cv.Filter = null;
            }
        }

        private void SearchBox_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) Searching();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // clean up database connections
            // _context.Dispose();
            base.OnClosing(e);
        }
    }
}