using System;

namespace Koneski.Tweener
{
    /// <summary>
    /// Tween object that holds Update and OnEnd actions
    /// along with TTL.
    /// </summary>
    public class Tween
    {
        public float DurationLeft;
        public Action<float> OnUpdateAction;
        public Action OnEndAction;

        public bool IsActive;
        public bool IsCanceled;

        /// <summary>
        /// Start the tween at the next possible frame.
        /// </summary>
        public void Start()
        {
            this.IsActive = true;
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
    }
}