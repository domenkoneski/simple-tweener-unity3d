using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Koneski.Tweener
{
    public class FloatTween : MonoBehaviour
    {
        public static Tween CreateTween(float duration, Action<float> OnUpdate, Action OnEnd = null)
        {
            Tween tween = new Tween();

            tween.DurationLeft = duration;
            tween.IsActive = false;
            tween.IsCanceled = false;
            tween.OnEndAction = OnEnd;
            tween.OnUpdateAction = OnUpdate;

            TweenerEngine.CreateTween(tween);

            return tween;
        }
    }
}