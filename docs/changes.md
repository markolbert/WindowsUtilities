# J4JSoftware.WindowsUtilities

|Version|Description|
|:-----:|-----------|
|1.2.0|updated to Net9, note comments on [experimental features](#120) below|
|1.1.0|added encryptable configuration class and some startup helper classes|
|1.0.1|fixed nuget dependencies|
|1.0.0|initial release|

## 1.2.0

Besides being updated to Net9, this release contains some work-in-progress/experimental classes that you shouldn't use, unless you want to try them out. In other words, use them at your own risk.

The experimental/work-in-process classes are:

- `ThrottleBase`
- `ThrottleAction`
- `ThrottleAction<TParam>`
- `ThrottleFunc`
- `ThrottleFunc<TParam, TResult>`

And, yes, I am aware you can mark stuff as experimental...but that requires you to remember to set flags to allow the use of experimental stuff. Which I often forget to do.
