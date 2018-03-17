# simple-tweener-unity3d
Tween your numbers, colors, translations with ease.

Check *Assets/Tweener/Tests* for examples.

![alt-text](https://github.com/domenkoneski/simple-tweener-unity3d/blob/master/simple-tweener/Assets/Github/tweening2.gif)

**Functions, Extentions and Method calls:**

Float Tween, creates a tween that invokes your onUpdateAction each frame (it holds time left until tween dies). Foundation for future tweening methods.
```cs
FloatTween.CreateTween(duration:float, onUpdateAction:Action<float>, onEndAction:Action);
```
