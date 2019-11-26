using System;
using System.IO;
using System.Collections.Generic;

namespace Background_Document_Updater
{
    class Program
    {
        public static string TEMPLATES_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\DJL Templates";
        static void Main(string[] args)
        {
            System.IO.Directory.CreateDirectory(TEMPLATES_FOLDER);
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

            foreach (Tuple<string, string> pathTuple in downloadPaths)
            {
                client.DownloadFile(pathTuple.Item1, TEMPLATES_FOLDER + "\\" + pathTuple.Item2);
            }
        }
    }
}
