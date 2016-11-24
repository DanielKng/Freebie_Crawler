using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Freebie_Crawler
{
    /// <summary>
    /// Interaction logic for Refresh_Call.xaml
    /// </summary>
    public partial class Refresh_Call : Window
    {
        public Refresh_Call()
        {
            InitializeComponent();
            CrawlRefresh();
        }
        async Task CrawlRefresh()
        {
            int refreshTime = Properties.Settings.Default.Refresh_Time;
            refreshTime = (refreshTime * 60 * 60);
            MessageBox.Show(Convert.ToString(refreshTime));
            await Task.Delay(refreshTime);
        }
    }
}
