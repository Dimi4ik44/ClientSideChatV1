using System;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class Program
    {

        static string IpAdress;
        static int port;
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static byte[] Gbuffer = new byte[100];
        static void Main(string[] args)
        {
            Console.WriteLine("Укажите айпи!");
            IpAdress = Console.ReadLine();
            Console.WriteLine("Укажите порт!");
            port = Int32.Parse(Console.ReadLine());
            socket.Connect(IpAdress, port);
            Thread AcT = new Thread(new ThreadStart(AcceptMessage));
            AcT.Start();
            Console.WriteLine("Hello World!");
            while (true)
            {
                string message = Console.ReadLine();
                byte[] buffer = Encoding.ASCII.GetBytes(message);
                socket.Send(buffer);

            }


        }
        static public void AcceptMessage()
        {
            while (true)
            {
                socket.Receive(Gbuffer);
                Console.WriteLine(Encoding.ASCII.GetString(Gbuffer));
                //Console.WriteLine("Mess");
            }
        }
    }
}
