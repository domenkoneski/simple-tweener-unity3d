using System;

namespace Koneski.Tweener
{
    /// <summary>
    /// Tween object that holds Update and OnEnd actions
    /// along with TTL.
    /// </summary>
    public class Tween
    {
        public float Duration;
        public float DurationLeft;

        public Action<float> OnUpdateAction;
        public Action OnRepeatAction;
        public Action OnEndAction;

        public bool IsActive;
        public bool IsCanceled;

        public bool ShouldRepeat;
        public int RepeatsLeft;

        /// <summary>
        /// Start the tween at the next possible frame.
        /// </summary>
        public void Start()
        {
            this.IsActive = true;
            this.Duration = DurationLeft;
        }

        /// <summary>
        /// Cancel tween the next possible frame.
        /// OnEnd Action will not get called, call
        /// it manually.
        /// </summary>
        public void Cancel()
        {
            this.IsActive = false;
            this.IsCanceled = true;
        }

        /// <summary>
        /// Repeats the tween with set repeat count.
        /// </summary>
        /// <param name="repeatCount"></param>
        /// <returns></returns>
        public Tween Repeat(int repeatCount = 1)
        {
            this.ShouldRepeat = true;
            this.RepeatsLeft = repeatCount;

            return this;
        }

        /// <summary>
        /// This action will get called only if Repeat() is called on this tween.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public Tween SetOnRepeatAction(Action action)
        {
            this.OnRepeatAction = action;

            return this;
        }
    }
}