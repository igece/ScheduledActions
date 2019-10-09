using System;
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

    private Action<DateTime> action_;


    public ScheduledAction(Action<DateTime> action)
    {
      Initialize(false, null, action);
    }


    public ScheduledAction(Time activationTime, Action<DateTime> action)
    {
      Initialize(false, activationTime, action);
    }


    public ScheduledAction(bool executeNow, Action<DateTime> action)
    {
      Initialize(executeNow, null, action);
    }


    public ScheduledAction(bool executeNow, Time activationTime, Action<DateTime> action)
    {
      Initialize(executeNow, activationTime, action);
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


    protected void Initialize(bool executeNow, Time? activationTime, Action<DateTime> action)
    {
      action_ = action;
      ActivationTime = activationTime;
      NextExecution = Reschedule();
     
      TimeSpan dueTime = executeNow ? TimeSpan.Zero : NextExecution - DateTime.Now;

      if (dueTime < TimeSpan.Zero)
        return;

      timer_ = new Timer(x => ExecuteAndReschedule(), null, dueTime, TimeSpan.Zero);
    }


    private void ExecuteAndReschedule()
    {
      Task.Run(() =>
      {
        lock (scheduleLock_)
        {
          NextExecution = Reschedule();
          action_(NextExecution);

          TimeSpan dueTime = NextExecution - DateTime.Now;

          if (dueTime < TimeSpan.Zero)
            return;

          timer_.Change(dueTime, TimeSpan.Zero);
        }
      });
    }
  }
}
