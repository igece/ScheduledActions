using System;


namespace ScheduledActions
{
    public class WeeklyAction : ScheduledAction
    {
        private readonly uint eachWeeks_ = 1;


        public WeeklyAction(Action<DateTime> action) : base(action)
        {
        }


        public WeeklyAction(bool executeNow, Action<DateTime> action) : base(executeNow, action)
        {
        }


        public WeeklyAction(bool executeNow, uint eachWeeks, Action<DateTime> action) : base(executeNow, action)
        {
            eachWeeks_ = eachWeeks;
        }


        public WeeklyAction(Time activationTime, Action<DateTime> action) : base(activationTime, action)
        {
        }


        public WeeklyAction(Time activationTime, uint eachWeeks, Action<DateTime> action) : base(activationTime, action)
        {
            eachWeeks_ = eachWeeks;
        }


        public WeeklyAction(bool executeNow, Time activationTime, Action<DateTime> action) : base(executeNow, activationTime, action)
        {
        }


        public WeeklyAction(bool executeNow, Time activationTime, uint eachWeeks, Action<DateTime> action) : base(executeNow, activationTime, action)
        {
            eachWeeks_ = eachWeeks;
        }


        public override DateTime Reschedule()
        {
            if (ActivationTime.HasValue)
            {
                DateTime today = DateTime.Today;
                return ActivationTime.Value.AddDate(today.AddDays((int)DayOfWeek.Monday - (int)today.AddDays(1).DayOfWeek + (eachWeeks_ * 7) % (eachWeeks_ * 7)));
            }
            else
            {
                DateTime today = DateTime.Now;
                return today.AddDays(((int)DayOfWeek.Monday - (int)today.AddDays(1).DayOfWeek + (eachWeeks_ * 7)) % (eachWeeks_ * 7));
            }
        }
    }
}
