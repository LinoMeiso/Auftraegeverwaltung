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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AufträgeOrgadata
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Program_Loaded(object sender, RoutedEventArgs e)
        {
            ProgrammName programme = new ProgrammName();
            
            for (int i = 0; i < programme.ProgrammListe.Count; i++)
            {
                CheckBox cb = new CheckBox();
                cb.Width = 115;
                cb.Height = 15;
                cb.VerticalAlignment = VerticalAlignment.Top;
                cb.HorizontalAlignment = HorizontalAlignment.Left;
                cb.Content = programme.ProgrammListe[i].Name;
                stackPanelPrograms.Children.Add(cb);
            }

            Installationsart installationsart = new Installationsart();

            for (int i = 0; i < installationsart.Installationsliste.Count; i++)
            {
                CheckBox cb = new CheckBox();
                cb.Width = 200;
                cb.Height = 15;
                cb.VerticalAlignment = VerticalAlignment.Top;
                cb.HorizontalAlignment = HorizontalAlignment.Left;
                cb.Content = installationsart.Installationsliste[i].Installationsart;
                stackPanelInstallation.Children.Add(cb);
            }

            StammName stamm = new StammName();

            for (int i = 0; i < stamm.StammListe.Count; i++)
            {
                CheckBox cb = new CheckBox();
                cb.Width = 200;
                cb.Height = 15;
                cb.VerticalAlignment = VerticalAlignment.Top;
                cb.HorizontalAlignment = HorizontalAlignment.Left;
                cb.Content = stamm.StammListe[i].StammName;
                wpanelStamm.Children.Add(cb);
            }
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Datum und Zeit Ausgabe
            DateTime date = DateTime.Now;
            string date1 = date.ToString();
            string dateOnly = date1.Substring(0, 10);
            string timeOnly = DateTime.Now.ToShortTimeString();

            lblDate.Content = dateOnly;
            lblTime.Content = timeOnly;
        }

        private void txtGrund_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtGrund.Text.Length > 0)
                cbGrund.IsChecked = true;
            else
                cbGrund.IsChecked = false;
        }

        private void txtAustausch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtAustausch.Text.Length > 0)
                cbAustausch.IsChecked = true;
            else
                cbAustausch.IsChecked = false;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close(); //Schließt das Fenster
        }
    }
}
