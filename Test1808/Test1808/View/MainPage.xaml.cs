
namespace Test1808.View
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void wve_SearchPressed(object sender, System.EventArgs e)
        {
            DisplayAlert("Alert", "Button pressed", "Ok");
        }

        private void btnText_Clicked(object sender, System.EventArgs e)
        {
            wve.SetSearchText("DevsDNA");
        }

        private void btnSearch_Clicked(object sender, System.EventArgs e)
        {
            wve.DoSearch();
        }

        private void btnObserve_Clicked(object sender, System.EventArgs e)
        {
            wve.Observe();
        }
    }
}
