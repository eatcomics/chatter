using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Chatter
{
    public partial class frmSettings : Form
    {
        private string settingFile = ".\\Settings.txt";

        public string server = "";
        public string username = "";
        public string txtcolor = "";


        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter fileWrite = File.CreateText(settingFile))
            {
                //Server Address
                if (txtServer.Text == "")
                {
                    MessageBox.Show("Please enter a Server address");
                    txtServer.Focus();
                }
                else
                {
                    fileWrite.WriteLine(txtServer.Text);
                    
                    //Text Color
                    switch (cboTextColor.SelectedIndex)
                    {
                        case 0:
                            fileWrite.WriteLine("Black");
                            break;
                        case 1:
                            fileWrite.WriteLine("Blue");
                            break;
                        case 2:
                            fileWrite.WriteLine("Green");
                            break;
                        case 3:
                            fileWrite.WriteLine("Pink");
                            break;
                        case 4:
                            fileWrite.WriteLine("Red");
                            break;
                        default:
                            //Random Color
                            fileWrite.WriteLine("Red");
                            break;
                    }

                    //Username
                    if (txtUser.Text != "")
                    {
                        fileWrite.WriteLine(txtUser.Text);
                    }
                    else
                    {
                        //Default Name
                        fileWrite.WriteLine("ThisGuyHasNoName");
                    }
                }

                this.Close();
            }
        }

        //Once the form is shown, fill it with the previous settings
        //If there aren't any it just writes that classes defaults of ""
        private void frmSettings_Shown(object sender, EventArgs e)
        {
            txtServer.Text = server;
            txtUser.Text = username;

            if (txtcolor == "Black")
                cboTextColor.SelectedIndex = 0;
            else if (txtcolor == "Blue")
                cboTextColor.SelectedIndex = 1;
            else if (txtcolor == "Green")
                cboTextColor.SelectedIndex = 2;
            else if (txtcolor == "Pink")
                cboTextColor.SelectedIndex = 3;
            else if (txtcolor == "Red")
                cboTextColor.SelectedIndex = 4;
        }
    }
}
