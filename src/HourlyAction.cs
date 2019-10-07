using System;


namespace ScheduledActions
{
  class HourlyTask: ScheduledAction
  {
    public HourlyTask(Action<DateTime> action) : base(action)
    {
    }


    public HourlyTask(bool executeNow, Action<DateTime> action) : base(executeNow, action)
    {
    }


    public override DateTime Reschedule()
    {
      return DateTime.Now.AddHours(1);
    }
  }
}
