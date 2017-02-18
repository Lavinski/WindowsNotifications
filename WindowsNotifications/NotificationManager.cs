using System;
using System.Linq;
using Windows.Data.Xml.Dom;
//using System.Xml;
using Windows.UI.Notifications;

namespace WindowsNotifications
{
    public class NotificationManager
    {
        private readonly string _appName;

        public NotificationManager(string appName)
        {
            _appName = appName;
        }

        public void Toast(string title, string line1, string line2)
        {
            var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText04);

            var toastTextAttributes = toastXml.GetElementsByTagName("text").ToArray();
            toastTextAttributes[0].InnerText = title;
            toastTextAttributes[1].InnerText = line1;
            toastTextAttributes[2].InnerText = line2;

            var toast = new ToastNotification(toastXml);
            var notifier = ToastNotificationManager.CreateToastNotifier(_appName);
            notifier.Show(toast);
            
        }
    }
}
