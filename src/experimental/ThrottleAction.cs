namespace J4JSoftware.WindowsUtilities;

public class ThrottleAction : ThrottleBase
{
    public event EventHandler? CallbackExecuted;

    private Action? _callback;

    public void Throttle( int milliseconds, Action callback ) =>
        Throttle( TimeSpan.FromMilliseconds( milliseconds ), callback );

    public void Throttle( TimeSpan interval, Action callback )
    {
        _callback = callback;
        Throttle( interval );
    }

    protected override void OnTimerTick()
    {
        _callback!.Invoke();
        CallbackExecuted?.Invoke( this, EventArgs.Empty );
    }
}
