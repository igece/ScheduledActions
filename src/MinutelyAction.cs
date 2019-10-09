using System;


namespace ScheduledActions
{
  public class MinutelyAction : ScheduledAction
  {
    private readonly uint eachMinutes_ = 1;


    public MinutelyAction(Action<DateTime> action) : base(action)
    {
    }


    public MinutelyAction(bool executeNow, Action<DateTime> action) : base(executeNow, action)
    {
    }


    public MinutelyAction(bool executeNow, uint eachMinutes, Action<DateTime> action) : base(executeNow, action)
    {
      eachMinutes_ = eachMinutes;
    }


    public MinutelyAction(Time activationTime, Action<DateTime> action) : base(activationTime, action)
    {
    }


    public MinutelyAction(Time activationTime, uint eachMinutes, Action<DateTime> action) : base(activationTime, action)
    {
      eachMinutes_ = eachMinutes;
    }


    public MinutelyAction(bool executeNow, Time activationTime, Action<DateTime> action) : base(executeNow, activationTime, action)
    {
    }


    public override DateTime Reschedule()
    {
      if (ActivationTime.HasValue)
        return ActivationTime.Value.AddDate(DateTime.Today.AddMinutes(eachMinutes_));
      else
        return DateTime.Now.AddMinutes(eachMinutes_);
    }
  }
}
