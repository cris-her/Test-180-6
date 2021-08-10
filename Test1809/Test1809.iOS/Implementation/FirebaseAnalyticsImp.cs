using Firebase.Analytics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Test1809.Interface;
using Xamarin.Forms;
using Test1809.iOS.Implementation;

[assembly: Dependency(typeof(FirebaseAnalyticsImp))]
namespace Test1809.iOS.Implementation
{
    public class FirebaseAnalyticsImp : IServiceFirebaseAnalytics
    {
        public void SendEvent(string eventId)
        {
            SendEvent(eventId, (IDictionary<string, string>)null);
        }

        public void SendEvent(string eventId, string paramName, string value)
        {
            SendEvent(eventId, new Dictionary<string, string>
            {
              { paramName, value }
            });
        }

        public void SetUserId(string userId)
        {
            Analytics.SetUserId(userId);
        }

        public void SendEvent(string eventId, IDictionary<string, string> parameters)
        {
            if (parameters == null)
            {
              Analytics.LogEvent(eventId, parameters: null);
              return;
            }

            var keys = new List<NSString>();
            var values = new List<NSString>();
            foreach (var item in parameters)
            {
              keys.Add(new NSString(item.Key));
              values.Add(new NSString(item.Value));
            }

            var parametersDictionary = NSDictionary<NSString, NSObject>.FromObjectsAndKeys(values.ToArray(), keys.ToArray(), keys.Count);
            Analytics.LogEvent(eventId, parametersDictionary);
        }
    }
}