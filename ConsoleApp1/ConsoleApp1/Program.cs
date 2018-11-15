using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args) {
            //   nlpData();

               nlpCMD();

            //var items = "A B A D A C".Split(' ');
            //var unique_items = new HashSet<string>(items);
            //foreach (string s in unique_items)
            //    Console.WriteLine(s);
            //Console.ReadLine();

            //Training training = new Training();

            //Console.ReadLine();
        }

        static void nlpCMD()
        {

            NLP nLP = new NLP();
            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "cmd.exe";
            info.RedirectStandardInput = true;
            info.UseShellExecute = false;

            p.StartInfo = info;
            p.Start();
            string comanddd = "";
          //  Console.WriteLine("Mamun");



            using (StreamWriter sw = p.StandardInput)
            {
                while (true)
                {
                    comanddd = Console.ReadLine();
                    string[] splitString = comanddd.Split("#");
                  //  Console.WriteLine(splitString.Length.ToString());
                    if (splitString.Length > 1)
                    {
                        comanddd = nLP.getAnswer(splitString[0].Trim());
                        comanddd = comanddd.Trim() + " " + splitString[1].Trim();
                    }
                    else
                    {
                        comanddd = nLP.getAnswer(comanddd);
                    }
                    if (sw.BaseStream.CanWrite)
                    {

                        sw.WriteLine(comanddd);
                        //  sw.WriteLine("mkdir Debdas");
                        //p.WaitForExit();
                    }
                }
            }
        }
        static void nlpData()
        {

            NLP nLP = new NLP();
            // nLP.vocabulary();
            //foreach (var item in nLP.SplitQuestioAnswer())
            //{
            //    Console.WriteLine(item[0]);
            //    Console.WriteLine(item[1]);
            //};
            //foreach (var item in nLP.KeyWords())
            //{
            //    Console.WriteLine(item[0]);
            //    Console.WriteLine(item[1]);
            //};
            //for (int i = 0; i < nLP.vocabulary().Length; i++)
            //{
            //    Console.WriteLine(i + ":" + nLP.vocabulary()[i]);
            //} 
            // string wmatrix = "";
            // for (int i = 0; i < nLP.wordToMatrix().Length; i++)
            // {
            //     for (int ii = 0; ii < nLP.wordToMatrix()[i].Length; ii++)
            //     {
            //         wmatrix = wmatrix + " " + nLP.wordToMatrix()[i][ii];
            //         // Console.WriteLine(nLP.WordToNumberMatrix()[i][ii]);
            //     }
            //     Console.WriteLine(wmatrix);
            //     wmatrix = "";
            // }

            //// Console.ReadLine();

            // string matrix = "";
            // for (int i = 0; i < nLP.WordToNumberMatrix().Length; i++)
            // {
            //     for (int ii = 0; ii < nLP.WordToNumberMatrix()[i].Length; ii++)
            //     {
            //         matrix = matrix + " " + nLP.WordToNumberMatrix()[i][ii].ToString();
            //        // Console.WriteLine(nLP.WordToNumberMatrix()[i][ii]);
            //     }
            //     Console.WriteLine(matrix);
            //     matrix = "";
            // }
            Console.WriteLine(nLP.getAnswer("would you please show me directory"));
            Console.ReadLine();
        }


    }
}
