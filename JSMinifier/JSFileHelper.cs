using System.Configuration;
using System.IO;

namespace JSMinifier
{
    

    class JSFileHelper
    {
        private string scriptsPath;
        private string hackmudScriptsPath;
        public JSFileHelper(string path)
        {
            scriptsPath = ConfigurationManager.AppSettings["ScriptsPath"];
            hackmudScriptsPath = path;
        }
        public string GetSource(string fileName)
        {
            string path = scriptsPath + fileName + ".js";
            string source = File.ReadAllText(path);
            return source;
        }
        public void SaveToHackmud(string fileName, string source)
        {
            string ResultFileName = fileName + ConfigurationManager.AppSettings["MinifiedIdentifier"] + ".js";
            File.WriteAllText(hackmudScriptsPath + @"\" + ResultFileName, source);
        }
    }
}
