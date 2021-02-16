namespace Library_Master.Desktop.Wpf.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public IndexCardListingViewModel IndexCardListingViewmodel { get; set; }

        public HomeViewModel(IndexCardListingViewModel indexCardViewmodel)
        {
            IndexCardListingViewmodel = indexCardViewmodel;
        }
    }
}