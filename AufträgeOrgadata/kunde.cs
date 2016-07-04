using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

    public class TKundeFind
    {
        public int IDFind { get; set; }
        public string NameFind { get; set; }
        public string OrtFind { get; set; }
        public string StrFind { get; set; }
        public string PLZFind { get; set; }
        public string AnsprechpartnerFind { get; set; }
        public string VertragsNrFind { get; set; }
    }

    public class kundecs
    {
        public List<TKunde> KundeListe { get; set; }
        public List<TKundeFind> KundeFindList { get; set; }

        public kundecs()
        {
            KundeFindList = new List<TKundeFind>();
            KundeListe = new List<TKunde>();
            LoadKunde();
        }

        public void LoadKunde()
        {
            login lgn = new login();

            var uid = lgn.lgnList[0].uid;
            var pw = lgn.lgnList[0].pw;
            var server = lgn.lgnList[0].server;
            var port = lgn.lgnList[0].port;
            var db = lgn.lgnList[0].db;

            string connstring = "uid=" + uid + ";" + "password=" + pw + ";" + "server=" + server + ";" + "port=" + port + ";" + "database=" + db + ";";
            MySqlConnection conn = new MySqlConnection(connstring);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM kunden") { Connection = conn };

                using (MySqlDataReader Reader = cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        TKunde kunde = new TKunde
                        {
                            ID = int.Parse(Reader["ID"].ToString()),
                            Name = Reader["Name"].ToString(),
                            Ort = Reader["Ort"].ToString(),
                            Str = Reader["Str"].ToString(),
                            PLZ = Reader["PLZ"].ToString(),
                            Ansprechpartner = Reader["Ansprechpartner"].ToString(),
                            VertragsNr = Reader["VertragsNr"].ToString()
                        };
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

            var uid = lgn.lgnList[0].uid;
            var pw = lgn.lgnList[0].pw;
            var server = lgn.lgnList[0].server;
            var port = lgn.lgnList[0].port;
            var db = lgn.lgnList[0].db;

            string connstring = "uid=" + uid + ";" + "password=" + pw + ";" + "server=" + server + ";" + "port=" + port + ";" + "database=" + db + ";";

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

            var uid = lgn.lgnList[0].uid;
            var pw = lgn.lgnList[0].pw;
            var server = lgn.lgnList[0].server;
            var port = lgn.lgnList[0].port;
            var db = lgn.lgnList[0].db;

            string connstring = "uid=" + uid + ";" + "password=" + pw + ";" + "server=" + server + ";" + "port=" + port + ";" + "database=" + db + ";";
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

            var uid = lgn.lgnList[0].uid;
            var pw = lgn.lgnList[0].pw;
            var server = lgn.lgnList[0].server;
            var port = lgn.lgnList[0].port;
            var db = lgn.lgnList[0].db;

            string connstring = "uid=" + uid + ";" + "password=" + pw + ";" + "server=" + server + ";" + "port=" + port + ";" + "database=" + db + ";";

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

        public void SearchKunde(TKundeSearch kunde)
        {
            login lgn = new login();

            var uid = lgn.lgnList[0].uid;
            var pw = lgn.lgnList[0].pw;
            var server = lgn.lgnList[0].server;
            var port = lgn.lgnList[0].port;
            var db = lgn.lgnList[0].db;

            var connstring = "uid=" + uid + ";" + "password=" + pw + ";" + "server=" + server + ";" + "port=" + port + ";" + "database=" + db + ";";

            MySqlConnection conn = new MySqlConnection(connstring);

            try
            {
                //string name, ort, str, plz, partner, vertrags;
                conn.Open();

                //DELETE FROM `kunden` WHERE `kunden`.`ID` = 16
                // name=?Name, ort=?Ort, str=?Str, plz=?PLZ, ansprechpartner=?Ansprechpartner, vertragsnr=?VertragsNr
                MySqlCommand cmd = new MySqlCommand();
                string sql = "SELECT * FROM kunden WHERE name LIKE ?Name OR ort LIKE ?Ort OR str LIKE ?Str OR plz LIKE ?PLZ OR ansprechpartner LIKE ?Ansprechpartner OR vertragsnr LIKE ?VertragsNr";
                cmd.CommandText = sql;

                if (string.IsNullOrWhiteSpace(kunde.name))
                    cmd.Parameters.AddWithValue("?Name", "");
                else
                    cmd.Parameters.AddWithValue("?Name", "%" + kunde.name + "%");

                if (string.IsNullOrWhiteSpace(kunde.ort))
                    cmd.Parameters.AddWithValue("?Ort", "");
                else
                    cmd.Parameters.AddWithValue("?Ort", "%" + kunde.ort + "%");

                if (string.IsNullOrWhiteSpace(kunde.str))
                    cmd.Parameters.AddWithValue("?Str", "");
                else
                    cmd.Parameters.AddWithValue("?Str", "%" + kunde.str + "%");

                if (string.IsNullOrWhiteSpace(kunde.plz))
                    cmd.Parameters.AddWithValue("?PLZ", "");
                else
                    cmd.Parameters.AddWithValue("?PLZ", "%" + kunde.plz + "%");

                if (string.IsNullOrWhiteSpace(kunde.partner))
                    cmd.Parameters.AddWithValue("?Ansprechpartner", "");
                else
                    cmd.Parameters.AddWithValue("?Ansprechpartner", "%" + kunde.partner + "%");

                if (string.IsNullOrWhiteSpace(kunde.vertrnr))
                    cmd.Parameters.AddWithValue("?VertragsNr", "");
                else
                    cmd.Parameters.AddWithValue("?VertragsNr", "%" + kunde.vertrnr + "%");

                cmd.Connection = conn;

                using (MySqlDataReader Reader = cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        // ID 	Name 	Ort 	Str 	PLZ 	Ansprechpartner 	VertragsNR
                        TKundeFind kdfind = new TKundeFind
                        {
                            IDFind = int.Parse(Reader["ID"].ToString()),
                            NameFind = Reader["Name"].ToString(),
                            OrtFind = Reader["Ort"].ToString(),
                            StrFind = Reader["Str"].ToString(),
                            PLZFind = Reader["PLZ"].ToString(),
                            AnsprechpartnerFind = Reader["Ansprechpartner"].ToString(),
                            VertragsNrFind = Reader["VertragsNr"].ToString()
                        };
                        KundeFindList.Add(kdfind);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}