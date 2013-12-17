/*
 * Chatter! A multi-user chat client. 
 * Written by Eric Kline
 * Do what you want with this code. Seriously. Whatever you want.
 * 
 * (Note: commands are case sensitive. This needs to be fixed.)
 * Commands:
 *      + /settings - open a setting dialogue box. User must close and reopen the program for changes to take effect.
 *          (Note: Fix the needing to close issue)
 *      + /nick - Changes the users nickname. Use: "/nick (nickname here)"
 *      
 * Unimplemented Command:
 *      + /disconnect - Disconnects the user from the server
 *      + /connect - connect to a new server. User: "/connect (hostname/ip)" (Must use /disconnect first)
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Chatter
{
    public partial class frmChatter : Form
    {
        private TcpClient client;       //The client class for connecting to the server
        private NetworkStream stream;   //Will inherit from client for reading/writing from/to server
        private Thread t;               //A seperate thread for listening for incoming messages
        private Settings settings;      //Instantiation of the settings class for loading/creating settings

        public frmChatter()
        {
            InitializeComponent();
        }

        //As soon as the form is shown it loads setting, or prompts the user to create
        //a settings file, then connects to the server
        private void frmChatter_Shown(object sender, EventArgs e)
        {
            settings = new Settings();
            settings.LoadSettings();

            StartConnection(settings.serverAddress);
        }

        //Function for connecting to the server
        private void StartConnection(String server)
        {
            try
            {
                Int32 port = 4000;                  //This should be loaded from the text file, but I was lazy
                client = new TcpClient(server, port);

                stream = client.GetStream();        //Sets up the stream for reading/writing

                t = new Thread(ReceiveMessages);    //Creates the new thread that runs the receive messages function
                t.IsBackground = true;              //Set it in the background so the thread closes when the form does
                t.Start();                          //Starts the thread
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("ArgumentNullException: " + e, "Error");
            }
            catch (SocketException e)
            {
                MessageBox.Show("SocketException: " + e, "Error");
            }
        }

        //Pretty self explanatory, just closes the connection to the server.
        //Run when the form is closing
        private void CloseConnection()
        {
            stream.Close();
            client.Close();
        }

        //The ReceiveMessages function just loops until something is sent from the server
        //Once it gets a message from the server it turns the bytes it receives into a string
        //And checks the settings for color in the string, then it removes the color information 
        private void ReceiveMessages()
        {
            while (true)
            {
                byte[] myReadBuffer = new byte[1024];
                StringBuilder myCompleteMessage = new StringBuilder();
                int numberOfBytesRead = 0;

                // Incoming message may be larger than the buffer size. 
                do
                {
                    numberOfBytesRead = stream.Read(myReadBuffer, 0, myReadBuffer.Length);
                    myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));
                }
                while (stream.DataAvailable);

                // Invoke the main thread and set txtConvo to myCompleteMessage.ToString()
                Invoke(new Action(() => 
                {
                    String tempStr = myCompleteMessage.ToString();
                    if (myCompleteMessage.ToString().Contains("`Black`"))
                        tempStr = tempStr.Remove(0, 7);
                    else if (myCompleteMessage.ToString().Contains("`Blue`"))
                        tempStr = tempStr.Remove(0, 6);
                    else if (myCompleteMessage.ToString().Contains("`Green`"))
                        tempStr = tempStr.Remove(0, 7);
                    else if (myCompleteMessage.ToString().Contains("`Pink`"))
                        tempStr = tempStr.Remove(0, 6);
                    else
                        tempStr = tempStr.Remove(0, 5);
                    txtConvo.AppendText(tempStr);
                    if ((txtConvo.Text.Length - tempStr.Length) > 0)
                    {
                        if (myCompleteMessage.ToString().Contains("`Black`"))
                        {
                            txtConvo.Select(txtConvo.Text.Length - tempStr.Length, txtConvo.Text.Length);
                            txtConvo.SelectionColor = Color.Black;

                            
                        }
                        else if(myCompleteMessage.ToString().Contains("`Blue`"))
                        {
                            txtConvo.Select(txtConvo.Text.Length - tempStr.Length, txtConvo.Text.Length);
                            txtConvo.SelectionColor = Color.Blue;
                        }
                        else if (myCompleteMessage.ToString().Contains("`Green`"))
                        {
                            txtConvo.Select(txtConvo.Text.Length - tempStr.Length, txtConvo.Text.Length);
                            txtConvo.SelectionColor = Color.Green;
                        }
                        else if (myCompleteMessage.ToString().Contains("`Pink`"))
                        {
                            txtConvo.Select(txtConvo.Text.Length - tempStr.Length, txtConvo.Text.Length);
                            txtConvo.SelectionColor = Color.Blue;
                        }
                        else
                        {
                            txtConvo.Select(txtConvo.Text.Length - tempStr.Length, txtConvo.Text.Length);
                            txtConvo.SelectionColor = Color.Red;
                        }
                    }
                }
                ));
            }
        }

        //CheckEnterDown is just a function that's run once the enter key is pressed to send a message
        //Note: e.Handled = true keeps the form from making a dinging noise when you hit enter
        private void CheckEnterDown(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                //If the user types the settings command, run the dialogue for saving settings
                if (txtType.Text == "/settings")
                {
                    settings.SaveSettings(settings.serverAddress, settings.username, settings.textColor);
                    e.Handled = true; 
                }
                //If the user types the nick command, change their nick to the word following "/nick "
                else if (txtType.Text.Contains("/nick "))
                {
                    StreamWriter writeStream = new StreamWriter(client.GetStream());
                    settings.username = txtType.Text.TrimStart('/', 'n', 'i', 'c', 'k', ' ');
                    writeStream.Flush();
                    txtType.Text = "";
                    e.Handled = true;
                }
                else if (txtType.Text == "")
                {
                    //Do nothing
                    //And make a dinging noise to punish the user for his/her insolence
                }
                //If none of the other conditions are met, send the string to the server and flush the textbox
                else
                {
                    StreamWriter writeStream = new StreamWriter(client.GetStream());
                    writeStream.WriteLine("`" + settings.textColor + "`" + settings.username + ": " + txtType.Text);
                    writeStream.Flush();
                    txtType.Text = "";
                    txtType.Lines = null;
                    e.Handled = true;
                }
            }
        }

        //This function just makes sure the txtbox scrolls automatically when the text is too large for the box
        private void txtConvo_TextChanged(object sender, EventArgs e)
        {
            txtConvo.SelectionStart = txtConvo.Text.Length;
            txtConvo.ScrollToCaret();
        }
    }
}
