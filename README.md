# simple-tweener-unity3d
Tween your numbers, colors, translations with ease.

Check *Assets/Tweener/Tests* for examples.

![alt-text](https://github.com/domenkoneski/simple-tweener-unity3d/blob/master/simple-tweener/Assets/Github/tweening2.gif)

**Functions, Extentions and Method calls:**

Float Tween, creates a tween that invokes your onUpdateAction each frame (it holds time left until tween dies). Foundation for future tweening methods.
```cs
FloatTween.CreateTween(duration:float, onUpdateAction:Action<float>, onEndAction:Action);
```

Transform tweens:
```cs
transform.TweenPosition(Vector3 endPosition, float duration, Action onEnd);
```
```cs
transform.TweenLocalPosition(Vector3 endPosition, float duration, Action onEnd);
```
```cs
transform.TweenScale(Vector3 endScale, float duration, Action onEnd);
```
```cs
transform.SwingPosition(float duration, float height, Action onEnd);
```

Tween options:
Repeats tween. Default = 0. Set to -1 to repeat infinite times.
```cs
transform.Repeat(int count);
```
Starts the tween.
```cs
transform.Start();
```
Cancels the tween the next possible frame.
```cs
transform.Cancel();
```
