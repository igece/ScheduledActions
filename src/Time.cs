using System;


namespace ScheduledActions
{
  public struct Time
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


    public override string ToString()
    {
      return string.Format("{0:00}:{1:00}:{2:00}", Hour, Minute, Second);
    }


    public Time AddHours(uint hours)
    {
      uint newHour = Hour + hours;

      if (newHour > 23)
        throw new Exception("Invalid time specified.");

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
        throw new Exception("Invalid time specified.");

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
        throw new Exception("Invalid time specified.");

      return new Time(newHour, newMinute, newSecond);
    }


    public DateTime AddDate(DateTime date)
    {
      return date.Date.AddHours(Hour).AddMinutes(Minute).AddSeconds(Second);
    }
  }
}
