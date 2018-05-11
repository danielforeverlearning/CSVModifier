using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSV_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 0-based index in comma delimitted file to change:");
            string targetindexstr = Console.ReadLine();
            int targetindex = int.Parse(targetindexstr);

            Console.WriteLine("Enter new string to place into index:");
            string outputstr = Console.ReadLine();

            Console.WriteLine("Enter input filename path:");
            string inputfilepath = Console.ReadLine();

            Console.WriteLine("Enter output filename path:");
            string outputfilepath = Console.ReadLine();

            StreamReader readstream = new StreamReader(inputfilepath);
            readstream.ReadLine(); //ignore 1st line, name of column headers

            StreamWriter writestream = new StreamWriter(outputfilepath);


            char delimiter = ',';
            string line = readstream.ReadLine();
            while (line != null)
            {
                string[] substrings = line.Split(delimiter);
                for (int ii=0; ii < substrings.Length; ii++)
                {
                    if (ii == targetindex)
                        writestream.Write(outputstr);
                    else
                        writestream.Write(substrings[ii]);

                    if (ii != (substrings.Length - 1))
                        writestream.Write(",");
                }
                writestream.WriteLine();

                line = readstream.ReadLine();
            }

            readstream.Close();
            writestream.Close();
            Console.WriteLine("DONE");
        }
    }
}
