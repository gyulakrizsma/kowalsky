using System;

namespace Kowalsky.Models
{
    public class Schedule
    {
        public Schedule(DateTime firstDay, DateTime? secondDay, DateTime? thirdDay, DateTime? fourthDay,
            DateTime? fifthDay, DateTime? sixthDay, DateTime? seventhDay)
        {
            FirstDay = firstDay;
            SecondDay = secondDay;
            ThirdDay = thirdDay;
            FourthDay = fourthDay;
            FifthDay = fifthDay;
            SixthDay = sixthDay;
            SeventhDay = seventhDay;
        }

        public DateTime FirstDay { get; }

        public DateTime? SecondDay { get; }

        public DateTime? ThirdDay { get; }

        public DateTime? FourthDay { get; }

        public DateTime? FifthDay { get; }

        public DateTime? SixthDay { get; }

        public DateTime? SeventhDay { get; }
    }
}
