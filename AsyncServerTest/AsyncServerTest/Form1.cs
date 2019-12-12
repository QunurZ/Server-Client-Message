using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace AsyncServerTest
{
    public partial class Form1 : Form
    {
        //Static
        public Socket listener = null;
        public IPEndPoint ipEndPoint = null;
        public static string data = null;
        public Socket handler = null;
        public byte[] bytes = new byte[1024];
        public int intProgression = 1;
        public string messageData;
        public string messageSend;
        public List<string> message = new List<string>();

        public Form1()
        {
            //Start on launch
            InitializeComponent();

            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

            IPAddress ipAddress = IPAddress.Any;
            ipEndPoint = new IPEndPoint(ipAddress, 11000);

            listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }


        public void CallListener(Socket listener, IPEndPoint ipEndPoint)
        {
            //Listen for port and establis a connection.
            try
            {
                listener.Bind(ipEndPoint);
                listener.Listen(10);
                Tbx_Read.Text = "Listening...";

                while(true)
                {
                    handler = listener.Accept();
                    if (handler != null)
                    {
                        break;
                    }
                }

                Tbx_Read.Text = "Connected";

                backgroundWorker1.RunWorkerAsync();
            }
            catch(Exception e)
            {
                Tbx_Read.Text = e.ToString();
            }
        }

        private void Btn_Send_Click(object sender, EventArgs e)
        {
            //Send messages to the connected handler
            string text = Tbx_Type.Text;
            DateTime currentDate = DateTime.Now;

            byte[] msg = Encoding.ASCII.GetBytes($"{currentDate:HH:mm} | <EAF> | " + text + "<EOF>");

            handler.Send(msg);

            //Decodes msg and adds it to the list, then displays the list
            messageSend = Encoding.ASCII.GetString(msg);
            messageSend = messageSend.Replace("<EAF>", "You");
            messageSend = messageSend.Replace("<EOF>", "");
            message.Add(messageSend);
            Tbx_Read.Text = String.Join(Environment.NewLine, message);
        }

        private void Btn_Listen_Click(object sender, EventArgs e)
        {
            //Start CallListener to listen for calls
            CallListener(listener, ipEndPoint);
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            //Closes the program
            if (handler != null)
            {
                backgroundWorker1.CancelAsync();
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }

            Application.Exit();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Receive data
            try
            {
                while (true)
                {
                    if (backgroundWorker1.CancellationPending == true)
                    {
                        e.Cancel = true;
                        return;
                    }

                    string dataReceived = "";
                    int bytesReceived = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesReceived);
                    if (data.IndexOf("<EOF>") > -1)
                    {
                        dataReceived = data.Replace("<EOF>", "");
                    }

                    Thread.Sleep(100);
                    backgroundWorker1.ReportProgress(intProgression, dataReceived);
                    intProgression++;
                    data = null;
                }
            }
            catch (Exception b)
            {
                //When the program is closed, removes the error handler.receive would give due to cancelled receiving
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Adds the received message to the list and displays the list
            messageData = e.UserState.ToString();
            messageData = messageData.Replace("<EAF>", "User");

            if (messageData != "")
            {
                message.Add(messageData);
                Tbx_Read.Text = String.Join(Environment.NewLine, message);
            }
        }
    }
}
