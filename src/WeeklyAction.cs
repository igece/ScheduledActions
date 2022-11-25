using System;


namespace ScheduledActions
{
    public class WeeklyAction : ScheduledAction
    {
        private readonly uint eachWeeks_ = 1;


        public WeeklyAction(params Action<DateTime>[] actions) : base(actions)
        {
        }


        public WeeklyAction(bool executeNow, params Action<DateTime>[] actions) : base(executeNow, actions)
        {
        }


        public WeeklyAction(bool executeNow, uint eachWeeks, params Action<DateTime>[] actions) : base(executeNow, actions)
        {
            eachWeeks_ = eachWeeks;
        }


        public WeeklyAction(Time activationTime, params Action<DateTime>[] actions) : base(activationTime, actions)
        {
        }


        public WeeklyAction(Time activationTime, uint eachWeeks, params Action<DateTime>[] actions) : base(activationTime, actions)
        {
            eachWeeks_ = eachWeeks;
        }


        public WeeklyAction(bool executeNow, Time activationTime, params Action<DateTime>[] actions) : base(executeNow, activationTime, actions)
        {
        }


        public WeeklyAction(bool executeNow, Time activationTime, uint eachWeeks, params Action<DateTime>[] actions) : base(executeNow, activationTime, actions)
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
