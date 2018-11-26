using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CMD
    {
        public string tasks { get; set; }
    }

    class Program
    {
        static void Main(string[] args) {
            //   nlpData();
           nlpCMDAsync();
            //  Console.WriteLine( GetStringAsync().Result[0]);
            //CMD cmd = JsonConvert.DeserializeObject<CMD>(GetStringAsync("Create task.").Result);

            //Console.WriteLine(cmd.tasks);

            //   CMDCALL("What is task today?");
            //      nlpCMD();

            //var items = "A B A D A C".Split(' ');
            //var unique_items = new HashSet<string>(items);
            //foreach (string s in unique_items)
            //    Console.WriteLine(s);
            //Console.ReadLine();

            //Training training = new Training();

               Console.ReadLine();




        }

        static string CMDCALL(string nlp)
        {

            CMD cmd = JsonConvert.DeserializeObject<CMD>(GetStringAsync(nlp).Result);

            Console.WriteLine(cmd.tasks);
            Console.ReadLine();
            string result = "";
            result = cmd.tasks;

            

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:5000/");

            //// Add an Accept header for JSON format.
            //client.DefaultRequestHeaders.Accept.Add(
            //new MediaTypeWithQualityHeaderValue("application/json"));

            //// List data response.
            //HttpResponseMessage response =  client.GetAsync("api?query=" + nlp + "").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            //if (response.IsSuccessStatusCode)
            //{
            //    CMD cmd =  JsonConvert.DeserializeObject<CMD>(response.Content.ReadAsStringAsync().Result);

            //    result = cmd.tasks;
            //    Console.WriteLine( result);
            //}
            //else
            //{
            //    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            //}

            ////Make any other calls using HttpClient here.

            ////Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            //// Console.ReadLine();
            //client.Dispose();

            return result;
        }

        static  void nlpCMDAsync()
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
                CMD cmd = new CMD();
                while (true)
                {
                    comanddd = Console.ReadLine();
                    
                    string[] splitString = comanddd.Split("#");
                   //   Console.WriteLine(splitString.Length.ToString());



                    //await Task.Run(() =>
                    //{
                    try
                    {
                        cmd = JsonConvert.DeserializeObject<CMD>(GetStringAsync(splitString[0].Trim()).Result);
                              //  Console.WriteLine(cmd.tasks);
                                comanddd = cmd.tasks;
                            }
                            catch (Exception)
                    {
                        comanddd = nLP.getAnswer(comanddd);
                        // throw;
                    }

                    //});

                   //  Console.WriteLine(comanddd);

                //   if (comanddd == null) { 
                    if (splitString.Length > 1)
                    {
                        comanddd = "";
                         comanddd = nLP.getAnswer(splitString[0].Trim());
                        // comanddd = CMDCALL(splitString[0].Trim());
                      //  comanddd = cmd.tasks;
                        comanddd = comanddd.Trim() + " " + splitString[1].Trim();
                            
                    }
                    else
                    {
                        
                      //  comanddd = cmd.tasks;
                        comanddd = nLP.getAnswer(comanddd);
                    }
                  //  }
                    // Console.ReadLine();
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

        public static async Task<string> GetStringAsync(string nlp)
        {
            var bytes = await GetBytesAsync("http://localhost:5000/api?query=" + nlp + "");
            Thread.Sleep(600);
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }

        public static async Task<byte[]> GetBytesAsync(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            using (var response = await request.GetResponseAsync())
            using (var content = new MemoryStream())
            using (var responseStream = response.GetResponseStream())
            {
                try
                {
                    await responseStream.CopyToAsync(content);
                }
                catch (Exception)
                {

                  //  throw;
                }
               
                return content.ToArray();
            }
        }
    }
}
