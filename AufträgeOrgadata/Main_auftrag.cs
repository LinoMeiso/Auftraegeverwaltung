using System;
using MySql.Data.MySqlClient;
using static AufträgeOrgadata.Get_set;
using System.Windows;

namespace AufträgeOrgadata
{
    class Main_auftrag
    {
        //Dongle: ReservierteNummer,Zeit,ServerDongle,auto_proglongation,AuftragNR
        //donglestammdaten: DongleID,StammdatenID
        private TLastIdentityDongle lastdongle;
        private Tstamm stamm = null;

        public Get_set.TLastIdentityDongle GetLastDongle()
        {
            return lastdongle;
        }

        public Get_set.Tstamm GetStammSet()
        {
            return stamm;
        }

        //4.
        public void Kunde()
        {
            Kunde kd = Application.Current.MainWindow as Kunde;
            MainWindow main = Application.Current.MainWindow as MainWindow;
            if (main == null) return;
            var dt = main.GetDateTimeSet();
            var grund = main.GetGrundSet();
            var auftrag = main.GetAuftragSet();
            var ausgefuehrt = main.GetAusgefuehrtSet();
            var anschreiben = main.GetAnschreibenSet();
            var handbuch = main.GetHandbuchSet();
            var anadresse = main.GetAnAdresseSet();
            var programms = main.GetProgrammsSet();
            var installart = main.GetInstallArtSet();
            var ausstattung = main.GetAusstattungSet();
            var twizt = main.GetTwiztSet();
            var ldongle = GetLastDongle();
            
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
                conn.Open();
                
                MySqlCommand cmd = new MySqlCommand();
                string sql = "INSERT INTO auftrag(Datum,Time,Anliegen,Grund,Erteilt,Ausgeführt,Post,Anschreiben,Handbuch,AnAdresseName," +
                             "AnAdresseLand,AnAdresseOrt,AnAdressePartner,AnAdressePLZ,KundenID,ProgrammID,InstallationsartID,VersandID,AusstattungsID," +
                             "Anhänger,Test,Geprüft,Verschickt,DongleID)" +
                             "VALUES (?Date,?Time,?Anliegen,?Grund,?Erteilt,?Ausgeführt,?Post,?Anschreiben,?Handbuch,?AnAdresseName," +
                             "?AnAdresseLand,?AnAdresseOrt,?AnAdressePartner,?AnAdressePLZ,?KundenID,?ProgrammID,?InstallationsartID,?VersandID,?AusstattungsID," +
                             "?Anhaenger,?Test,?Geprueft,?Verschickt,?DongleID)";
                cmd.CommandText = sql;
                
                TKundeAdresse kdadresse = new TKundeAdresse();
                cmd.Parameters.AddWithValue("?Date", dt.date);
                cmd.Parameters.AddWithValue("?Time", dt.timer);
                cmd.Parameters.AddWithValue("?Grund", grund.grund);
                cmd.Parameters.AddWithValue("?Austausch", grund.austausch);
                cmd.Parameters.AddWithValue("?Erteilt", auftrag.kuerzel);
                ///*Mit einer kleinen Anwendung*/cmd.Parameters.AddWithValue("?Ausgeführt", ausgefuehrt.kuerzel);
                ///*Mit einer kleinen Anwendung*/cmd.Parameters.AddWithValue("?Post", "1");
                cmd.Parameters.AddWithValue("?Anschreiben", anschreiben.anschreiben);
                cmd.Parameters.AddWithValue("?Handbuch", handbuch.handbuch);
                cmd.Parameters.AddWithValue("?AnAdresseName", anadresse.name);
                cmd.Parameters.AddWithValue("?AnAdresseStr", anadresse.str);
                cmd.Parameters.AddWithValue("?AnAdresseOrt", anadresse.ort);
                cmd.Parameters.AddWithValue("?AnAdressePartner", anadresse.ansprechpartner);
                cmd.Parameters.AddWithValue("?AnAdressePLZ", anadresse.plz);
                cmd.Parameters.AddWithValue("?KundenID", main.customerid);
                cmd.Parameters.AddWithValue("?ProgrammID", programms.id);
                cmd.Parameters.AddWithValue("?InstallationsartID", installart.id);
                cmd.Parameters.AddWithValue("?VersandID", "1");
                ///* Mehrere möglich */cmd.Parameters.AddWithValue("?AusstattungsID", ausstattung.id);
                cmd.Parameters.AddWithValue("?Anhaenger", twizt.anhaenger);
                cmd.Parameters.AddWithValue("?Test", twizt.ewtest);
                cmd.Parameters.AddWithValue("?Geprueft", 1);
                cmd.Parameters.AddWithValue("?Verschickt", 1);
                cmd.Parameters.AddWithValue("?DongleID", ldongle.id);

                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //1.
        public void dongle()
        {
            Get_set.TVNummer vnummer = null;

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
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                string sql = "INSERT INTO dongle(ReservierteNummer1, ReservierteNummer2, ReservierteNummer3, Zeit, ServerDongle, autoprolongation)" +
                             "VALUES(?RNummer1,?RNummer2,?RNummer3,?Zeit,?ServerDongle,?autoprolo)";
                cmd.CommandText = sql;
                
                cmd.Parameters.AddWithValue("?RNummer1", vnummer.rnummer);
                cmd.Parameters.AddWithValue("?RNummer2", vnummer.rnummer2);
                cmd.Parameters.AddWithValue("?RNummer3", vnummer.rnumemr3);
                cmd.Parameters.AddWithValue("?Zeit", vnummer.zeitdongle);
                cmd.Parameters.AddWithValue("?ServerDongle", vnummer.serverdongle);
                cmd.Parameters.AddWithValue("?autoprolo", vnummer.autopro);
                
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //2.
        public void dongleIndetity()
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
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                string sql = "SELECT LAST_INSERT_ID() FROM dongle";
                cmd.CommandText = sql;
                
                cmd.Connection = conn;
                using (MySqlDataReader Reader = cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        lastdongle = new TLastIdentityDongle {id = int.Parse(Reader["ID"].ToString())};
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //3.
        public void donglestamm()
        {
            Get_set.Tstamm stamm = null;
            Get_set.TAusstattung_Data ausstattung = null;

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

                string sql = "INSERT INTO donglestammdaten(DongleID,StammdatenID,AusstattungID) VALUES (?DonlgeID,?StammdatenID,?AusstattungID)";
                cmd.CommandText = sql;
                
                Get_set.TLastIdentityDongle ldongle = GetLastDongle();
                for (var i = 0; i < stamm.StammListUebergabe.Count; i++)
                {
                    cmd.Parameters.AddWithValue("?DongleID", ldongle.id);
                    cmd.Parameters.AddWithValue("?StammdatenID", stamm.id);
                    cmd.Parameters.AddWithValue("?AusstattungID",ausstattung.id);
                }

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