using System;
using System.Collections.Generic;
using System.IO;
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
using PE2.LIB.Helper;

namespace PE2.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static void DoEvents()
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { }));
        }

        private void btnReadCSV_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();

            ofd.DefaultExt = ".csv";
            ofd.Filter = "CSV|*.csv";
            if(ofd.ShowDialog() == true)
            {
                string bestand = ofd.FileName;
                tbKCSV.Text = System.IO.File.ReadAllText(bestand);
            }


        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            tbKRapport.Text = "";
            string inhoud = tbKCSV.Text;
            string[] lijnen = inhoud.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            this.Cursor = Cursors.Wait;
            foreach(string lijn in lijnen)
            {
                ProcessUser(lijn);
                DoEvents();
            }
            this.Cursor = Cursors.Arrow;
        }
        private void ProcessUser(string lijn)
        {
            string[] waarden;
            string[] groepen;

            waarden = lijn.Split(';');
            string username = waarden[0];
            string firstname = waarden[1];
            string lastname = waarden[2];
            string expirationdate = waarden[3];
            string paswoord = waarden[4];
            string ou = waarden[5];
            groepen = waarden[6].Split(',');

            if(ADRef.DoesUserExits(username))
            {
                tbKRapport.Text += $"Updating {username} ... ";
                // pas gebruiker aan

                tbKRapport.Text += $" - {username} succesfully updated\n";  // uiteraard nog aanpassen
            }
            else
            {
                tbKRapport.Text += $"Adding {username} ... ";
                // voeg gebruiker toe

                tbKRapport.Text += $" - {username} succesfully added\n";  // uiteraard nog aanpassen
            }

        }
    }
}
