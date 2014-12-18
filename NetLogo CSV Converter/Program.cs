using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace NetLogo_CSV_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string[] filePaths = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv");  // get all .csv file files from same dir as this.exe

            // run in parallel mode if there's a command line argument of any sort
            if (args.Length >= 1)
            {
                Parallel.ForEach(filePaths, file =>
                {
                    ProcessFile(file);
                });
            }
            // otherwise run in single threaded mode
            else
            {
                foreach (string file in filePaths)
                {
                    ProcessFile(file);
                }
            }
            Console.WriteLine("Finished reformatting .csv files in {0}", stopwatch.Elapsed);
            stopwatch.Stop();
        }

        private static void ProcessFile(string file)
        {
            // read file
            StreamReader sr = new StreamReader(file);
            string contents = sr.ReadToEnd();
            sr.Close();

            // replace dodgy .csv characters with nothing
            string pattern = @"[\[\] ]";
            Regex rx = new Regex(pattern);
            string newContents = rx.Replace(contents, "");

            // output file
            StreamWriter sw = new StreamWriter(file);
            sw.Write(newContents);
            sw.Close();
        }


    }
}
