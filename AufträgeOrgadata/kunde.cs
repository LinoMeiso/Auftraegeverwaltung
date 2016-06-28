using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;
using static AufträgeOrgadata.Kunde;

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

    public class kundecs
    {
        public List<TKunde> KundeListe { get; set; }

        public kundecs()
        {
            KundeListe = new List<TKunde>();
            LoadKunde();
        }

        public void LoadKunde()
        {
            login lgn = new login();

            string uid, pw, server, port, db;
            uid = lgn.lgnList[0].uid;
            pw = lgn.lgnList[0].pw;
            server = lgn.lgnList[0].server;
            port = lgn.lgnList[0].port;
            db = lgn.lgnList[0].db;

            String connstring = "uid=" + uid + ";" + "password=" + pw + ";" + "server=" + server + ";" + "port=" + port + ";" + "database=" + db + ";";
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

        public void EditKunde(TKundeEdit kunde)
        {
            login lgn = new login();

            string uid, pw, server, port, db;
            uid = lgn.lgnList[0].uid;
            pw = lgn.lgnList[0].pw;
            server = lgn.lgnList[0].server;
            port = lgn.lgnList[0].port;
            db = lgn.lgnList[0].db;

            String connstring = "uid=" + uid + ";" + "password=" + pw + ";" + "server=" + server + ";" + "port=" + port + ";" + "database=" + db + ";";

            MySqlConnection conn = new MySqlConnection(connstring);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                string sql = "UPDATE kunden SET Name=?Name,Ort=?Ort,Str=?Str,PLZ=?PLZ,Ansprechpartner=?Ansprechpartner,VertragsNR=?VertragsNr WHERE kunden.ID=?KundeID";
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("?KundeID", kunde.id);
                cmd.Parameters.AddWithValue("?Name", kunde.name);
                cmd.Parameters.AddWithValue("?Ort", kunde.ort);
                cmd.Parameters.AddWithValue("?Str", kunde.str);
                cmd.Parameters.AddWithValue("?PLZ", kunde.plz);
                cmd.Parameters.AddWithValue("?Ansprechpartner", kunde.partner);
                cmd.Parameters.AddWithValue("?VertragsNr", kunde.vertrnr);

                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddKunde(TKundeAdd kunde)
        {
            login lgn = new login();

            string uid, pw, server, port, db;
            uid = lgn.lgnList[0].uid;
            pw = lgn.lgnList[0].pw;
            server = lgn.lgnList[0].server;
            port = lgn.lgnList[0].port;
            db = lgn.lgnList[0].db;

            String connstring = "uid=" + uid + ";" + "password=" + pw + ";" + "server=" + server + ";" + "port=" + port + ";" + "database=" + db + ";";

            MySqlConnection conn = new MySqlConnection(connstring);

            try
            {
                //string name, ort, str, plz, partner, vertrags;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                string sql = "INSERT INTO kunden(name,ort,str,plz,ansprechpartner,vertragsnr) VALUES (?Name,?Ort,?Str,?PLZ,?Ansprechpartner,?VertragsNr)";
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("?Name", kunde.name);
                cmd.Parameters.AddWithValue("?Ort", kunde.ort);
                cmd.Parameters.AddWithValue("?Str", kunde.str);
                cmd.Parameters.AddWithValue("?PLZ", kunde.plz);
                cmd.Parameters.AddWithValue("?Ansprechpartner", kunde.partner);
                cmd.Parameters.AddWithValue("?VertragsNr", kunde.vertrnr);

                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteKunde(TKundeDelete kunde)
        {
            login lgn = new login();

            string uid, pw, server, port, db;
            uid = lgn.lgnList[0].uid;
            pw = lgn.lgnList[0].pw;
            server = lgn.lgnList[0].server;
            port = lgn.lgnList[0].port;
            db = lgn.lgnList[0].db;

            String connstring = "uid=" + uid + ";" + "password=" + pw + ";" + "server=" + server + ";" + "port=" + port + ";" + "database=" + db + ";";

            MySqlConnection conn = new MySqlConnection(connstring);

            try
            {
                //string name, ort, str, plz, partner, vertrags;
                conn.Open();

                //DELETE FROM `kunden` WHERE `kunden`.`ID` = 16 
                MySqlCommand cmd = new MySqlCommand();
                string sql = "DELETE FROM kunden WHERE kunden.ID= ?kundenid";
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("?kundenid", kunde.id);

                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
