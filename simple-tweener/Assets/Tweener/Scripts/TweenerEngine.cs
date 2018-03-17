using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Koneski.Tweener
{
    public class TweenerEngine : MonoBehaviour
    {
        public static TweenerEngine Instance;

        private static List<Tween> ActiveTweens;

        void Awake()
        {
            Instance = this;

            ActiveTweens = new List<Tween>();
        }

        void Update()
        {
            int tweenToDelete = -1;
            for (int i = 0; i < ActiveTweens.Count; i++)
            {
                Tween tween = ActiveTweens[i];

                if (tween.IsCanceled)
                    tweenToDelete = i;

                if (tween.IsActive)
                {
                    tween.DurationLeft -= Time.deltaTime;

                    if (tween.DurationLeft <= 0)
                    {
                        if ((tween.ShouldRepeat && tween.RepeatsLeft > 0) ||
                            tween.ShouldRepeat && tween.RepeatsLeft == -1)
                        {
                            if (tween.RepeatsLeft != -1)
                                tween.RepeatsLeft -= 1;

                            tween.DurationLeft = tween.Duration;

                            if (tween.OnRepeatAction != null)
                                tween.OnRepeatAction.Invoke();
                        }
                        else
                        {
                            tweenToDelete = i;

                            if (tween.OnEndAction != null)
                                tween.OnEndAction.Invoke();
                        }
                    }
                    else
                        tween.OnUpdateAction(tween.DurationLeft);
                }
            }

            if (tweenToDelete != -1)
                ActiveTweens.RemoveAt(tweenToDelete);
        }

        public void AddTween(Tween tween)
        {
            ActiveTweens.Add(tween);
        }

        public static void CreateTween(Tween tween)
        {
            TweenerEngine tweener;
            if (TweenerEngine.Instance == null)
            {
                GameObject TweenObject = new GameObject("Tweener Engine");
                tweener = TweenObject.AddComponent<TweenerEngine>();
                TweenObject.hideFlags |= HideFlags.HideInHierarchy;
            }
            else
                tweener = TweenerEngine.Instance;

            tweener.AddTween(tween);
        }
    }
}
