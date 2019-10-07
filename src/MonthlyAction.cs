using System;


namespace ScheduledActions
{
  class MonthlyTask : ScheduledAction
  {
    public MonthlyTask(Action<DateTime> action) : base(action)
    {
    }


    public MonthlyTask(bool executeNow, Action<DateTime> action) : base(executeNow, action)
    {
    }


    public MonthlyTask(Time activationTime, Action<DateTime> action) : base(activationTime, action)
    {
    }


    public MonthlyTask(bool executeNow, Time activationTime, Action<DateTime> action) : base(executeNow, activationTime, action)
    {
    }


    public override DateTime Reschedule()
    {
      if (ActivationTime.HasValue)
      {
        DateTime today = DateTime.Today;
        return ActivationTime.Value.AddDate(today.AddDays(-(today.Day - 1)).AddMonths(1));
      }
      else
      {
        DateTime today = DateTime.Today;
        return today.AddDays(-(today.Day - 1)).AddMonths(1);
      }
    }
  }
}
