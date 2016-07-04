using MySql.Data.MySqlClient;
using System;
using System.Windows;
using static AufträgeOrgadata.Get_set;

namespace AufträgeOrgadata
{
    internal class Main_auftrag
    {
        //Dongle: ReservierteNummer,Zeit,ServerDongle,auto_proglongation,AuftragNR
        //donglestammdaten: DongleID,StammdatenID

        public void Kunde()
        {
            var kd = Application.Current.MainWindow as Kunde;
            var main = Application.Current.MainWindow as MainWindow;
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

            MessageBox.Show(grund.grund);

            var lgn = new login();

            var uid = lgn.lgnList[0].uid;
            var pw = lgn.lgnList[0].pw;
            var server = lgn.lgnList[0].server;
            var port = lgn.lgnList[0].port;
            var db = lgn.lgnList[0].db;

            var connstring = "uid=" + uid + ";" + "password=" + pw + ";" + "server=" + server + ";" + "port=" + port +
                             ";" + "database=" + db + ";";

            var conn = new MySqlConnection(connstring);

            try
            {
                //string name, ort, str, plz, partner, vertrags;
                conn.Open();

                var cmd = new MySqlCommand();
                //Datum,Time,Anliegen,Austausch,Erteilt,Ausgeführt,Post,Anschreiben,Handbuch,AnAdresseName,
                //AnAdresseLand,AnAdresseOrt,AnAdressePartner,AnAdressePLZ,KundenID,ProgrammID,InstallationsartID
                //VersandID,AustattungID,Anhänger,Test,Geprüft,Verschickt,DongleStammdatenID
                var sql =
                    "INSERT INTO auftrag(Datum,Time,Anliegen,Grund,Erteilt,Ausgeführt,Post,Anschreiben,Handbuch,AnAdresseName," +
                    "AnAdresseLand,AnAdresseOrt,AnAdressePartner,AnAdressePLZ,KundenID,ProgrammID,InstallationsartID,VersandID,AusstattungsID," +
                    "Anhänger,Test,Geprüft,Verschickt,DongleStammdatenID)" +
                    "VALUES (?Date,?Time,?Anliegen,?Grund,?Erteilt,?Ausgeführt,?Post,?Anschreiben,?Handbuch,?AnAdresseName," +
                    "?AnAdresseLand,?AnAdresseOrt,?AnAdressePartner,?AnAdressePLZ,?KundenID,?ProgrammID,?InstallationsartID,?VersandID,?AusstattungsID," +
                    "?Anhaenger,?Test,?Geprueft,?Verschickt,?DongleStammdatenID)";
                cmd.CommandText = sql;

                new TKundeAdresse();
                if (cmd.Parameters != null)
                {
                    cmd.Parameters.AddWithValue("?Date", dt.date);
                    cmd.Parameters.AddWithValue("?Time", dt.timer);
                    cmd.Parameters.AddWithValue("?Grund", grund.grund);
                    cmd.Parameters.AddWithValue("?Austausch", grund.austausch);
                    cmd.Parameters.AddWithValue("?Erteilt", auftrag.kuerzel);
                    /*Mit einer kleinen Anwendung*/
                    cmd.Parameters.AddWithValue("?Ausgeführt", ausgefuehrt.kuerzel);
                    /*Mit einer kleinen Anwendung*/
                    cmd.Parameters.AddWithValue("?Post", "1");
                    cmd.Parameters.AddWithValue("?Anschreiben", anschreiben.anschreiben);
                    cmd.Parameters.AddWithValue("?Handbuch", handbuch.handbuch);
                    cmd.Parameters.AddWithValue("?AnAdresseName", anadresse.name);
                    cmd.Parameters.AddWithValue("?AnAdresseLand", "1");
                    cmd.Parameters.AddWithValue("?AnAdresseOrt", anadresse.ort);
                    cmd.Parameters.AddWithValue("?AnAdressePartner", anadresse.ansprechpartner);
                    cmd.Parameters.AddWithValue("?AnAdressePLZ", anadresse.plz);
                    cmd.Parameters.AddWithValue("?KundenID", main.customerid);
                    cmd.Parameters.AddWithValue("?ProgrammID", programms.id);
                    cmd.Parameters.AddWithValue("?InstallationsartID", installart.id);
                    cmd.Parameters.AddWithValue("?VersandID", "1");
                    /* Mehrere möglich */
                    cmd.Parameters.AddWithValue("?AusstattungsID", ausstattung.id);
                    cmd.Parameters.AddWithValue("?Anhaenger", twizt.anhaenger);
                    cmd.Parameters.AddWithValue("?Test", twizt.ewtest);
                    cmd.Parameters.AddWithValue("?Geprueft", "1");
                    cmd.Parameters.AddWithValue("?Verschickt", "1");
                    /* Mehrere möglich */
                    cmd.Parameters.AddWithValue("?DongleStammdatenID", "1");
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