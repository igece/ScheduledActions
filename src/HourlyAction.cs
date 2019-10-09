using System;


namespace ScheduledActions
{
  public class HourlyAction: ScheduledAction
  {
    private readonly uint eachHours_ = 1;


    public HourlyAction(Action<DateTime> action) : base(action)
    {
    }


    public HourlyAction(bool executeNow, Action<DateTime> action) : base(executeNow, action)
    {
    }


    public HourlyAction(bool executeNow, uint eachHours, Action<DateTime> action) : base(executeNow, action)
    {
      eachHours_ = eachHours;
    }


    public HourlyAction(Time activationTime, Action<DateTime> action) : base(activationTime, action)
    {
    }


    public HourlyAction(Time activationTime, uint eachHours, Action<DateTime> action) : base(activationTime, action)
    {
      eachHours_ = eachHours;
    }


    public HourlyAction(bool executeNow, Time activationTime, Action<DateTime> action) : base(executeNow, activationTime, action)
    {
    }


    public HourlyAction(Time activationTime, bool executeNow, uint eachHours, Action<DateTime> action) : base(executeNow, activationTime, action)
    {
      eachHours_ = eachHours;
    }


    public override DateTime Reschedule()
    {
      if (ActivationTime.HasValue)
        return ActivationTime.Value.AddDate(DateTime.Today.AddHours(eachHours_));
      else
        return DateTime.Now.AddHours(eachHours_);
    }
  }
}
