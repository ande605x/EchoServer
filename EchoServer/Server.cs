﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EchoServer
{
    public class Server
    {
        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 7);
            server.Start();

            using (TcpClient socket = server.AcceptTcpClient())
            using (NetworkStream ns = socket.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                String inLine = sr.ReadLine();
                sw.WriteLine(inLine);


                int countWords = inLine.Split(' ').Length;


                Console.WriteLine("Besked fra client modtaget: " + inLine+" Antal ord modtaget: "+countWords);

                sw.Flush();
            }

        }
    }
}
