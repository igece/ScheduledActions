using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace ScheduledActions
{
    public abstract class ScheduledAction : IDisposable
    {
        public Time? ActivationTime { get; protected set; }

        public DateTime NextExecution { get; private set; }


        private Timer timer_;
        private static readonly object scheduleLock_ = new object();
        private bool disposed_ = false;

        private IEnumerable<Action<DateTime>> actions_ = null;


        public ScheduledAction(params Action<DateTime>[] actions)
        {
            Initialize(false, null, actions);
        }


        public ScheduledAction(Time activationTime, params Action<DateTime>[] actions)
        {
            Initialize(false, activationTime, actions);
        }


        public ScheduledAction(bool executeNow, params Action<DateTime>[] actions)
        {
            Initialize(executeNow, null, actions);
        }


        public ScheduledAction(bool executeNow, Time activationTime, params Action<DateTime>[] actions)
        {
            Initialize(executeNow, activationTime, actions);
        }


        public abstract DateTime Reschedule();


        public void Dispose()
        {
            Dispose(true);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposed_)
            {
                if (disposing)
                    timer_.Dispose();

                disposed_ = true;
            }
        }


        protected void Initialize(bool executeNow, Time? activationTime, Action<DateTime>[] actions)
        {
            actions_ = actions.ToList();
            ActivationTime = activationTime;
            NextExecution = Reschedule();

            TimeSpan dueTime = executeNow ? TimeSpan.Zero : NextExecution - DateTime.Now;

            if (dueTime < TimeSpan.Zero)
                return;

            timer_ = new Timer(_ => ExecuteAndReschedule(), null, dueTime, TimeSpan.Zero);
        }


        private void ExecuteAndReschedule()
        {
            Task.Run(() =>
            {
                lock (scheduleLock_)
                {
                    NextExecution = Reschedule();
                    
                    foreach (var action in actions_)
                        action(NextExecution);

                    TimeSpan dueTime = NextExecution - DateTime.Now;

                    if (dueTime < TimeSpan.Zero)
                        return;

                    timer_.Change(dueTime, TimeSpan.Zero);
                }
            });
        }
    }
}
