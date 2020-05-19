using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdpBroadcastSender
{
    public class Checkin
    {
        public Checkin(int scannerkey, DateTime checkintime, int classroom, bool checkingIn)
        {
            ScannerKey = scannerkey;
            CheckInTime = checkintime;
            Classroom = classroom;
            CheckingIn = checkingIn;
        }
        public int ScannerKey { get; set; }
        public DateTime CheckInTime { get; set; }
        public int Classroom { get; set; }
        public bool CheckingIn { get; set; }

        public override string ToString()
        {
            return ScannerKey.ToString() + " " + Classroom.ToString() + " " + CheckInTime + " " + CheckingIn;
        }
    }
}
