using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace StringsAndCharacterEncodings
{
    class Program
    {
        static void Main(string[] args)
        {
            string Title = string.Format("| Pub Date   |                     Title | Authors                   |\n|====================================================================|");
            Console.WriteLine(Title);

            using (var sr = new StreamReader("../csvdata.csv"))
            {
                var reader = new CsvReader(sr);
                IEnumerable<DataRecord> records = reader.GetRecords<DataRecord>();
                foreach (var record in records)
                {
                    string pubDate = record.PublicationDate.ToString("dd/MM/yyyy");
                    string title = record.Title;
                    string author = record.Authors;

                    if (title.Length < 25 && author.Length < 25)
                    {
                        Console.WriteLine(string.Format("| {0,-10} | {1,-25} | {2,5} |", pubDate, title, author));
                    }
                    else if (title.Length < 25 && author.Length >= 25)
                    {
                        Console.WriteLine(string.Format("| {0,-10} | {1,-25} | {2,5} |", pubDate, title, author.Substring(0, 25)));
                    }
                    else if (title.Length >= 25 && author.Length < 25)
                    {
                        Console.WriteLine(string.Format("| {0,-10} | {1,-25} | {2,-25} |", pubDate, title.Substring(0, 25), author));
                    }
                    else
                    {
                        Console.WriteLine(string.Format("| {0,-10} | {1,-25} | {2,5} |", pubDate, title.Substring(0, 25), author.Substring(0, 25)));
                    }
                   

                }
            }
            Console.ReadLine();
        }
    }
}

