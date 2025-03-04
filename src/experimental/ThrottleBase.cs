using System;
using Microsoft.UI.Xaml;

namespace J4JSoftware.WindowsUtilities;

// under construction...
// thanx to Rick Strahl for the inspiration for this.
// https://weblog.west-wind.com/posts/2017/jul/02/debouncing-and-throttling-dispatcher-events

public abstract class ThrottleBase
{
    private DispatcherTimer? _timer;
    private DateTime _timerStarted = DateTime.UtcNow.AddYears( -1 );

    protected void Throttle( int milliseconds ) => Throttle( TimeSpan.FromMilliseconds( milliseconds ) );

    protected void Throttle( TimeSpan interval )
    {
        _timer?.Stop();
        _timer = null;

        var curTime = DateTime.UtcNow;

        // if timeout is not up yet - adjust timeout to fire 
        // with potentially new Action parameters           
        if( curTime.Subtract( _timerStarted ) < interval )
            interval -= curTime.Subtract( _timerStarted );

        _timer = new DispatcherTimer();
        _timer.Tick += ProcessTimerTick;
        _timer.Interval = interval;

        _timer.Start();
        _timerStarted = curTime;
    }

    private void ProcessTimerTick( object? sender, object e )
    {
        _timer?.Stop();
        _timer = null;

        OnTimerTick();
    }

    protected abstract void OnTimerTick();
}
