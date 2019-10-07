using System;


namespace ScheduledActions
{
  class DailyAction: ScheduledAction
  {
    public DailyAction(Action<DateTime> action) : base(action)
    {
    }


    public DailyAction(bool executeNow, Action<DateTime> action) : base(executeNow, action)
    {
    }


    public DailyAction(Time activationTime, Action<DateTime> action) : base(activationTime, action)
    {
    }


    public DailyAction(bool executeNow, Time activationTime, Action<DateTime> action) : base(executeNow, activationTime, action)
    {
    }


    public override DateTime Reschedule()
    {
      if (ActivationTime.HasValue)
        return ActivationTime.Value.AddDate(DateTime.Today.AddDays(1));
      else
        return DateTime.Now.AddDays(1);
    }
  }
}
