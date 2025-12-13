namespace J4JSoftware.WindowsUtilities;

public class ThrottleFunc<TResult> : ThrottleBase
{
    public event EventHandler<TResult>? CallbackExecuted;

    private Func<TResult>? _callback;

    public void Throttle( int milliseconds, Func<TResult> callback ) =>
        Throttle( TimeSpan.FromMilliseconds( milliseconds ), callback );

    public void Throttle( TimeSpan interval, Func<TResult> callback )
    {
        _callback = callback;
        Throttle( interval );
    }

    protected override void OnTimerTick()
    {
        var result = _callback!.Invoke();
        CallbackExecuted?.Invoke( this, result );
    }
}
