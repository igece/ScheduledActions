using System;


namespace ScheduledActions
{
  public class DailyAction: ScheduledAction
  {
    private readonly uint eachDays_ = 1;


    public DailyAction(Action<DateTime> action) : base(action)
    {
    }


    public DailyAction(bool executeNow, Action<DateTime> action) : base(executeNow, action)
    {
    }


    public DailyAction(bool executeNow, uint eachDays, Action<DateTime> action) : base(executeNow, action)
    {
      eachDays_ = eachDays;
    }


    public DailyAction(Time activationTime, Action<DateTime> action) : base(activationTime, action)
    {
    }


    public DailyAction(Time activationTime, uint eachDays, Action<DateTime> action) : base(activationTime, action)
    {
      eachDays_ = eachDays;
    }


    public DailyAction(bool executeNow, Time activationTime, Action<DateTime> action) : base(executeNow, activationTime, action)
    {
    }


    public DailyAction(bool executeNow, Time activationTime, uint eachDays, Action<DateTime> action) : base(executeNow, activationTime, action)
    {
      eachDays_ = eachDays;
    }


    public override DateTime Reschedule()
    {
      if (ActivationTime.HasValue)
        return ActivationTime.Value.AddDate(DateTime.Today.AddDays(eachDays_));
      else
        return DateTime.Now.AddDays(eachDays_);
    }
  }
}
