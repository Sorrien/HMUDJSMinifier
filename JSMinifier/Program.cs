using System;
using System.IO;
using System.Configuration;

namespace JSMinifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string hackmud = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\hackmud\";
            string[] directories = Directory.GetDirectories(hackmud);
            string path = "";
            string input = "";
            if (directories.Length > 1)
            {
                while (path == "")
                {
                    for (int i = 0; i < directories.Length; i++)
                    {
                        string user = directories[i];

                        Console.WriteLine(i + directories[i]);
                    }
                    input = Console.ReadLine();
                    int index = -1;
                    int.TryParse(input, out index);
                    if (index >= 0)
                    {
                        path = directories[index];
                    }
                    else
                    {
                        Console.WriteLine("Please choose a valid index.");
                    }
                }
            }
            else
            {
                path = directories[0];
            }
            string originalFileName = "";
            string source = "";
            JSFileHelper fileHelper = new JSFileHelper(path + @"\scripts\");
            while (source == "" || source == null)
            {
                Console.WriteLine("Please enter the name of the script you wish to minify.");
                originalFileName = Console.ReadLine();
                if (originalFileName == "")
                {
                    originalFileName = ConfigurationManager.AppSettings["DefaultScript"];
                }

                try
                {
                    source = fileHelper.GetSource(originalFileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            HackMudMinifier minifier = new HackMudMinifier();
            string minifiedSource = minifier.MinifyHackMudJavaScript(source);

            if (minifier.ErrorList.Count > 0)
            {
                foreach (var error in minifier.ErrorList)
                {
                    Console.Error.WriteLine(error.ToString());
                }
            }
            else
            {
                try
                {
                    fileHelper.SaveToHackmud(originalFileName, minifiedSource);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Success");
            }
            Console.ReadLine();
        }
    }
}

