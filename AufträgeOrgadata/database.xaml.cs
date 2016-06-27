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
using System.Xml.Linq;
using System.IO;

namespace AufträgeOrgadata
{
    /// <summary>
    /// Interaktionslogik für database.xaml
    /// </summary>
    public partial class database : Window
    {
        public database()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            string uid, pw, server, port, database, table;

            uid = txtUid.Text;
            pw = txtPassword.Text;
            server = txtServer.Text;
            port = txtPort.Text;
            database = txtDatabase.Text;
            table = txtTable.Text;

            XElement n = new XElement("AufträgeOrgadata",
                new XElement("Username",uid),
                new XElement("Password", pw),
                new XElement("Server", server),
                new XElement("Port", port),
                new XElement("Database", database),
                new XElement("Table",table));

        }
    }
}
