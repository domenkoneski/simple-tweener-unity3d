using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Koneski.Tweener
{
    public class TransformTween
    {
        public static Tween TweenPosition(Transform transform, Vector3 endPosition, float duration, bool localPosition = false, Action OnEnd = null)
        {
            Vector3 startPosition = localPosition ? transform.localPosition : transform.position;

            Tween tween = FloatTween.CreateTween(duration,
            (timeLeft) =>
            {
                float t = 1.0f - timeLeft / duration;

                Vector3 nextPosition = Vector3.Lerp(startPosition, endPosition, t);

                if (localPosition)
                    transform.localPosition = nextPosition;
                else
                    transform.position = nextPosition;
            }, 
            () =>
            {
                if (localPosition)
                    transform.localPosition = endPosition;
                else
                    transform.position = endPosition;

                if (OnEnd != null)
                    OnEnd.Invoke();
            });

            return tween;
        }

        public static Tween SwingTransform(Transform transform, float duration, float height, Action onEnd = null)
        {
            Vector3 initialPosition = transform.position;

            return FloatTween.CreateTween(duration, (f) =>
            {
                float t = 1.0f - f / duration;

                transform.position = initialPosition + Vector3.up * Mathf.Sin(t * 2 * Mathf.PI) * height;
            }, onEnd);
        }

        public static Tween TweenScale(Transform transform, Vector3 endScale, float duration, Action OnEnd = null)
        {
            Vector3 startScale = endScale;

            Tween tween = FloatTween.CreateTween(duration,
            (timeLeft) =>
            {
                float t = 1.0f - timeLeft / duration;

                Vector3 nextScale = Vector3.Lerp(startScale, endScale, t);

                transform.localScale = nextScale;
            },
            () =>
            {
                transform.localScale = endScale;

                if (OnEnd != null)
                    OnEnd.Invoke();
            });

            return tween;
        }

        /*public static Tween RotateAround(Transform transform, Vector3 pivot, float duration, Action OnEnd = null)
        {
            Vector3 startPosition = transform.position;

            Tween tween = FloatTween.CreateTween(duration,
            (timeLeft) =>
            {
                float t = 1.0f - timeLeft / duration;

                Vector3 nextScale = Vector3.(startScale, endScale, t);

                transform.localScale = nextScale;
            },
            () =>
            {
                transform.localScale = endScale;

                if (OnEnd != null)
                    OnEnd.Invoke();
            });

            return tween;
        }*/
    }
}
