using Android.Content;
using Android.Webkit;
using Java.Interop;
using System;
using Test1809.CustomControl;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(WebViewExtended), typeof(Test1809.Droid.CustomControl.WebViewExtendedRenderer))]
namespace Test1809.Droid.CustomControl
{
    public class WebViewExtendedRenderer : WebViewRenderer
    {
        const string JavascriptFunction = "function invokeCSharpAction(data){AnalyticsWebInterface.invokeAction(data);}";
        Context _context;
        public WebViewExtendedRenderer(Context context) : base(context)
        {
            _context = context;
        }
        /*
        protected override WebView CreateNativeControl()
        {
            WebView webView = base.CreateNativeControl();
            webView.Settings.JavaScriptEnabled = true;

            webView.AddJavascriptInterface(new AnalyticsWebInterface(), "Test");

            return webView;
        }*/

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                Control.RemoveJavascriptInterface("AnalyticsWebInterface");
                ((WebViewExtended)Element).Cleanup();
            }
            if (e.NewElement != null)
            {
                Control.SetWebViewClient(new JavascriptWebViewClient(this, $"javascript: {JavascriptFunction}"));
                Control.AddJavascriptInterface(new AnalyticsWebInterface(this), "AnalyticsWebInterface");
                Control.LoadUrl($"file:///android_asset/Content/{((WebViewExtended)Element).Uri}");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ((WebViewExtended)Element).Cleanup();
            }
            base.Dispose(disposing);
        }

        /*
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
        }*/
    }
}