using System;
using System.Windows;
using MySql.Data.MySqlClient;

namespace AufträgeOrgadata
{
    /// <summary>
    /// Interaction logic for AddAusstattung.xaml
    /// </summary>
    public partial class AddAusstattung : Window
    {
        public AddAusstattung()
        {
            InitializeComponent();
        }

        private void btnEditChange_Click(object sender, RoutedEventArgs e)
        {
            string TextAusstattung;

            TextAusstattung = txtAusstattung.Text;
            string connstring = "Server = localhost; database = auftraege; uid = root ";
            MySqlConnection connection = new MySqlConnection(connstring);
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO ausstattung (Ausstattungname) VALUES (?Ausstattungsnamename)";
                command.Parameters.AddWithValue("?Ausstattungsnamename", TextAusstattung);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

            this.Close();
        }
    }
}
