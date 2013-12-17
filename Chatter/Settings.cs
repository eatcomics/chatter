using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Chatter
{
    class Settings
    {
        private string settingFile = ".\\Settings.txt";
        public string serverAddress = "";
        public string textColor = "";
        public string username = "";

        public void LoadSettings()
        {
            //If there's no settings file, open a dialogue so the user can create one
            if (!File.Exists(settingFile))
            {
                SaveSettings();
            }

            //code for loading settings
            using (StreamReader reader = new StreamReader(settingFile))
            {
                serverAddress = reader.ReadLine();
                textColor = reader.ReadLine();
                username = reader.ReadLine();
            }
        }

        //This sets up the settings form and displays a messagebox that lets the user know what's up
        public void SaveSettings()
        {
            System.Windows.Forms.MessageBox.Show("You do not have a settings file. Hit okay to create one.");

            frmSettings settingsForm = new frmSettings();
            settingsForm.ShowDialog();
        }

        //This is similar to the above function, but it's called when the user uses the "/settings" command
        //It creates a settings dialogue, but it fills in the old settings for reference.
        //It also doesn't pop up the messagebox about not having a setting file
        public void SaveSettings(string _serverAddress, string _username, string _textColor)
        {
            frmSettings settingsForm = new frmSettings();
            settingsForm.server = _serverAddress;
            settingsForm.username = _username;
            settingsForm.txtcolor = _textColor;
            settingsForm.ShowDialog();
        }
    }
}
