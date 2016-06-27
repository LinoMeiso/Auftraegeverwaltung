using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace AufträgeOrgadata
{
    public class TKunde
    {
        // ID 	Name 	Ort 	Str 	PLZ 	Ansprechpartner 	VertragsNR
        public int ID { get; set; }
        public string Name { get; set; }
        public string Ort { get; set; }
        public string Str { get; set; }
        public string PLZ { get; set; }
        public string Ansprechpartner { get; set; }
        public string VertragsNr { get; set; } 
    }

    public class kunde
    {
        public List<TKunde> KundeListe { get; set; }

        public kunde()
        {
            KundeListe = new List<TKunde>();
            LoadKunde();
        }

        public void LoadKunde()
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

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM kunden");
                cmd.Connection = conn;

                using (MySqlDataReader Reader = cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {

                        // ID 	Name 	Ort 	Str 	PLZ 	Ansprechpartner 	VertragsNR

                        TKunde kunde = new TKunde();
                        kunde.ID = int.Parse(Reader["ID"].ToString());
                        kunde.Name = Reader["Name"].ToString();
                        kunde.Ort = Reader["Ort"].ToString();
                        kunde.Str = Reader["Str"].ToString();
                        kunde.PLZ = Reader["PLZ"].ToString();
                        kunde.Ansprechpartner = Reader["Ansprechpartner"].ToString();
                        kunde.VertragsNr = Reader["VertragsNr"].ToString();
                        KundeListe.Add(kunde);
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
}
