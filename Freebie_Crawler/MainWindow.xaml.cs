using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Freebie_Crawler.ShellHelpers;
using MS.WindowsAPICodePack.Internal;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;

using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
using System.Net;

namespace Freebie_Crawler
{
    public partial class MainWindow : Window
    {
        Windows10_Notifications win10_notification = new Windows10_Notifications();
        public MainWindow()
        {
            InitializeComponent();
            //A shourtcut is needed for the Toast to show up.
            win10_notification.TryCreateShortcut();
        }

        public void CrawlWebsite()
        {
            string pageContent = null;
            //Start the Timer
            Refresh_Call callRefresh = new Refresh_Call();
            //Open a HTTP-Request with the User-Specified URL
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.Crawl_URL);
            //Get the HTTP-Response, since we want to Crawl the Content
            HttpWebResponse myres = (HttpWebResponse)myReq.GetResponse();
            //Use the respond and crawl its content
            using (StreamReader sr = new StreamReader(myres.GetResponseStream()))
            {
                pageContent = sr.ReadToEnd();
            }
            //If the Keyword is available at the Page, show the Toast
            if (pageContent.Contains(Properties.Settings.Default.Crawl_Keyword))
            {
                win10_notification.ShowToast();
            }
            else
            {
                //Error
            }
        }

        //Used if the user want's to manually crawl
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            CrawlWebsite();
        }
        //Open up the Settings Windows if clicked
        private void Options_Click(object sender, RoutedEventArgs e)
        {
            //Get the Window reference
            Settings openOptions = new Settings();
            //Obviously...show the Options
            openOptions.Show();
        }

        private void Freebie_Settings_Cick(object sender, RoutedEventArgs e)
        {
            var FreebieCrawlerSettings = new Freebie_Crawler_URL();
            FreebieCrawlerSettings.Show();
        }
    }
}
