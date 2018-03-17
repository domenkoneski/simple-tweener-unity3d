using System;
using System.Collections.Generic;
using UnityEngine;

namespace Koneski.Tweener
{
    public enum EaseType
    {
        LINEAR,
        QUADIN,     QUADOUT,    QUADINOUT,
        CUBICIN,    CUBICOUT,   CUBICINOUT,
        QUARTIN,    QUARTOUT,   QUARTINOUT
    }

    public class Easing
    {
        private static Dictionary<EaseType, Func<float, float, float, float>> EasingFunctions;

        static void BuildEasingFunctionsDictionary()
        {
            EasingFunctions = new Dictionary<EaseType, Func<float, float, float, float>>();

            EasingFunctions[EaseType.LINEAR] = new Func<float, float, float, float>(Linear);
            EasingFunctions[EaseType.QUADIN] = new Func<float, float, float, float>(QuadIn);
            EasingFunctions[EaseType.QUADOUT] = new Func<float, float, float, float>(QuadOut);
            EasingFunctions[EaseType.QUADINOUT] = new Func<float, float, float, float>(QuadInOut);
            EasingFunctions[EaseType.CUBICIN] = new Func<float, float, float, float>(CubicIn);
            EasingFunctions[EaseType.CUBICOUT] = new Func<float, float, float, float>(CubicOut);
            EasingFunctions[EaseType.CUBICINOUT] = new Func<float, float, float, float>(CubicInOut);
            EasingFunctions[EaseType.QUARTIN] = new Func<float, float, float, float>(QuadIn);
            EasingFunctions[EaseType.QUARTOUT] = new Func<float, float, float, float>(QuartOut);
            EasingFunctions[EaseType.QUARTINOUT] = new Func<float, float, float, float>(QuartInOut);
        }

        public static float ResolveEasing(float start, float end, float t, EaseType easeType)
        {
            if (EasingFunctions == null || EasingFunctions.Count == 0)
                BuildEasingFunctionsDictionary();

            return EasingFunctions[easeType](start, end, t);
        }

        private static Vector3 tempVector = new Vector3();
        public static Vector3 ResolveEasingVector3(Vector3 start, Vector3 end, float t, EaseType easeType)
        {
            tempVector.x = ResolveEasing(start.x, end.x, t, easeType);
            tempVector.y = ResolveEasing(start.y, end.y, t, easeType);
            tempVector.z = ResolveEasing(start.z, end.z, t, easeType);

            return tempVector;
        }

        private static Color tempColor = new Color();
        public static Color ResolveEasingColor(Color start, Color end, float t, EaseType easeType)
        {
            tempColor.a = ResolveEasing(start.a, end.a, t, easeType);
            tempColor.r = ResolveEasing(start.r, start.r, t, easeType);
            tempColor.g = ResolveEasing(start.g, start.g, t, easeType);
            tempColor.b = ResolveEasing(start.b, start.b, t, easeType);

            return tempColor;
        }


        /// <summary>
        /// Easing functions.
        /// </summary>

        public static float Linear(float start, float end, float t)
        {
            return (end - start) * t + start;
        }

        public static float QuadIn(float start, float end, float t)
        {
            return (end - start) * t * t + start;
        }

        public static float QuadOut(float start, float end, float t)
        {
            return -(end - start) * t * (t - 2.0f) + start;
        }

        public static float QuadInOut(float start, float end, float t)
        {
            t *= 2.0f;

            if (t < 1)
                return 0.5f * (end - start) * t * t + start;

            t -= 1.0f;

            return -0.5f * (end - start) * (t * (t - 2.0f) - 1.0f) + start;  
        }

        public static float CubicIn(float start, float end, float t)
        {
            return (end - start) * (t * t * t) + start;
        }

        public static float CubicOut(float start, float end, float t)
        {
            t -= 1f;
            return (end - start) * (t * t * t + 1) + start;
        }

        public static float CubicInOut(float start, float end, float t)
        {
            t *= 2f;
            if (t < 1)
                return 0.5f * (end - start) * t * t * t + start;

            t -= 2f;

            return 0.5f * (end - start) * (t * t * t + 2) + start; 
        }

        public static float QuartOut(float start, float end, float t)
        {
            t -= 1f;
            return -(end - start) * (t * t * t * t - 1) + start;
        }

        public static float QuartIn(float start, float end, float t)
        {
            return (end - start) * t * t * t * t + start;
        }

        public static float QuartInOut(float start, float end, float t)
        {
            t *= 2.0f;
            if (t < 1)
                return 0.5f * (end - start) * t * t * t * t + start;

            return -0.5f * (end - start) * (t * t * t * t - 2.0f) + start;
        }

        //http://www.gizma.com/easing/ continue
    }
}
