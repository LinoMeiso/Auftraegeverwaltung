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
using MySql.Data.MySqlClient;


namespace AufträgeOrgadata
{
    /// <summary>
    /// Interaktionslogik für AusstattungWindow.xaml
    /// </summary>
    public partial class AusstattungWindow : Window
    {
        public AusstattungWindow()
        {
            InitializeComponent();
        }
        public class TAusstattung
        {
            public int ID { get; set; }
            public String AusstattungName { get; set; }
        }
        public class AusstattungCs
        {
            public List<TAusstattung> Ausstattungsliste { get; set; }

            public AusstattungCs()
            {
                Ausstattungsliste = new List<TAusstattung>();
                LoadAusstattung();
            }

            public void LoadAusstattung()
            {
                login lgn = new login();

                string uid, pw, server, port, db, table;
                uid = lgn.lgnList[0].uid;
                pw = lgn.lgnList[0].pw;
                server = lgn.lgnList[0].server;
                port = lgn.lgnList[0].port;
                db = lgn.lgnList[0].db;
                table = lgn.lgnList[0].table;

                String connstring = "uid=" + uid + ";" + "password=" + pw + ";" + "server=" + server + ";" + "port=" + port + ";" + "database=" + db + ";" + "table=" + table + ";";
                MySqlConnection conn = new MySqlConnection(connstring);

                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM ausstattung");
                    cmd.Connection = conn;

                    using (MySqlDataReader Reader = cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                        {

                            TAusstattung Ausstattung = new TAusstattung();
                            Ausstattung.ID = int.Parse(Reader["ID"].ToString());
                            Ausstattung.AusstattungName = Reader["AusstattungName"].ToString();
                            Ausstattungsliste.Add(Ausstattung);
                        }
                    }
                    conn.Close();
                }

                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void AWindow_Loaded(object sender, RoutedEventArgs e)
        {
            AusstattungCs AS = new AusstattungCs();

            for (int i = 0; i < AS.Ausstattungsliste.Count; i++)
            {
                lvAusstattung.Items.Add(new TAusstattung
                {
                    ID = AS.Ausstattungsliste[i].ID,
                    AusstattungName = AS.Ausstattungsliste[i].AusstattungName

                });
            }
        }

        public void mDelete_Click(object sender, RoutedEventArgs e)
        {

            var selectitem = (dynamic)lvAusstattung.SelectedItems[0];

            String connstring = "Server = localhost; database = auftraege; uid = root ";

            MySqlConnection conn = new MySqlConnection(connstring);


            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("Delete from ausstattung where Ausstattung = ?ItemClick");


                cmd.Parameters.AddWithValue("?ItemClick", selectitem.AusstattungName);

                MessageBox.Show("Ausstattung: " + (Convert.ToString(selectitem.AusstattungName) + (" erfolgreich gelöscht!")));


                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }


        }


        private void mAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
