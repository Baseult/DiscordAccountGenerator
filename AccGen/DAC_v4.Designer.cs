using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace DAC_v4
{
    public class DAC : MetroForm
    {
        public string[] proxies = (new WebClient()).DownloadString("https://proxyscrape.com/proxies/HTTP_Working_Proxies.txt").Split(new char[] { '\n' });

        public string fileName = string.Format("tokens/{0:yyyy-MM-dd_HH-mm-ss}.txt", DateTime.Now);

        private IContainer components = null;

        private MetroButton start;

        private MetroLabel label;

        private MetroTextBox username;

        private MetroCheckBox random;

        private MetroTextBox metroTextBox1;

        private MetroTextBox invite;

        private MetroLabel metroLabel1;

        private MetroCheckBox metroCheckBox2;

        private MetroButton getProxies;

        public DAC()
        {
            this.InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            Process.Start("https://www.youtube.com/Lemons1337?sub_confirmation=1");
        }

        public string createAccount(string username, string invite, string host, int port)
        {
            string str;
            if (this.start.Text.ToUpper() != "START")
            {
                string str1 = "https://discordapp.com/api/auth/register";
                WebClient webClient = new WebClient()
                {
                    Proxy = new WebProxy(host, port)
                };
                string str2 = string.Concat(new string[] { "{\"username\":\"", username, "\",\"invite\":", invite, ",\"consent\":true,\"captcha_key\":null}" });
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                try
                {
                    dynamic obj = JObject.Parse(webClient.UploadString(str1, str2));
                    string str3 = (string)obj.token.ToString();
                    this.metroTextBox1.AppendText(string.Concat(str3, "\r\n"));
                    File.AppendAllText(this.fileName, string.Concat(str3, "\r\n"));
                }
                catch (Exception exception)
                {
                }
                Thread thread = new Thread(() => this.sendAnother())
                {
                    IsBackground = true
                };
                thread.Start();
                str = null;
            }
            else
            {
                str = null;
            }
            return str;
        }

        private void DAC_Load(object sender, EventArgs e)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if ((!disposing ? false : this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public string getName()
        {
            Guid guid = Guid.NewGuid();
            string str = Regex.Replace(Convert.ToBase64String(guid.ToByteArray()).Substring(0, 12), "[^0-9A-Za-z]+", "");
            return str;
        }

        private void getProxies_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "Select your proxy list"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.proxies = File.ReadAllText(openFileDialog.FileName.ToString()).Split(new char[] { '\n' });
                MessageBox.Show("Proxy file selected!");
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(DAC));
            this.start = new MetroButton();
            this.label = new MetroLabel();
            this.username = new MetroTextBox();
            this.random = new MetroCheckBox();
            this.metroTextBox1 = new MetroTextBox();
            this.invite = new MetroTextBox();
            this.metroLabel1 = new MetroLabel();
            this.metroCheckBox2 = new MetroCheckBox();
            this.getProxies = new MetroButton();
            base.SuspendLayout();
            this.start.Highlight = true;
            this.start.Location = new Point(48, 345);
            this.start.Name = "start";
            this.start.Size = new Size(315, 60);
            this.start.TabIndex = 0;
            this.start.Text = "Start";
            this.start.Theme = MetroThemeStyle.Dark;
            this.start.Click += new EventHandler(this.start_Click);
            this.label.AutoSize = true;
            this.label.BackColor = Color.White;
            this.label.ForeColor = SystemColors.ControlText;
            this.label.Location = new Point(48, 296);
            this.label.Name = "label";
            this.label.Size = new Size(75, 19);
            this.label.Style = MetroColorStyle.Teal;
            this.label.TabIndex = 1;
            this.label.Text = "Username: ";
            this.label.Theme = MetroThemeStyle.Dark;
            this.label.Click += new EventHandler(this.metroLabel1_Click);
            this.username.Location = new Point(129, 296);
            this.username.MaxLength = 30;
            this.username.Name = "username";
            this.username.Size = new Size(234, 23);
            this.username.TabIndex = 2;
            this.username.Text = "allthefoxes";
            this.username.Theme = MetroThemeStyle.Dark;
            this.username.Click += new EventHandler(this.metroTextBox1_Click);
            this.random.AutoSize = true;
            this.random.Location = new Point(48, 213);
            this.random.Name = "random";
            this.random.Size = new Size(129, 15);
            this.random.TabIndex = 3;
            this.random.Text = "Random Usernames";
            this.random.Theme = MetroThemeStyle.Dark;
            this.random.UseVisualStyleBackColor = true;
            this.random.CheckedChanged += new EventHandler(this.metroCheckBox1_CheckedChanged);
            this.metroTextBox1.Location = new Point(416, 38);
            this.metroTextBox1.Multiline = true;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.ScrollBars = ScrollBars.Vertical;
            this.metroTextBox1.Size = new Size(495, 486);
            this.metroTextBox1.TabIndex = 4;
            this.metroTextBox1.Theme = MetroThemeStyle.Dark;
            this.invite.Location = new Point(96, 250);
            this.invite.MaxLength = 20;
            this.invite.Name = "invite";
            this.invite.Size = new Size(267, 23);
            this.invite.TabIndex = 6;
            this.invite.Text = "qJq5C";
            this.invite.Theme = MetroThemeStyle.Dark;
            this.invite.Click += new EventHandler(this.metroTextBox2_Click);
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new Point(48, 254);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new Size(42, 19);
            this.metroLabel1.TabIndex = 7;
            this.metroLabel1.Text = "Invite:";
            this.metroLabel1.Theme = MetroThemeStyle.Dark;
            this.metroCheckBox2.AutoSize = true;
            this.metroCheckBox2.Checked = true;
            this.metroCheckBox2.CheckState = CheckState.Checked;
            this.metroCheckBox2.Location = new Point(48, 180);
            this.metroCheckBox2.Name = "metroCheckBox2";
            this.metroCheckBox2.Size = new Size(97, 15);
            this.metroCheckBox2.TabIndex = 5;
            this.metroCheckBox2.Text = "Custom Invite";
            this.metroCheckBox2.Theme = MetroThemeStyle.Dark;
            this.metroCheckBox2.UseVisualStyleBackColor = true;
            this.metroCheckBox2.CheckedChanged += new EventHandler(this.metroCheckBox1_CheckedChanged_1);
            this.getProxies.Highlight = true;
            this.getProxies.Location = new Point(209, 180);
            this.getProxies.Name = "getProxies";
            this.getProxies.Size = new Size(154, 48);
            this.getProxies.TabIndex = 10;
            this.getProxies.Text = "Select Proxies (optional)";
            this.getProxies.Theme = MetroThemeStyle.Dark;
            this.getProxies.Click += new EventHandler(this.getProxies_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(934, 547);
            base.Controls.Add(this.getProxies);
            base.Controls.Add(this.metroLabel1);
            base.Controls.Add(this.invite);
            base.Controls.Add(this.metroCheckBox2);
            base.Controls.Add(this.metroTextBox1);
            base.Controls.Add(this.random);
            base.Controls.Add(this.username);
            base.Controls.Add(this.label);
            base.Controls.Add(this.start);
            base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            base.Name = "DAC";
            this.Text = "Discord Account Creator";
            base.Theme = MetroThemeStyle.Dark;
            base.Load += new EventHandler(this.DAC_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            switch (this.random.CheckState)
            {
                case CheckState.Unchecked:
                case CheckState.Indeterminate:
                    {
                        this.username.Enabled = true;
                        break;
                    }
                case CheckState.Checked:
                    {
                        this.username.Enabled = false;
                        break;
                    }
            }
        }

        private void metroCheckBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            switch (this.metroCheckBox2.CheckState)
            {
                case CheckState.Unchecked:
                case CheckState.Indeterminate:
                    {
                        this.invite.Enabled = false;
                        break;
                    }
                case CheckState.Checked:
                    {
                        this.invite.Enabled = true;
                        break;
                    }
            }
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
        }

        private void metroTextBox1_Click_1(object sender, EventArgs e)
        {
        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {
        }

        public string sendAnother()
        {
            try
            {
                string str = (this.random.Checked ? this.getName() : this.username.Text);
                string str1 = (this.metroCheckBox2.Checked ? string.Concat("\"", this.invite.Text, "\"") : "null");
                string str2 = this.proxies[(new Random()).Next((int)this.proxies.Length)].ToString();
                string str3 = str2.Split(new char[] { ':' })[0];
                int num = int.Parse(str2.Split(new char[] { ':' })[1]);
                Thread thread = new Thread(() => this.createAccount(str, str1, str3, num))
                {
                    IsBackground = true
                };
                thread.Start();
            }
            catch (Exception exception)
            {
            }
            return null;
        }

        private void start_Click(object sender, EventArgs e)
        {
            string upper = this.start.Text.ToUpper();
            if (upper == "START")
            {
                this.start.Text = "Stop";
                Thread thread = new Thread(() => this.startThreads())
                {
                    IsBackground = true
                };
                thread.Start();
            }
            else if (upper == "STOP")
            {
                this.start.Text = "Start";
            }
        }

        public string startThreads()
        {
            MessageBox.Show("Started Account Creator");
            string str = (this.random.Checked ? this.getName() : this.username.Text);
            string str1 = (this.metroCheckBox2.Checked ? string.Concat("\"", this.invite.Text, "\"") : "null");
            for (int i = 0; i < 500; i++)
            {
                try
                {
                    string str2 = this.proxies[(new Random()).Next((int)this.proxies.Length)].ToString();
                    string str3 = str2.Split(new char[] { ':' })[0];
                    int num = int.Parse(str2.Split(new char[] { ':' })[1]);
                    Thread thread = new Thread(() => this.createAccount(str, str1, str3, num))
                    {
                        IsBackground = true
                    };
                    thread.Start();
                }
                catch (Exception exception)
                {
                }
            }
            return null;
        }
    }
}