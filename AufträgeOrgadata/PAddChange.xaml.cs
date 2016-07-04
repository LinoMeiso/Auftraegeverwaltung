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
    /// Interaktionslogik für Kunde.xaml
    /// </summary>
    public partial class PAddChange : Window
    {
        public PAddChange()
        {
            InitializeComponent();
        }
        public class TProgram
        {
            public int ID { get; set; }
            public string ProgrammName { get; set; }

        }

        public class PAddChangeCs
        {
            public List<TProgram> ProgramListe { get; set; }

            public PAddChangeCs()
            {
                ProgramListe = new List<TProgram>();
                LoadProgram();
            }

            public void LoadProgram()
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

                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM programm");
                    cmd.Connection = conn;

                    using (MySqlDataReader Reader = cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                        {

                            TProgram ProgramName = new TProgram();
                            ProgramName.ID = int.Parse(Reader["ID"].ToString());
                            ProgramName.ProgrammName = Reader["ProgrammName"].ToString();
                            ProgramListe.Add(ProgramName);
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
        private void btnEditChange_Click(object sender, RoutedEventArgs e)

        {
            string TextFeldID;
            String TextFeldProgrammName;

            TextFeldID = txtID.ToString();
            TextFeldProgrammName = txtProgramName.ToString();

            string connstring = "Server = localhost; database = auftraege; uid = root ";

            MySqlConnection conn = new MySqlConnection(connstring);

            try
            {
                conn.Open();

              MySqlCommand cmd = new MySqlCommand("Update programmm (?ItemClick) Values (TextFeldProgrammName) ");
                //MySqlCommand cmd = new MySqlCommand("Delete from programm where ID = 50");

                //var selectitem = (dynamic)lvProWindow.SelectedItems[0];
                //cmd.Parameters.AddWithValue("?ItemClick", selectitem.ID);
              

//                MessageBox.Show(Convert.ToString(selectitem.ID));


                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

            this.Close();
        }
        private void mAdd_Click(object sender, RoutedEventArgs e)
        {
            PAddChange EditChange = new PAddChange();
            EditChange.ShowDialog();
        }
    }
}

