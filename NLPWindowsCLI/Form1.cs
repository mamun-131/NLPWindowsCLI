using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NLPWindowsCLI
{
    public partial class Form1 : Form
    {
        private static StringBuilder cmdOutput = null;
        Process cmdProcess;
        StreamWriter cmdStreamWriter;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmdOutput = new StringBuilder("");
            cmdProcess = new Process();

            cmdProcess.StartInfo.FileName = "cmd.exe";
            cmdProcess.StartInfo.UseShellExecute = false;
            cmdProcess.StartInfo.CreateNoWindow = true;
            cmdProcess.StartInfo.RedirectStandardOutput = true;

            cmdProcess.OutputDataReceived += new DataReceivedEventHandler(SortOutputHandler);
            cmdProcess.StartInfo.RedirectStandardInput = true;
            cmdProcess.Start();

            cmdStreamWriter = cmdProcess.StandardInput;
            cmdProcess.BeginOutputReadLine();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmdStreamWriter.WriteLine(textBox2.Text);
        }

        //private void btnQuit_Click(object sender, EventArgs e)
        //{
        //    cmdStreamWriter.Close();
        //    cmdProcess.WaitForExit();
        //    cmdProcess.Close();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = cmdOutput.ToString();
        }

        private static void SortOutputHandler(object sendingProcess,
            DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                cmdOutput.Append(Environment.NewLine + outLine.Data);
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Process p = new Process();
        //    ProcessStartInfo info = new ProcessStartInfo();
        //    info.FileName = "cmd.exe";
        //    info.RedirectStandardInput = true;
        //    info.UseShellExecute = false;

        //    p.StartInfo = info;
        //    p.Start();
        //    string comanddd = "";
        //    using (StreamWriter sw = p.StandardInput)
        //    {
        //        if (sw.BaseStream.CanWrite)
        //        {
        //            comanddd = Console.ReadLine();
        //           sw.WriteLine(comanddd);

        //            p.WaitForExit();
        //        }
        //    }
        //}
    }
}
