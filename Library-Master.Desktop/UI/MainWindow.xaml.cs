using System;
using System.Windows;
using Library_Master.Desktop.UI;
using Microsoft.Win32;

namespace Library_Master.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Export_To_Csv_OnClick(object sender, RoutedEventArgs e)
        {
            // var exporterCsv = new CsvExporter();
            // var db = new LibraryContext();
            // var list = db.AbfragenAllerSchuelerBuechereiObjects();
            // exporterCsv.SchreibeInCsv(list);
        }

        private void Export_To_Json_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Settings_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void LoginscreenShowButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MenuBuchItemNew_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MenuItemBookDataView_Click(object sender, RoutedEventArgs e)
        {
            var dataview = new Dataview();
            dataview.ShowDialog();
        }

        private void Import_Json_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Import_Csv_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialogImport = new OpenFileDialog();
            fileDialogImport.Filter = "CSV files (*.csv)|*.csv";
            if (fileDialogImport.ShowDialog() == true)
            {
                var importPath = fileDialogImport.FileName;
                // CsvImporter importer = new CsvImporter(importPath);
            }
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ChangeToBookDataView()
        {
            throw new NotImplementedException();
        }

        public void ChangeToAddNewBookView()
        {
            throw new NotImplementedException();
        }

        public void ChangeToSchuelerDataView()
        {
            throw new NotImplementedException();
        }

        public void ChangeToAddNewSchuelerView()
        {
            throw new NotImplementedException();
        }

        public void ChangeToHauptmenuView()
        {
            throw new NotImplementedException();
        }

        public void ChangeToReturnItemView()
        {
            throw new NotImplementedException();
        }

        public void ChangeToIssueItemView()
        {
            throw new NotImplementedException();
        }

        private void MenuItemMainMenu_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MenuItemSchuelerDataView_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MenuSchuelerItemNew_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void NotificationButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}