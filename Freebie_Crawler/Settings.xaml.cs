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
    /// Interaktionslogik für Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            //Call the Combobox Method on Start
            Combobox_Fill();
            //Jump into the Method
            CheckForOptions();
        }

        private void Combobox_Fill()
        {
            if (Properties.Settings.Default.Refresh_Time != 15)
            {
                CheckForOptions();
                //Fills the Combobox with Variables
                Minutes_Combobox.Items.Add("5");
                Minutes_Combobox.Items.Add("10");
                Minutes_Combobox.Items.Add("15");
                Minutes_Combobox.Items.Add("30");
                Minutes_Combobox.Items.Add("60");
            }
            else if (Properties.Settings.Default.Refresh_Time == 15)
            {
                //Selects a standard Item (15 minutes)
                Minutes_Combobox.SelectedIndex = 2;
                //Fills the Combobox with Variables
                Minutes_Combobox.Items.Add("5");
                Minutes_Combobox.Items.Add("10");
                Minutes_Combobox.Items.Add("15");
                Minutes_Combobox.Items.Add("30");
                Minutes_Combobox.Items.Add("60");
            }
        }
        //Only save the Settings if the User wants to apply it
        private void Apply_Clicked(object sender, RoutedEventArgs e)
        {
            #region Minimize to Tray Checkbox

            if (MinimizeToTray.IsChecked == true)
            {
                //Save the Settings in the User.Config
                Properties.Settings.Default.Minimize_Tray = true;
                SaveSettings();
            }
            else if (MinimizeToTray.IsChecked == false)
            {
                //Save the Settings in the User.Config
                Properties.Settings.Default.Minimize_Tray = false;
                SaveSettings();
            }

            #endregion
            #region Notify using Windows 10 Toast

            if (Notify_Win10.IsChecked == true)
            {
                //Save the Settings in the User.Config
                Properties.Settings.Default.Windows10_Notify = true;
                SaveSettings();
            }
            else if (Notify_Win10.IsChecked == false)
            {
                //Save the Settings in the User.Config
                Properties.Settings.Default.Windows10_Notify = false;
                SaveSettings();
            }

            #endregion
            #region Notify using PopUp

            if (Notify_PopUp.IsChecked == true)
            {
                //Save the Settings in the User.Config
                Properties.Settings.Default.PopUp_Notify = true;
                SaveSettings();
            }

            else if (Notify_PopUp.IsChecked == false)
            {
                //Save the Settings in the User.Config
                Properties.Settings.Default.PopUp_Notify = false;
                SaveSettings();
            }

            #endregion
            #region Combobox

            int i = Convert.ToInt32(Minutes_Combobox.SelectedItem);
            if (i == 5)
            {
                Minutes_Combobox.SelectedIndex = 0;
                Properties.Settings.Default.Refresh_Time = 5;
                SaveSettings();
            }
            else if (i == 10)
            {
                Minutes_Combobox.SelectedIndex = 1;
                Properties.Settings.Default.Refresh_Time = 10;
                SaveSettings();
            }
            else if (i == 15)
            {
                Minutes_Combobox.SelectedIndex = 2;
                Properties.Settings.Default.Refresh_Time = 15;
                SaveSettings();
            }
            else if (i == 30)
            {
                Minutes_Combobox.SelectedIndex = 3;
                Properties.Settings.Default.Refresh_Time = 30;
                SaveSettings();
            }
            else if (i == 60)
            {
                Minutes_Combobox.SelectedIndex = 4;
                Properties.Settings.Default.Refresh_Time = 60;
                SaveSettings();
            }
            #endregion
            this.Close();
        }

        private void CheckForOptions()
        {
            if (Properties.Settings.Default.Minimize_Tray)
            {
                this.MinimizeToTray.IsChecked = true;
            }
            if (Properties.Settings.Default.Windows10_Notify)
            {
                this.Notify_Win10.IsChecked = true;
            }
            if (Properties.Settings.Default.PopUp_Notify)
            {
                this.Notify_PopUp.IsChecked = true;
            }
            if (Properties.Settings.Default.Refresh_Time == 5)
            {
                Minutes_Combobox.SelectedIndex = 0;
            }
            if (Properties.Settings.Default.Refresh_Time == 10)
            {
                Minutes_Combobox.SelectedIndex = 1;
            }
            if (Properties.Settings.Default.Refresh_Time == 15)
            {
                Minutes_Combobox.SelectedIndex = 2;
            }
            if (Properties.Settings.Default.Refresh_Time == 30)
            {
                Minutes_Combobox.SelectedIndex = 3;
            }
            if (Properties.Settings.Default.Refresh_Time == 60)
            {
                Minutes_Combobox.SelectedIndex = 4;
            }
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }
    }
}
