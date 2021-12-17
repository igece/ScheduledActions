using System;


namespace ScheduledActions
{
    public class MonthlyAction : ScheduledAction
    {
        private readonly uint eachMonths_ = 1;


        public MonthlyAction(Action<DateTime> action) : base(action)
        {
        }


        public MonthlyAction(bool executeNow, Action<DateTime> action) : base(executeNow, action)
        {
        }


        public MonthlyAction(bool executeNow, uint eachMonths, Action<DateTime> action) : base(executeNow, action)
        {
            eachMonths_ = eachMonths;
        }


        public MonthlyAction(Time activationTime, Action<DateTime> action) : base(activationTime, action)
        {
        }


        public MonthlyAction(Time activationTime, uint eachMonths, Action<DateTime> action) : base(activationTime, action)
        {
            eachMonths_ = eachMonths;
        }


        public MonthlyAction(bool executeNow, Time activationTime, Action<DateTime> action) : base(executeNow, activationTime, action)
        {
        }


        public MonthlyAction(bool executeNow, Time activationTime, uint eachMonths, Action<DateTime> action) : base(executeNow, activationTime, action)
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
