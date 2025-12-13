namespace J4JSoftware.WindowsUtilities;

public class ThrottleAction<TParam> : ThrottleBase
{
    public event EventHandler? CallbackExecuted;

    private Action<TParam?>? _callback;
    private bool _isAsync;
    private TParam? _arg;

    public void Throttle( int milliseconds, Action<TParam?> callback, TParam? arg ) =>
        Throttle( TimeSpan.FromMilliseconds( milliseconds ), callback, arg );

    public void Throttle( TimeSpan interval, Action<TParam?> callback, TParam? arg )
    {
        _callback = callback;
        _isAsync = false;
        _arg = arg;

        Throttle( interval );
    }

    public void ThrottleAsync( int milliseconds, Action<TParam?> callback, TParam? arg ) =>
        ThrottleAsync( TimeSpan.FromMilliseconds( milliseconds ), callback, arg );

    public async Task ThrottleAsync( TimeSpan interval, Action<TParam?> callback, TParam? arg )
    {
        _callback = callback;
        _isAsync = true;
        _arg = arg;

        Throttle( interval );
    }

    protected override void OnTimerTick()
    {
        _callback!.Invoke( _arg );
        CallbackExecuted?.Invoke( this, EventArgs.Empty );
    }
}
