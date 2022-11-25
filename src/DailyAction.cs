using System;


namespace ScheduledActions
{
    public class DailyAction : ScheduledAction
    {
        private readonly uint eachDays_ = 1;


        public DailyAction(params Action<DateTime>[] actions) : base(actions)
        {
        }


        public DailyAction(bool executeNow, params Action<DateTime>[] actions) : base(executeNow, actions)
        {
        }


        public DailyAction(bool executeNow, uint eachDays, params Action<DateTime>[] actions) : base(executeNow, actions)
        {
            eachDays_ = eachDays;
        }


        public DailyAction(Time activationTime, params Action<DateTime>[] actions) : base(activationTime, actions)
        {
        }


        public DailyAction(bool executeNow, Time activationTime, params Action<DateTime>[] actions) : base(executeNow, activationTime, actions)
        {
        }


        public DailyAction(bool executeNow, Time activationTime, uint eachDays, params Action<DateTime>[] actions) : base(executeNow, activationTime, actions)
        {
            eachDays_ = eachDays;
        }


        public override DateTime Reschedule()
        {
            if (ActivationTime.HasValue)
            {
                if (ActivationTime.Value > DateTime.Now.TimeOfDay)
                {
                    return ActivationTime.Value.AddDate(DateTime.Today);
                }

                else
                {
                    return ActivationTime.Value.AddDate(DateTime.Today.AddDays(eachDays_));
                }
            }
            else
                return DateTime.Now.AddDays(eachDays_);
        }
    }
}
