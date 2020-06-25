using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CloudCommerceGroup
{
    public static class FileHelpers
    {
        public static string[] ReadLines(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException($"{nameof(filePath)} is empty");
            }

            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length < 2)
            {
                throw new ArgumentException($"{nameof(filePath)}:{filePath} is not valid. At least two lines are required.");
            }

            return lines;
        }

        public static string ReadAllExceptHeaders(string[] lines)
        {
            var contents = new StringBuilder();
            for (int i = 1; i < lines.Count(); i++)
            {
                contents.Append(lines[i]);
            }

            return contents.ToString();
        }
    }
}