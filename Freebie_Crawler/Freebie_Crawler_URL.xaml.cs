using System.Windows;

namespace Freebie_Crawler
{
    /// <summary>
    /// Interaction logic for Freebie_Crawler_URL.xaml
    /// </summary>
    public partial class Freebie_Crawler_URL : Window
    {
        public string crawlURL = Properties.Settings.Default.Crawl_URL;
        public string crawlKey = Properties.Settings.Default.Crawl_Keyword;

        public Freebie_Crawler_URL()
        {
            InitializeComponent();

            Crawl_URL_User.Text = crawlURL;
            Crawl_Keyword.Text = crawlKey;
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            crawlURL = Crawl_URL_User.Text;
            Properties.Settings.Default.Crawl_URL = crawlURL;

            crawlKey = Crawl_Keyword.Text;
            Properties.Settings.Default.Crawl_Keyword = crawlKey;

            this.Close();
        }
    }
}