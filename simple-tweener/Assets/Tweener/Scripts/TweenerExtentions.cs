using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Koneski.Tweener
{
    public static class TweenerExtentions
    {
        public static Tween TweenPosition(this Transform transform, Vector3 endPosition, float duration, Action onEnd = null)
        {
            return TransformTween.TweenPosition(transform, endPosition, duration, false, onEnd);
        }

        public static Tween SwingTransform(this Transform transform, float duration, float height, Action onEnd = null)
        {
            return TransformTween.SwingTransform(transform, duration, height, onEnd);
        }

        public static Tween TweenLocalPosition(this Transform transform, Vector3 endPosition, float duration, Action onEnd = null)
        {
            return TransformTween.TweenPosition(transform, endPosition, duration, true, onEnd);
        }

        public static Tween TweenScale(this Transform transform, Vector3 endScale, float duration, Action onEnd = null)
        {
            return TransformTween.TweenScale(transform, endScale, duration, onEnd);
        }
    }
}