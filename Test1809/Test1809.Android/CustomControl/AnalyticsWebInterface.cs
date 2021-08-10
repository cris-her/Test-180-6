using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Java.Interop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test1809.CustomControl;
using Test1809.Interface;
using Xamarin.Forms;

namespace Test1809.Droid.CustomControl
{
    public class AnalyticsWebInterface : Java.Lang.Object
    {
        readonly WeakReference<WebViewExtendedRenderer> webViewExtendedRenderer;
        //private IServiceFirebaseAnalytics eventTracker;


        public AnalyticsWebInterface(WebViewExtendedRenderer extendedRenderer)
        {
            //eventTracker = DependencyService.Get<IServiceFirebaseAnalytics>();
            webViewExtendedRenderer = new WeakReference<WebViewExtendedRenderer>(extendedRenderer);
        }

        [JavascriptInterface]
        [Export("invokeAction")]
        public void InvokeAction(string data)
        {
            WebViewExtendedRenderer extendedRenderer;

            if (webViewExtendedRenderer != null && webViewExtendedRenderer.TryGetTarget(out extendedRenderer))
            {
                ((WebViewExtended)extendedRenderer.Element).InvokeAction(data);
            }
        }

        [JavascriptInterface]
        [Export("logEvent")]
        public void logEvent(string name, string jsonParams)
        {
            // LOGD("logEvent:" + name);
            //eventTracker.SendEvent(name, dictionaryFromJson(jsonParams));
            //webViewExtended.OnSearchBtnPressed();
        }

        private Dictionary<string, string> dictionaryFromJson(string json)
        {
            if (json == null)
            {
                return new Dictionary<string, string>();
            }
            else
            {
                return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
        }
    }
}

/*
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
}*/