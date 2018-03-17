using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Koneski.Tweener
{
    public class ColorTween
    {
        public static Tween TweenColor(Material material, Color endColor, float duration, Action onEnd = null)
        {
            Color startColor = material.color;

            Tween tween = FloatTween.CreateTween(duration,
            (timeLeft) =>
            {
                float t = 1.0f - timeLeft / duration;

                Color nextColor = Color.Lerp(startColor, endColor, t);

                material.color = nextColor;
            },
            () =>
            {
                material.color = endColor;

                if (onEnd != null)
                    onEnd.Invoke();
            });

            return tween;
        }

        public static Tween TweenColor(Color color, Color endColor, float duration, Action onEnd = null)
        {
            Color startColor = color;

            return FloatTween.CreateTween(0, null, null);
        }
    }
}