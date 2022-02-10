using System;
using System.IO;
using System.Threading;

namespace TextLineContain
{
    class Program
    {
        static void Main(string[] args)
        {

            if (!Directory.Exists(@"data"))
                Directory.CreateDirectory(@"data");

            if (!File.Exists(@"data\fulls.txt"))
                File.Create(@"data\fulls.txt").Close();

            if (!File.Exists(@"data\lines.txt"))
                File.Create(@"data\lines.txt").Close();

            string[] fulls = File.ReadAllLines(@"data\fulls.txt");
            string[] lines = File.ReadAllLines(@"data\lines.txt");


            if(fulls.Length > 0 && lines.Length > 0)
            {
                foreach (string line in lines)
                {
                    string dataFull = string.Empty;
                    bool isContain = false;
                    foreach (string full in fulls)
                    {
                        if(full.Contains(line))
                        {
                            using (StreamWriter sw = File.AppendText(@"data\contain.txt"))
                                sw.WriteLine(full);

                            isContain = true;

                            break;
                        }
                        dataFull = full;
                    }

                    if(!isContain)
                    {
                        using (StreamWriter sw = File.AppendText(@"data\not_contain.txt"))
                            sw.WriteLine(dataFull);
                    }    
                }
            }

            Console.WriteLine("Hoan thanh");

            Console.ReadKey();
        }
    }
}
