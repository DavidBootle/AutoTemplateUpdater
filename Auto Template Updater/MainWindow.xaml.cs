﻿using System;
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

        public MainWindow()
        {
            System.IO.Directory.CreateDirectory(TEMPLATES_FOLDER);
            InitializeComponent();
        }

        // Open Templates Folder
        private void Button_Click(object sender, RoutedEventArgs e)
        {
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

        }
    }
}