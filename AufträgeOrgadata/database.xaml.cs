using System;
using System.IO;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace AufträgeOrgadata
{
    public partial class database
    {
        public string uid;
        public string pw;
        public string server;
        public string port;
        public string databasetxt;

        public database()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {


            XElement n = new XElement("AufträgeOrgadata",
                new XElement("login"),
                new XElement("username", uid),
                new XElement("password", pw),
                new XElement("server", server),
                new XElement("port", port),
                new XElement("database", databasetxt));

            n.Save("login.xml");

            Close();
        }

        private void LoadSettings()
        {
            if (!File.Exists("login.xml")) return;
            using (
                var reader = new XmlTextReader(AppDomain.CurrentDomain.BaseDirectory + @"\login.xml")
                )
                while (reader.Read())
                {
                    if (!reader.IsStartElement()) continue;
                    switch (reader.Name)
                    {
                        case "server":
                            txtServer.Text = reader.ReadString();
                            break;

                        case "database":
                            txtDatabase.Text = reader.ReadString();
                            break;

                        case "username":
                            txtUid.Text = reader.ReadString();
                            break;

                        case "port":
                            txtPort.Text = reader.ReadString();
                            break;

                        case "password":
                            txtPassword.Text = reader.ReadString();
                            break;
                    }
                }
        }
    }
}