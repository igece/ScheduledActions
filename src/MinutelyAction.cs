using System;


namespace ScheduledActions
{
  class MinutelyAction : ScheduledAction
  {
    private readonly uint eachMinutes_ = 1;


    public MinutelyAction(Action<DateTime> action) : base(action)
    {
    }


    public MinutelyAction(bool executeNow, Action<DateTime> action) : base(executeNow, action)
    {
    }


    public MinutelyAction(uint eachMinutes, Action<DateTime> action) : base(action)
    {
      eachMinutes_ = eachMinutes;
    }


    public MinutelyAction(bool executeNow, uint eachMinutes, Action<DateTime> action) : base(executeNow, action)
    {
      eachMinutes_ = eachMinutes;
    }


    public override DateTime Reschedule()
    {
      return DateTime.Now.AddMinutes(eachMinutes_);
    }
  }
}
