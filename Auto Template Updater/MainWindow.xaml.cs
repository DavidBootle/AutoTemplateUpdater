using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace Auto_Template_Updater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string TEMPLATES_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\DJL Templates";

        public MainWindow()
        {
            System.IO.Directory.CreateDirectory(TEMPLATES_FOLDER);
            InitializeComponent();
        }

        // Open Templates Folder
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            statusBox.Text = "";
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo.FileName = "explorer.exe";
            startInfo.Arguments = "\"C:\\Users\\lab\\Documents\\DJL Templates\"";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void Download_Button_Click(object sender, RoutedEventArgs e)
        {
            statusBox.Text = "";
            System.Net.WebClient client = new System.Net.WebClient();

            client.DownloadFile("https://github.com/TheWeirdSquid/AutoTemplateUpdaterHosting/blob/master/download_urls.txt?raw=true", TEMPLATES_FOLDER + "\\urls.txt");
            string line;
            List<Tuple<string, string>> downloadPathsList = new List<Tuple<string, string>>();
            StreamReader file = new StreamReader(TEMPLATES_FOLDER + "\\urls.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] strings = line.Split('|');
                Tuple<string, string> downloadTuple = new Tuple<string, string>(strings[0], strings[1]);
                downloadPathsList.Add(downloadTuple);
            }
            file.Close();
            File.Delete(TEMPLATES_FOLDER + "\\urls.txt");
            Tuple<string, string>[] downloadPaths = downloadPathsList.ToArray();

            int i = 1;
            foreach (Tuple<string, string> pathTuple in downloadPaths)
            {
                statusBox.Text = string.Format("Downloading file {0}/{1}", i, downloadPaths.Length);
                client.DownloadFile(pathTuple.Item1, TEMPLATES_FOLDER + "\\" + pathTuple.Item2);
                i++;
                
            }
            statusBox.Text = "Download complete.";
        }
    }
}
