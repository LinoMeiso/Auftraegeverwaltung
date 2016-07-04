namespace AufträgeOrgadata
{
    public class Kunde_anadresse
    {
        //private class Date
        //{
        //    //Datum und Zeit Ausgabe
        //    //DateTime date = DateTime.Now;
        //    //string date1 = date.ToString();
        //    //string dateOnly = date1.Substring(0, 10);
        //    //string timeOnly = DateTime.Now.ToShortTimeString();
        //}

        //public Kunde_anadresse()
        //{
        //    Kunde();
        //}

        //private void Kunde()
        //{
        //    login lgn = new login();

        //    string uid, pw, server, port, db;
        //    uid = lgn.lgnList[0].uid;
        //    pw = lgn.lgnList[0].pw;
        //    server = lgn.lgnList[0].server;
        //    port = lgn.lgnList[0].port;
        //    db = lgn.lgnList[0].db;

        //    String connstring = "uid=" + uid + ";" + "password=" + pw + ";" + "server=" + server + ";" + "port=" + port + ";" + "database=" + db + ";";

        //    MySqlConnection conn = new MySqlConnection(connstring);

        //    try
        //    {
        //        //string name, ort, str, plz, partner, vertrags;
        //        conn.Open();

        //        MySqlCommand cmd = new MySqlCommand();
        //        string sql = "INSERT INTO auftrag(KundenID) VALUES (?ID)";
        //        cmd.CommandText = sql;

        //        Kunde kd = new Kunde();
        //        Get_set.TGetCustomer customer = kd.GetCustomerSet();

        //        TKundeAdresse kdadresse = new TKundeAdresse();
        //        cmd.Parameters.AddWithValue("?ID",customer.id);

        //        cmd.Connection = conn;
        //        cmd.ExecuteNonQuery();

        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}