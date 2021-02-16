using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Library_Master.Core.Models;
using Library_Master.Core.Services;

namespace Library_Master.Desktop.Wpf.ViewModels
{
    public class IndexCardListingViewModel : BaseViewModel
    {
        private IIndexCardService _indexCardService;

        private IndexCard _bookCard;
        private IndexCard _borrowedBooksCard;
        private IndexCard _studentsCard;

        public IndexCard BookCard
        {
            get => _bookCard;
            set
            {
                _bookCard = value;
                OnPropertyChanged(nameof(BookCard));
            }
        }

        public IndexCard BorrowedBooksCard
        {
            get => _borrowedBooksCard;
            set
            {
                _borrowedBooksCard = value;
                OnPropertyChanged(nameof(BorrowedBooksCard));
            }
        }

        public IndexCard StudentsCard
        {
            get => _studentsCard;
            set
            {
                _studentsCard = value;
                OnPropertyChanged(nameof(StudentsCard));
            }
        }

        public IndexCardListingViewModel(IIndexCardService indexCardService)
        {
            _indexCardService = indexCardService;
        }

        public static IndexCardListingViewModel LoadIndexCardViewModel(IIndexCardService indexCardService)
        {
            IndexCardListingViewModel indexCardViewModel = new IndexCardListingViewModel(indexCardService);
            indexCardViewModel.LoadIndexCards();
            return indexCardViewModel;
        }

        private void LoadIndexCards()
        {
            BookCard = _indexCardService.GetIndexCard(IndexCardType.Books).Result;
            BorrowedBooksCard =  _indexCardService.GetIndexCard(IndexCardType.Ausgeliehen).Result;
            StudentsCard = _indexCardService.GetIndexCard(IndexCardType.Students).Result;
        }
    }
}