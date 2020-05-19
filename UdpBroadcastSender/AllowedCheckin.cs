using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdpBroadcastSender
{
    public class AllowedCheckin
    {
        private static int idcounter = 1;
        public AllowedCheckin(int classroom, DateTime lessonStart)
        {
            Id = idcounter;
            idcounter++;
            Classroom = classroom;
            LessonStart = lessonStart;
        }
        public int Id { get; set; }
        public int Classroom { get; set; }
        public DateTime LessonStart { get; set; }
    }
}
