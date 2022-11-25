using System;


namespace ScheduledActions
{
    public class HourlyAction : ScheduledAction
    {
        private readonly uint eachHours_ = 1;


        public HourlyAction(params Action<DateTime>[] actions) : base(actions)
        {
        }


        public HourlyAction(bool executeNow, params Action<DateTime>[] actions) : base(executeNow, actions)
        {
        }


        public HourlyAction(bool executeNow, uint eachHours, params Action<DateTime>[] actions) : base(executeNow, actions)
        {
            eachHours_ = eachHours;
        }


        public HourlyAction(Time activationTime, params Action<DateTime>[] actions) : base(activationTime, actions)
        {
        }


        public HourlyAction(Time activationTime, uint eachHours, params Action<DateTime>[] actions) : base(activationTime, actions)
        {
            eachHours_ = eachHours;
        }


        public HourlyAction(bool executeNow, Time activationTime, params Action<DateTime>[] actions) : base(executeNow, activationTime, actions)
        {
        }


        public HourlyAction(Time activationTime, bool executeNow, uint eachHours, params Action<DateTime>[] actions) : base(executeNow, activationTime, actions)
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
