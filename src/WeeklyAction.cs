using System;


namespace ScheduledActions
{
  class WeeklyTask: ScheduledAction
  {
    public Time? activationTime_ = null;


    public WeeklyTask(Action<DateTime> action) : base(action)
    {
    }


    public WeeklyTask(bool executeNow, Action<DateTime> action) : base(executeNow, action)
    {
    }


    public WeeklyTask(Time activationTime, Action<DateTime> action) : base(action)
    {
      activationTime_ = activationTime;
    }


    public WeeklyTask(bool executeNow, Time activationTime, Action<DateTime> action) : base(executeNow, action)
    {
      activationTime_ = activationTime;
    }


    public override DateTime Reschedule()
    {
      if (activationTime_.HasValue)
      {
        DateTime today = DateTime.Today;
        return activationTime_.Value.AddDate(today.AddDays(((int)DayOfWeek.Monday - (int)today.AddDays(1).DayOfWeek + 7) % 7));
      }
      else
      {
        DateTime today = DateTime.Now;
        return today.AddDays(((int)DayOfWeek.Monday - (int)today.AddDays(1).DayOfWeek + 7) % 7);
      }
    }
  }
}
