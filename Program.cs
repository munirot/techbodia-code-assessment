using System;
using System.Text.RegularExpressions;

namespace notificationParser
{
    class Program
    {
        static void Main(String[] args)
        {

            // define valid tags declaration Backend (BE), Frontend (FE), Quality Assurance (QA), and Urgent (Urgent)
            HashSet<String> validTags = new HashSet<string> { "BE", "FE", "QA", "Urgent" };

            // input stirng
            Console.WriteLine("Notification Title: ");
            string input = Console.ReadLine();

            // check and validate the input
            string results = NotificationPaser(input, validTags);
            Console.WriteLine(results);
            Console.ReadKey();
        }

        static string NotificationPaser(string title, HashSet<string> validTags)
        {
            // define regular expression to extract tags in square brackets
            var regex = new Regex(@"\[([^\]]+)\]");
            // check if the title match with the expression
            var matches = regex.Matches(title);

            // get the valid tags by first get the content from the [] then filter only valid tags
            var tags = matches.Select(m => m.Groups[1].Value).Where(tag => validTags.Contains(tag));

            // return the output
            return tags.Any() ? $"Receive channels: {string.Join(", ", tags)}" : "No valid channels found";
        }
    }
}