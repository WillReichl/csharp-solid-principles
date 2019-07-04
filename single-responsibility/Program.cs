using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace single_responsibility
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;
        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento pattern -- will look at this later in course
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        // Move persistence to it's own class, that has one responsibility
    }

    public class Persistence 
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || File.Exists(filename))
                File.WriteAllText(filename, j.ToString());
        }

        public static Journal Load(string filename)
        {
            return null;
        }

        public static Journal Load(Uri uri)
        {
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("dear diary, i love design patterns");
            j.AddEntry("dear diary, i might be a nerd");
            Console.WriteLine(j);

            var p = new Persistence();
            var filename = @"c:\temp\journal.txt";
            p.SaveToFile(j, filename, true);
            // Process.Start(filename);
        }
    }
}
