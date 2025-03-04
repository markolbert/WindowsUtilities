#region copyright

// Copyright (c) 2021, 2022, 2023 Mark A. Olbert 
// https://www.JumpForJoySoftware.com
// NewThrottleStuff.cs
//
// This file is part of JumpForJoy Software's WindowsUtilities.
// 
// WindowsUtilities is free software: you can redistribute it and/or modify it 
// under the terms of the GNU General Public License as published by the 
// Free Software Foundation, either version 3 of the License, or 
// (at your option) any later version.
// 
// WindowsUtilities is distributed in the hope that it will be useful, but 
// WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
// or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License 
// for more details.
// 
// You should have received a copy of the GNU General Public License along 
// with WindowsUtilities. If not, see <https://www.gnu.org/licenses/>.

#endregion

using System;

namespace J4JSoftware.WindowsUtilities;

public class ThrottleFunc<TParam, TResult> : ThrottleBase
{
    public event EventHandler<TResult>? CallbackExecuted;

    private Func<TParam?, TResult>? _callback;
    private TParam? _arg;

    public void Throttle( int milliseconds, Func<TParam?, TResult> callback, TParam? arg ) =>
        Throttle( TimeSpan.FromMilliseconds( milliseconds ), callback, arg );

    public void Throttle( TimeSpan interval, Func<TParam?, TResult> callback, TParam? arg )
    {
        _callback = callback;
        _arg = arg;

        Throttle( interval );
    }

    protected override void OnTimerTick()
    {
        var result = _callback!.Invoke( _arg );
        CallbackExecuted?.Invoke( this, result );
    }
}
