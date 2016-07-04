using System.Windows;

namespace AufträgeOrgadata
{
    /// <summary>
    /// Interaktionslogik für add_edit.xaml
    /// </summary>
    public partial class add_edit
    {
        public add_edit()
        {
            InitializeComponent();
        }

        public class TAdEdKunde
        {
            public string Name { get; set; }
            public string Ort { get; set; }
            public string Str { get; set; }
            public string PLZ { get; set; }
            public string Ansprechpartner { get; set; }
            public string VertragsNr { get; set; }
        }

        public void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}