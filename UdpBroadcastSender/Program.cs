using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

// Using TcpClient
namespace UdpBroadcastSender
{
    class Program
    {
        public const int Port = 7000;
        static void Main()
        {
            CheckinList checklist = new CheckinList();
            UdpClient socket = new UdpClient();
            socket.EnableBroadcast = true; // IMPORTANT
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, Port);
            while (true)
            {
                Console.WriteLine("Check a student in or out syntax: 'studentIndex'-'lessonIndex'");
                string msg = Console.ReadLine();
                string[] parts = msg.Split('-');

                //run simulation
                if (msg.ToUpper() == "S")
                {
                    Console.WriteLine("Running simulation");
                    break;
                }
                //random checkin
                else if(msg.ToUpper() == "R")
                {
                    AllowedCheckin allowedCheckin = checklist.RandomAllowedCheckin();
                    Checkin checkin = new Checkin(checklist.RandomKey(), allowedCheckin.LessonStart, allowedCheckin.Classroom, true);

                    if (!checklist.CanCheckIn(checkin))
                    {
                        checkin.CheckingIn = false;
                        checkin.CheckInTime.AddMinutes(45);
                    }
                    string message = checkin.ToString();
                    byte[] sendBuffer = Encoding.ASCII.GetBytes(message);
                    socket.Send(sendBuffer, sendBuffer.Length, endPoint);
                    Console.WriteLine(DateTime.Now + "Message sent to broadcast address {0} port {1}", endPoint.Address, Port);


                }
                //specific checkin
                else if (parts.Length == 2)
                {

                    int studentIndex = Convert.ToInt32(parts[0]);
                    int lessonIndex = Convert.ToInt32(parts[1]);

                    
                    Checkin checkin = new Checkin(checklist.ScannerKeyList[studentIndex], checklist.AllowedCheckins[lessonIndex].LessonStart, checklist.AllowedCheckins[lessonIndex].Classroom, true);
                    if (!checklist.CanCheckIn(checkin))
                    {
                        checkin.CheckingIn = false;
                        checkin.CheckInTime.AddMinutes(45);
                    }
                    string message = checkin.ToString();
                    byte[] sendBuffer = Encoding.ASCII.GetBytes(message);
                    socket.Send(sendBuffer, sendBuffer.Length, endPoint);
                    Console.WriteLine(DateTime.Now + "Message sent to broadcast address {0} port {1}", endPoint.Address, Port);

                }
                else
                {
                    Console.WriteLine("You must write in the correct syntax");
                }
            }
            while (true)
            {
                AllowedCheckin allowedCheckin = checklist.RandomAllowedCheckin();
                Checkin checkin = new Checkin(checklist.RandomKey(), allowedCheckin.LessonStart, allowedCheckin.Classroom, true);

                if (!checklist.CanCheckIn(checkin))
                {
                    checkin.CheckingIn = false;
                    checkin.CheckInTime.AddMinutes(45);
                }
                string message = checkin.ToString();
                byte[] sendBuffer = Encoding.ASCII.GetBytes(message);
                socket.Send(sendBuffer, sendBuffer.Length, endPoint);
                Console.WriteLine(DateTime.Now+"Message sent to broadcast address {0} port {1}", endPoint.Address, Port);
                
                Thread.Sleep(5000);
            }
        }
    }
}
