using System;
using System.Collections.Generic;
using System.Windows;
using MySql.Data.MySqlClient;

namespace AufträgeOrgadata
{
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
            public string Ausstatung { get; internal set; }
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
                
                string uid = lgn.lgnList[0].uid;
                string pw = lgn.lgnList[0].pw;
                string server = lgn.lgnList[0].server;
                string port = lgn.lgnList[0].port;
                string db = lgn.lgnList[0].db;
                string table = lgn.lgnList[0].table;

                var connstring = "uid=" + uid + ";" + "password=" + pw + ";" + "server=" + server + ";" + "port=" + port + ";" + "database=" + db + ";" + "table=" + table + ";";
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
            LoadData();
        }

        private void LoadData()
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
            var connstring = "Server = localhost; database = auftraege; uid = root ";
            MySqlConnection conn = new MySqlConnection(connstring);
            
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Delete from ausstattung where AusstattungnAME = ?ItemClick");
                
                cmd.Parameters.AddWithValue("?ItemClick", selectitem.AusstattungName);

                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                conn.Close();
                lvAusstattung.Items.Clear();
                LoadData();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        
        private void mAdd_Click(object sender, RoutedEventArgs e)
        {
            AddAusstattung addAusstattungWindow = new AddAusstattung();
            addAusstattungWindow.ShowDialog();
        }

        private void mEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mClose_Click(object sender, RoutedEventArgs e)
        {
           Close();
        }
    }
}