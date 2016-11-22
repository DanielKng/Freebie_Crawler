using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace Freebie_Crawler
{
    /// <summary>
    /// Interaction logic for Auto_Refresh.xaml
    /// </summary>
    public partial class Auto_Refresh : Window
    {
        private int delay = Properties.Settings.Default.Refresh_Time;

        public Auto_Refresh()
        {
            InitializeComponent();
            RefreshDelay();                   
        }

        async Task RefreshDelay()
        {
            MessageBox.Show(Convert.ToString(delay));
            await Task.Delay(delay);

            var crawlAgain = new MainWindow();
            crawlAgain.CrawlWebsite();
        }
    }
}
