using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Test1809.CustomControl
{
    public class WebViewExtended : WebView
    {
        /*
        public Action<string> SetSearchText;
        public Action DoSearch;
        public Action Observe;

        public event EventHandler SearchPressed;

        public void OnSearchBtnPressed()
        {
            SearchPressed?.Invoke(this, null);
        }*/

        Action<string, string> action;
        Action<string, Dictionary<string, string>> analyticsAction;

        public static readonly BindableProperty UriProperty = BindableProperty.Create(
            propertyName: "Uri",
            returnType: typeof(string),
            declaringType: typeof(WebViewExtended),
            defaultValue: default(string));

        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }

        public void RegisterAction(Action<string, string> callback)
        {
            action = callback;
        }

        public void LogEvent(Action<string, Dictionary<string, string>> callback)
        {
            analyticsAction = callback;
        }

        public void Cleanup()
        {
            action = null;
            analyticsAction = null;
        }

        public void InvokeAction(string data)
        {
            if (action == null || data == null) // || jsonParams == null ??
            {
                return;
            }

            var dictData = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);

            action.Invoke(dictData["name"], dictData["jsonParams"]);

            var dictParams = JsonConvert.DeserializeObject<Dictionary<string, string>>(dictData["jsonParams"]);
            analyticsAction.Invoke(dictData["name"], dictParams);
        }
    }
}
