using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Jekyll.Wordpress.Permalink.Redirect.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || !args.Any())
            {
                throw new ArgumentNullException("args");
            }
            var directory = args[0];

            if (!Directory.Exists(directory))
            {
                throw new ArgumentException(string.Format("The directory '{0}' does not exist", directory), "args");
            }

            var files = Directory.GetFiles(directory, "*.html");

            Console.WriteLine(string.Format("Found {0} html files.", files.Count()));

            if (!files.Any())
            {
                return;
            }

            Console.WriteLine("Press any key to start processing files");
            Console.ReadKey(true);

            Array.ForEach(files, AddRedirect);
        }

        private static readonly Regex PostNameRegex = new Regex(@"(?<year>\d{4})-(?<month>\d{2})-(?<day>\d{2})-(?<slug>.*)");

        private static void AddRedirect(string filePath)
        {
            var postName = Path.GetFileNameWithoutExtension(filePath);

            var match = PostNameRegex.Match(postName);
            var year = match.Groups["year"].Value;
            var month = match.Groups["month"].Value;
            var day = match.Groups["day"].Value;
            var slug = match.Groups["slug"].Value;

            var redirect = string.Format("/index.php/{0}/{1}/{2}/{3}/", year, month, day, slug);

            Encoding encoding;
            string contents;
            using (var reader = new StreamReader(filePath))
            {
                contents = reader.ReadToEnd();
                encoding = reader.CurrentEncoding;
            }

            contents = contents.Replace("published: true", string.Format("redirect_from: {0}\r\npublished: true", redirect));

            File.WriteAllText(filePath, contents, new UTF8Encoding(false));
        }
    }
}
