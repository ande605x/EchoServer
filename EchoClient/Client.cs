using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EchoClient
{
    public class Client
    {
        public void Start()
        {
            using (TcpClient socket = new TcpClient("localhost", 7))
            using (NetworkStream ns = socket.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                String sendStr = "Anders";
                sw.WriteLine(sendStr);
                sw.Flush();

                String incommingStr = sr.ReadLine();
                Console.WriteLine("Ekko modtaget: "+incommingStr);
            }

        }
    }
}
