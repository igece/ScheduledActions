using System;


namespace ScheduledActions
{
    public struct Time : IEquatable<Time>, IComparable<Time>, IComparable
    {
        public uint Hour { get; private set; }

        public uint Minute { get; private set; }

        public uint Second { get; private set; }


        public Time(uint hour, uint minute, uint second)
        {
            if (hour > 23 || minute > 59 || second > 59)
                throw new ArgumentException("Invalid time specified");

            Hour = hour;
            Minute = minute;
            Second = second;
        }


        public Time(DateTime date)
        {
            Hour = (uint)date.Hour;
            Minute = (uint)date.Minute;
            Second = (uint)date.Second;
        }


        public Time(TimeSpan timeSpan)
        {
            Hour = (uint)timeSpan.Hours;
            Minute = (uint)timeSpan.Minutes;
            Second = (uint)timeSpan.Seconds;
        }


        public static implicit operator Time(DateTime value)
        {
            return new Time(value);
        }


        public static implicit operator Time(TimeSpan value)
        {
            return new Time(value);
        }


        public static bool operator ==(Time left, Time right)
        {
            return left.CompareTo(right) == 0;
        }


        public static bool operator ==(Time left, TimeSpan right)
        {
            return left.CompareTo(right) == 0;
        }


        public static bool operator !=(Time left, Time right)
        {
            return left.CompareTo(right) != 0;
        }


        public static bool operator !=(Time left, TimeSpan right)
        {
            return left.CompareTo(right) != 0;
        }


        public static bool operator <(Time left, Time right)
        {
            return left.CompareTo(right) < 0;
        }


        public static bool operator <(Time left, TimeSpan right)
        {
            return left.CompareTo(right) < 0;
        }


        public static bool operator >(Time left, Time right)
        {
            return left.CompareTo(right) > 0;
        }


        public static bool operator >(Time left, TimeSpan right)
        {
            return left.CompareTo(right) > 0;
        }


        public static bool operator <=(Time left, Time right)
        {
            return left.CompareTo(right) <= 0;
        }


        public static bool operator <=(Time left, TimeSpan right)
        {
            return left.CompareTo(right) <= 0;
        }


        public static bool operator >=(Time left, Time right)
        {
            return left.CompareTo(right) >= 0;
        }


        public static bool operator >=(Time left, TimeSpan right)
        {
            return left.CompareTo(right) >= 0;
        }


        public Time AddHours(uint hours)
        {
            uint newHour = Hour + hours;

            if (newHour > 23)
                throw new ArgumentException("Invalid time specified.");

            return new Time(newHour, Minute, Second);
        }


        public Time AddMinutes(uint minutes)
        {
            uint newHour = Hour;
            uint newMinute = Minute + minutes;

            while (newMinute > 59)
            {
                newMinute -= 60;
                newHour++;
            }

            if (newHour > 23)
                throw new ArgumentException("Invalid time specified.");

            return new Time(newHour, newMinute, Second);
        }


        public Time AddSeconds(uint seconds)
        {
            uint newHour = Hour;
            uint newMinute = Minute;
            uint newSecond = Second + seconds;

            while (newSecond > 59)
            {
                newSecond -= 60;
                newMinute++;
            }

            while (newMinute > 59)
            {
                newMinute -= 60;
                newHour++;
            }

            if (newHour > 23)
                throw new ArgumentException("Invalid time specified.");

            return new Time(newHour, newMinute, newSecond);
        }


        public DateTime AddDate(DateTime date)
        {
            return date.Date.AddHours(Hour).AddMinutes(Minute).AddSeconds(Second);
        }


        public int CompareTo(object obj)
        {
            if (obj is Time time)
                return CompareTo(time);

            if (obj is TimeSpan timeSpan)
            {
                var hourComp = Hour.CompareTo((uint)timeSpan.Hours);

                if (hourComp != 0)
                    return hourComp;

                var minComp = Minute.CompareTo((uint)timeSpan.Minutes);

                if (minComp != 0)
                    return minComp;

                return Second.CompareTo((uint)timeSpan.Seconds);
            }

            throw new ArgumentException();
        }


        public int CompareTo(Time other)
        {
            var hourComp = Hour.CompareTo(other.Hour);

            if (hourComp != 0)
                return hourComp;

            var minComp = Minute.CompareTo(other.Minute);

            if (minComp != 0)
                return minComp;

            return Second.CompareTo(other.Second);
        }


        public override bool Equals(object obj)
        {
            if (obj is Time time)
                return Equals(time);

            if (obj is TimeSpan timeSpan)
            {
                return Hour == timeSpan.Hours &&
                       Minute == timeSpan.Minutes &&
                       Second == timeSpan.Seconds;
            }

            throw new ArgumentException();
        }


        public bool Equals(Time other)
        {
            return this == other;
        }


        public override int GetHashCode()
        {
            return Hour.GetHashCode() ^ Minute.GetHashCode() ^ Second.GetHashCode();
        }


        public override string ToString()
        {
            return string.Format("{0:00}:{1:00}:{2:00}", Hour, Minute, Second);
        }


        public TimeSpan ToTimeSpan()
        {
            return new TimeSpan((int)Hour, (int)Minute, (int)Second);
        }
    }
}
