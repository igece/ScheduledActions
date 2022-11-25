using System;


namespace ScheduledActions
{
    public class MinutelyAction : ScheduledAction
    {
        private readonly uint eachMinutes_ = 1;


        public MinutelyAction(params Action<DateTime>[] actions) : base(actions)
        {
        }


        public MinutelyAction(bool executeNow, params Action<DateTime>[] actions) : base(executeNow, actions)
        {
        }


        public MinutelyAction(bool executeNow, uint eachMinutes, params Action<DateTime>[] actions) : base(executeNow, actions)
        {
            eachMinutes_ = eachMinutes;
        }


        public MinutelyAction(Time activationTime, params Action<DateTime>[] actions) : base(activationTime, actions)
        {
        }


        public MinutelyAction(Time activationTime, uint eachMinutes, params Action<DateTime>[] actions) : base(activationTime, actions)
        {
            eachMinutes_ = eachMinutes;
        }


        public MinutelyAction(bool executeNow, Time activationTime, params Action<DateTime>[] actions) : base(executeNow, activationTime, actions)
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
