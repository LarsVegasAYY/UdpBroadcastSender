using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdpBroadcastSender
{
    public class CheckinList
    {
        public List<int> ScannerKeyList = new List<int>();
        public List<int> ClassroomList = new List<int>();
        public List<DateTime> StartTimes = new List<DateTime>();
        public List<int> Days = new List<int>();
        public List<AllowedCheckin> AllowedCheckins = new List<AllowedCheckin>();
        public List<Checkin> Checkedin = new List<Checkin>();


        public int year = 2020;
        public int month = 5;
        public CheckinList()
        {
            ScannerKeyList.Add(4);
            ScannerKeyList.Add(5);
            ScannerKeyList.Add(6);
            ScannerKeyList.Add(7);
            ScannerKeyList.Add(8);
            ScannerKeyList.Add(9);
            ScannerKeyList.Add(10);
            ScannerKeyList.Add(11);
            ScannerKeyList.Add(12);
            ScannerKeyList.Add(13);

            Days.Add(18);
            Days.Add(19);
            Days.Add(21);
            Days.Add(22);

            StartTimes.Add(new DateTime(year, month, 1, 9, 0, 0));
            StartTimes.Add(new DateTime(year, month, 1, 10, 5, 0));
            StartTimes.Add(new DateTime(year, month, 1, 10, 50, 0));
            StartTimes.Add(new DateTime(year, month, 1, 12, 15, 0));
            StartTimes.Add(new DateTime(year, month, 1, 13, 0, 0));
            StartTimes.Add(new DateTime(year, month, 1, 14, 0, 0));

            ClassroomList.Add(1);
            ClassroomList.Add(2);

            //mandag
            AllowedCheckins.Add(new AllowedCheckin(1, new DateTime(year, month, Days[0], StartTimes[0].Hour, StartTimes[0].Minute, 0)));
            AllowedCheckins.Add(new AllowedCheckin(1, new DateTime(year, month, Days[0], StartTimes[1].Hour, StartTimes[1].Minute, 0)));
            AllowedCheckins.Add(new AllowedCheckin(1, new DateTime(year, month, Days[0], StartTimes[2].Hour, StartTimes[2].Minute, 0)));
            AllowedCheckins.Add(new AllowedCheckin(1, new DateTime(year, month, Days[0], StartTimes[3].Hour, StartTimes[3].Minute, 0)));

            //tirsdag
            AllowedCheckins.Add(new AllowedCheckin(1, new DateTime(year, month, Days[1], StartTimes[0].Hour, StartTimes[0].Minute, 0)));
            AllowedCheckins.Add(new AllowedCheckin(1, new DateTime(year, month, Days[1], StartTimes[1].Hour, StartTimes[1].Minute, 0)));
            AllowedCheckins.Add(new AllowedCheckin(1, new DateTime(year, month, Days[1], StartTimes[2].Hour, StartTimes[2].Minute, 0)));
            AllowedCheckins.Add(new AllowedCheckin(2, new DateTime(year, month, Days[1], StartTimes[3].Hour, StartTimes[3].Minute, 0)));
            AllowedCheckins.Add(new AllowedCheckin(2, new DateTime(year, month, Days[1], StartTimes[4].Hour, StartTimes[4].Minute, 0)));
            AllowedCheckins.Add(new AllowedCheckin(2, new DateTime(year, month, Days[1], StartTimes[5].Hour, StartTimes[5].Minute, 0)));


            //torsdag
            AllowedCheckins.Add(new AllowedCheckin(1, new DateTime(year, month, Days[2], StartTimes[0].Hour, StartTimes[0].Minute, 0)));
            AllowedCheckins.Add(new AllowedCheckin(1, new DateTime(year, month, Days[2], StartTimes[1].Hour, StartTimes[1].Minute, 0)));
            AllowedCheckins.Add(new AllowedCheckin(1, new DateTime(year, month, Days[2], StartTimes[2].Hour, StartTimes[2].Minute, 0)));
            AllowedCheckins.Add(new AllowedCheckin(1, new DateTime(year, month, Days[2], StartTimes[3].Hour, StartTimes[3].Minute, 0)));
            AllowedCheckins.Add(new AllowedCheckin(1, new DateTime(year, month, Days[2], StartTimes[4].Hour, StartTimes[4].Minute, 0)));
            AllowedCheckins.Add(new AllowedCheckin(1, new DateTime(year, month, Days[2], StartTimes[5].Hour, StartTimes[5].Minute, 0)));

            //fredag
            AllowedCheckins.Add(new AllowedCheckin(2, new DateTime(year, month, Days[3], StartTimes[0].Hour, StartTimes[0].Minute, 0)));
            AllowedCheckins.Add(new AllowedCheckin(2, new DateTime(year, month, Days[3], StartTimes[1].Hour, StartTimes[1].Minute, 0)));
            AllowedCheckins.Add(new AllowedCheckin(2, new DateTime(year, month, Days[3], StartTimes[2].Hour, StartTimes[2].Minute, 0)));
            AllowedCheckins.Add(new AllowedCheckin(2, new DateTime(year, month, Days[3], StartTimes[3].Hour, StartTimes[3].Minute, 0)));



        }
        public int RandomKey()
        {
            var random = new Random();
            return ScannerKeyList[random.Next(ScannerKeyList.Count)];
        }
        public AllowedCheckin RandomAllowedCheckin()
        {
            var random = new Random();
            return AllowedCheckins[random.Next(AllowedCheckins.Count)];
        }

        public Checkin RandomCheckedin()
        {
            var random = new Random();
            return Checkedin[random.Next(Checkedin.Count)];
        }

        public bool CanCheckIn(Checkin canCheckin)
        {
            foreach (Checkin checkin in Checkedin)
            {
                if (checkin.ScannerKey == canCheckin.ScannerKey && checkin.Classroom == canCheckin.Classroom && checkin.CheckInTime.Date == canCheckin.CheckInTime.Date && checkin.CheckInTime.Hour == canCheckin.CheckInTime.Hour && checkin.CheckInTime.Minute == canCheckin.CheckInTime.Minute)
                {
                    Checkedin.Remove(checkin);
                    return false;
                }
            }
            Checkedin.Add(canCheckin);
            return true;
        }




    }
}
