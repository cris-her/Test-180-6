using System;
using System.Collections.Generic;
using System.Text;

namespace Test1808.Interface
{
    public interface IServiceFirebaseAnalytics
    {
        void SendEvent(string eventId); //LogEvent?
        void SendEvent(string eventId, string paramName, string value);
        void SendEvent(string eventId, IDictionary<string, string> parameters);
        void SetUserId(string userId);
    }
}
