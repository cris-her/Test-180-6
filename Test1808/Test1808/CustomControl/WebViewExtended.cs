using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Test1808.CustomControl
{
    public class WebViewExtended : WebView
    {
        public Action<string> SetSearchText;
        public Action DoSearch;
        public Action Observe;

        public event EventHandler SearchPressed;

        public void OnSearchBtnPressed()
        {
            SearchPressed?.Invoke(this, null);
        }
    }
}
