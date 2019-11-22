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

namespace Auto_Template_Updater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string TEMPLATES_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\DJL Templates";
        public static Tuple<string, string>[] DOWNLOAD_PATHS = { new Tuple<string, string>("https://github.com/TheWeirdSquid/AutoTemplateUpdaterHosting/blob/master/Davy%20Jones'%20Locker%20Generic%20Document.dotx?raw=true", "Standard.dotx"),
            new Tuple<string, string>("https://github.com/TheWeirdSquid/AutoTemplateUpdaterHosting/blob/master/Generic%20Cover%20Page%20Template%20Latest.dotx?raw=true", "Standard Cover Page.dotx"),
            new Tuple<string, string>("https://github.com/TheWeirdSquid/AutoTemplateUpdaterHosting/blob/master/DJL%20Newsletter%20Template.dotx", "Newsletter Template.dotx")
        };

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
            int i = 1;
            foreach (Tuple<string, string> pathTuple in DOWNLOAD_PATHS)
            {
                statusBox.Text = string.Format("Downloading file {0}/{1}", i, DOWNLOAD_PATHS.Length);
                client.DownloadFile(pathTuple.Item1, TEMPLATES_FOLDER + "\\" + pathTuple.Item2);
                i++;
                
            }
            statusBox.Text = "Download complete.";
        }

        // install fonts
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            // https://stackoverflow.com/questions/21986744/how-to-install-a-font-programmatically-c
        }
    }
}
