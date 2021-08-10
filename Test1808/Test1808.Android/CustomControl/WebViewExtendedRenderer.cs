using Android.Content;
using Android.Webkit;
using Java.Interop;
using System;
using Test1808.CustomControl;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(WebViewExtended), typeof(Test1808.Droid.CustomControl.WebViewExtendedRenderer))]
namespace Test1808.Droid.CustomControl
{
    public class WebViewExtendedRenderer : WebViewRenderer
    {
        public WebViewExtendedRenderer(Context context) : base(context)
        {
        }

        protected override WebView CreateNativeControl()
        {
            WebView webView = base.CreateNativeControl();
            webView.Settings.JavaScriptEnabled = true;

            webView.AddJavascriptInterface(new JavascriptInterface(Element as WebViewExtended), "Test");

            return webView;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                ((WebViewExtended)e.NewElement).SetSearchText = SetSearchText;
                ((WebViewExtended)e.NewElement).DoSearch = DoSearch;
                ((WebViewExtended)e.NewElement).Observe = Observe;
            }
        }

        private void SetSearchText(string text)
        {
            string javascript = $"javascript: document.getElementById('sb_form_q').value = '{text}';";
            Control.EvaluateJavascript(javascript, null);
        }

        private void DoSearch()
        {
            string javascript = "javascript: document.getElementById('sb_form_go').click();";
            Control.EvaluateJavascript(javascript, null);
        }
        private void Observe()
        {
            string javascript = "javascript: document.getElementById('sb_form_go').onclick = function() { Test.ButtonPressed(); };";
            Control.EvaluateJavascript(javascript, null);
        }
    }

    public class JavascriptInterface : Java.Lang.Object
    {
        private WebViewExtended webViewExtended;

        public JavascriptInterface(WebViewExtended webViewExtended) : base()
        {
            this.webViewExtended = webViewExtended;
        }

        [JavascriptInterface]
        [Export("ButtonPressed")]
        public void ButtonPressed()
        {
            webViewExtended.OnSearchBtnPressed();
        }
    }
}