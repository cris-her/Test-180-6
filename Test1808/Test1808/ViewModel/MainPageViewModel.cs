using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test1808.Interface;
using Xamarin.Forms;

namespace Test1808.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            /*
            IServiceFirebaseAnalytics eventTracker = DependencyService.Get<IServiceFirebaseAnalytics>();
            eventTracker?.SendEvent("Click001");
            eventTracker?.SendEvent("Click002", "Comment", "Hello Events");
            var dictionary = new Dictionary<string, string>
            {
                {"Name", "John Xamarin"},
                {"Phone", "55 555 555 555"},
                {"Email", "johnxamarin@john.com"}
            };
            eventTracker?.SendEvent("Click003", dictionary);*/
        }
    }
}
