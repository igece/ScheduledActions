using System;


namespace ScheduledActions
{
    public class MonthlyAction : ScheduledAction
    {
        private readonly uint eachMonths_ = 1;


        public MonthlyAction(params Action<DateTime>[] actions) : base(actions)
        {
        }


        public MonthlyAction(bool executeNow, params Action<DateTime>[] actions) : base(executeNow, actions)
        {
        }


        public MonthlyAction(bool executeNow, uint eachMonths, params Action<DateTime>[] actions) : base(executeNow, actions)
        {
            eachMonths_ = eachMonths;
        }


        public MonthlyAction(Time activationTime, params Action<DateTime>[] actions) : base(activationTime, actions)
        {
        }


        public MonthlyAction(Time activationTime, uint eachMonths, params Action<DateTime>[] actions) : base(activationTime, actions)
        {
            eachMonths_ = eachMonths;
        }


        public MonthlyAction(bool executeNow, Time activationTime, params Action<DateTime>[] actions) : base(executeNow, activationTime, actions)
        {
        }


        public MonthlyAction(bool executeNow, Time activationTime, uint eachMonths, params Action<DateTime>[] actions) : base(executeNow, activationTime, actions)
        {
            eachMonths_ = eachMonths;
        }


        public override DateTime Reschedule()
        {
            if (ActivationTime.HasValue)
            {
                DateTime today = DateTime.Today;
                return ActivationTime.Value.AddDate(today.AddDays(-(today.Day - 1)).AddMonths((int)eachMonths_));
            }
            else
            {
                DateTime today = DateTime.Today;
                return today.AddDays(-(today.Day - 1)).AddMonths((int)eachMonths_);
            }
        }
    }
}
