using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "cmd.exe";
            info.RedirectStandardInput = true;
            info.UseShellExecute = false;

            p.StartInfo = info;
            p.Start();
            string comanddd = "";
            Console.WriteLine("Mamun");
            comanddd = Console.ReadLine();

            using (StreamWriter sw = p.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    if (comanddd == "write cd")
                    {
                        comanddd = "cd\\";
                    }

                      sw.WriteLine(comanddd);
                    //  sw.WriteLine("mkdir Debdas");
                    p.WaitForExit();
                }
            }
        }


        private void EC(string commandTEXT)
        {
            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "cmd.exe";
            info.RedirectStandardInput = true;
            info.UseShellExecute = false;

            p.StartInfo = info;
            p.Start();

            using (StreamWriter sw = p.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine(commandTEXT);
                    p.WaitForExit();
                }
            }

        }
    }
}
