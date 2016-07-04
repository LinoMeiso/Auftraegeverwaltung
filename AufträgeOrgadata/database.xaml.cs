using System.Windows;
using System.Xml.Linq;

namespace AufträgeOrgadata
{
    /// <summary>
    /// Interaktionslogik für database.xaml
    /// </summary>
    public partial class database
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
            var uid = txtUid.Text;
            var pw = txtPassword.Text;
            var server = txtServer.Text;
            var port = txtPort.Text;
            var database = txtDatabase.Text;

            XElement n = new XElement("AufträgeOrgadata",
                new XElement("login",
                new XElement("username", uid),
                new XElement("password", pw),
                new XElement("server", server),
                new XElement("port", port),
                new XElement("database", database)));

            n.Save("login.xml");

            Close();
        }
    }
}