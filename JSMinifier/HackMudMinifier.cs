using System.Linq;
using Microsoft.Ajax.Utilities;
using System.Text.RegularExpressions;

namespace JSMinifier
{
    class HackMudMinifier : Minifier
    {
        public string[] Scriptors;
        public HackMudMinifier()
        {

        }
        public string MinifyHackMudJavaScript(string source)
        {
            source = CleanScriptors(source);
            source = base.MinifyJavaScript(source);
            source = RestoreScriptors(source);
            return source;
        }
        public string CleanScriptors(string source)
        {
            if (source.Contains("#"))
            {
                //string[] Scriptors = ConfigurationManager.AppSettings["ScriptorsToRemove"].Split(';');

                Regex r = new Regex(Regex.Escape("#") + "(.*?)" + Regex.Escape("("));
                Scriptors = r.Matches(source).OfType<Match>()
               .Select(m => m.Value)
               .Distinct()
               .ToArray();
                foreach (string filter in Scriptors)
                {
                    string noSymbolFilter = filter.Replace("#", "");
                    if (filter != "")
                        source = source.Replace(filter, noSymbolFilter);
                }
            }
            source = source.Replace("(context,args)", "test()");
            source = source.Replace("(context, args)", "test()");
            source = source.Replace("(c, a)", "test()");

            return source;
        }
        public string RestoreScriptors(string source)
        {
            //string[] filters = ConfigurationManager.AppSettings["ScriptorsToRemove"].Split(';');
            foreach (string filter in Scriptors)
            {
                string noSymbolFilter = filter.Replace("#", "");
                if (filter != "")
                    source = source.Replace(noSymbolFilter, filter);
            }
            source = source.Replace("test()", "(c,a)");
            return source;
        }
    }
}
