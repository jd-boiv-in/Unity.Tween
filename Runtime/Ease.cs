// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
using System;
using UnityEngine;

// Contains easing functions to use for Tween
// Heavily inspired by shohei909 TweenX library
namespace JD.Tween
{
    public enum Ease
    {
        Linear = 0,
        SineIn = 1,
        SineOut = 2,
        InSine = 1,
        OutSine = 2,
        SineInOut = 3,
        SineOutIn = 4,
        QuadIn = 5,
        QuadOut = 6,
        InQuad = 5,
        OutQuad = 6,
        QuadInOut = 7,
        InOutQuad = 7,
        QuadOutIn = 8,
        CubicIn = 9,
        CubicOut = 10,
        InCubic = 9,
        OutCubic = 10,
        CubicInOut = 11,
        CubicOutIn = 12,
        QuartIn = 13,
        QuartOut = 14,
        InQuart = 13,
        OutQuart = 14,
        QuartInOut = 15,
        QuartOutIn = 16,
        QuintIn = 17,
        QuintOut = 18,
        InQuint = 17,
        OutQuint = 18,
        QuintInOut = 19,
        QuintOutIn = 20,
        ExpoIn = 21,
        ExpoOut = 22,
        InExpo = 21,
        OutExpo = 22,
        ExpoInOut = 23,
        ExpoOutIn = 24,
        CircIn = 25,
        CircOut = 26,
        InCirc = 25,
        OutCirc = 26,
        CircInOut = 27,
        CircOutIn = 28,
        BounceIn = 29,
        BounceOut = 30,
        InBounce = 29,
        OutBounce = 30,
        BounceInOut = 31,
        BounceOutIn = 32,
        BackIn = 33,
        BackOut = 34,
        InBack = 33,
        OutBack = 34,
        BackInOut = 35,
        BackOutIn = 36,
        ElasticIn = 37,
        ElasticOut = 38,
        InElastic = 37,
        OutElastic = 38,
        ElasticInOut = 39,
        ElasticOutIn = 40,
        WarpIn = 41,
        WarpOut = 42,
        InWarp = 41,
        OutWarp = 42,
        WarpInOut = 43,
        WarpOutIn = 44,
        
        None = 255
    }
    
    public static class EasingFunc
    {
        private const float Pi = 3.1415926535897932384626433832795f;
        private const float Pi2 = Pi / 2f;
        private const float Ln2 = 0.6931471805599453f;
        private const float Ln2Ten = 6.931471805599453f;

        private const float Overshoot = 1.70158f;

        private const float Amplitude = 1f;
        private const float Period = 0.0003f;

        public static float Tween(float start, float end, float t, Ease ease)
        {
            return start + (end - start) * t.Ease(ease);
        }

        // Using enum
        public static float Ease(this float t, Ease ease)
        {
            switch (ease)
            {
                case JD.Tween.Ease.Linear:
                    return Linear(t);
                case JD.Tween.Ease.SineIn:
                    return SineIn(t);
                case JD.Tween.Ease.SineOut:
                    return SineOut(t);
                case JD.Tween.Ease.SineInOut:
                    return SineInOut(t);
                case JD.Tween.Ease.SineOutIn:
                    return SineOutIn(t);
                case JD.Tween.Ease.QuadIn:
                    return QuadIn(t);
                case JD.Tween.Ease.QuadOut:
                    return QuadOut(t);
                case JD.Tween.Ease.QuadInOut:
                    return QuadInOut(t);
                case JD.Tween.Ease.QuadOutIn:
                    return QuadOutIn(t);
                case JD.Tween.Ease.CubicIn:
                    return CubicIn(t);
                case JD.Tween.Ease.CubicOut:
                    return CubicOut(t);
                case JD.Tween.Ease.CubicInOut:
                    return CubicInOut(t);
                case JD.Tween.Ease.CubicOutIn:
                    return CubicOutIn(t);
                case JD.Tween.Ease.QuartIn:
                    return QuartIn(t);
                case JD.Tween.Ease.QuartOut:
                    return QuartOut(t);
                case JD.Tween.Ease.QuartInOut:
                    return QuartInOut(t);
                case JD.Tween.Ease.QuartOutIn:
                    return QuartOutIn(t);
                case JD.Tween.Ease.QuintIn:
                    return QuintIn(t);
                case JD.Tween.Ease.QuintOut:
                    return QuintOut(t);
                case JD.Tween.Ease.QuintInOut:
                    return QuintInOut(t);
                case JD.Tween.Ease.QuintOutIn:
                    return QuintOutIn(t);
                case JD.Tween.Ease.ExpoIn:
                    return ExpoIn(t);
                case JD.Tween.Ease.ExpoOut:
                    return ExpoOut(t);
                case JD.Tween.Ease.ExpoInOut:
                    return ExpoInOut(t);
                case JD.Tween.Ease.ExpoOutIn:
                    return ExpoOutIn(t);
                case JD.Tween.Ease.CircIn:
                    return CircIn(t);
                case JD.Tween.Ease.CircOut:
                    return CircOut(t);
                case JD.Tween.Ease.CircInOut:
                    return CircInOut(t);
                case JD.Tween.Ease.CircOutIn:
                    return CircOutIn(t);
                case JD.Tween.Ease.BounceIn:
                    return BounceIn(t);
                case JD.Tween.Ease.BounceOut:
                    return BounceOut(t);
                case JD.Tween.Ease.BounceInOut:
                    return BounceInOut(t);
                case JD.Tween.Ease.BounceOutIn:
                    return BounceOutIn(t);
                case JD.Tween.Ease.BackIn:
                    return BackIn(t);
                case JD.Tween.Ease.BackOut:
                    return BackOut(t);
                case JD.Tween.Ease.BackInOut:
                    return BackInOut(t);
                case JD.Tween.Ease.BackOutIn:
                    return BackOutIn(t);
                case JD.Tween.Ease.ElasticIn:
                    return ElasticIn(t);
                case JD.Tween.Ease.ElasticOut:
                    return ElasticOut(t);
                case JD.Tween.Ease.ElasticInOut:
                    return ElasticInOut(t);
                case JD.Tween.Ease.ElasticOutIn:
                    return ElasticOutIn(t);
                case JD.Tween.Ease.WarpIn:
                    return WarpIn(t);
                case JD.Tween.Ease.WarpOut:
                    return WarpOut(t);
                case JD.Tween.Ease.WarpInOut:
                    return WarpInOut(t);
                case JD.Tween.Ease.WarpOutIn:
                    return WarpOutIn(t);
                case JD.Tween.Ease.None:
                    return 1f;
                default:
                    throw new ArgumentOutOfRangeException(nameof(ease), ease, null);
            }
        }
        
        // Linear
        public static float Linear(this float t)
        {
            return t;
        }

        // Sine
        public static float SineIn(this float t)
        {
            if (Mathf.Approximately(t, 0f))
            {
                return 0f;
            }

            if (Mathf.Approximately(t, 1f))
            {
                return 1f;
            }

            return 1f - Mathf.Cos(t * Pi2);
        }

        public static float SineOut(this float t)
        {
            if (Mathf.Approximately(t, 0f))
            {
                return 0f;
            }

            if (Mathf.Approximately(t, 1f))
            {
                return 1f;
            }

            return Mathf.Sin(t * Pi2);
        }

        public static float SineInOut(this float t)
        {
            if (Mathf.Approximately(t, 0f))
            {
                return 0f;
            }

            if (Mathf.Approximately(t, 1f))
            {
                return 1f;
            }

            return -0.5f * (Mathf.Cos(Pi * t) - 1f);
        }

        public static float SineOutIn(this float t)
        {
            if (Mathf.Approximately(t, 0f))
            {
                return 0f;
            }

            if (Mathf.Approximately(t, 1f))
            {
                return 1f;
            }

            if (t < 0.5f)
            {
                return 0.5f * Mathf.Sin((t * 2f) * Pi2);
            }

            return -0.5f * Mathf.Cos((t * 2f - 1f) * Pi2) + 1f;
        }

        // Quad
        public static float QuadIn(this float t)
        {
            return t * t;
        }

        public static float QuadOut(this float t)
        {
            return -t * (t - 2f);
        }

        public static float QuadInOut(this float t)
        {
            return (t < 0.5f) ? 2f * t * t : -2f * ((t -= 1f) * t) + 1f;
        }

        public static float QuadOutIn(this float t)
        {
            return (t < 0.5f)
                ? -0.5f * (t = (t * 2f)) * (t - 2f)
                : 0.5f * (t = (t * 2f - 1f)) * t + 0.5f;
        }

        // Cubic
        public static float CubicIn(this float t)
        {
            return t * t * t;
        }

        public static float CubicOut(this float t)
        {
            return (t -= 1f) * t * t + 1f;
        }

        public static float CubicInOut(this float t)
        {
            return ((t *= 2f) < 1f)
                ? 0.5f * t * t * t
                : 0.5f * ((t -= 2f) * t * t + 2f);
        }

        public static float CubicOutIn(this float t)
        {
            return 0.5f * ((t = t * 2f - 1f) * t * t + 1f);
        }

        // Quart
        public static float QuartIn(this float t)
        {
            return (t *= t) * t;
        }

        public static float QuartOut(this float t)
        {
            return 1f - (t = (t -= 1f) * t) * t;
        }

        public static float QuartInOut(this float t)
        {
            return ((t *= 2f) < 1f)
                ? 0.5f * (t *= t) * t
                : -0.5f * ((t = (t -= 2f) * t) * t - 2f);
        }

        public static float QuartOutIn(this float t)
        {
            return (t < 0.5f)
                ? -0.5f * (t = (t = t * 2f - 1f) * t) * t + 0.5f
                : 0.5f * (t = (t = t * 2f - 1f) * t) * t + 0.5f;
        }

        // Quint
        public static float QuintIn(this float t)
        {
            return t * (t *= t) * t;
        }

        public static float QuintOut(this float t)
        {
            return (t -= 1f) * (t *= t) * t + 1f;
        }

        public static float QuintInOut(this float t)
        {
            return ((t *= 2f) < 1f) ? 0.5f * t * (t *= t) * t : 0.5f * (t -= 2f) * (t *= t) * t + 1f;
        }

        public static float QuintOutIn(this float t)
        {
            return 0.5f * ((t = t * 2f - 1f) * (t *= t) * t + 1f);
        }

        // Expo
        public static float ExpoIn(this float t)
        {
            return Mathf.Approximately(t, 0f) ? 0f : Mathf.Exp(Ln2Ten * (t - 1f));
        }

        public static float ExpoOut(this float t)
        {
            return Mathf.Approximately(t, 1f) ? 1f : (1f - Mathf.Exp(-Ln2Ten * t));
        }

        public static float ExpoInOut(this float t)
        {
            if (Mathf.Approximately(t, 0f))
            {
                return 0f;
            }

            if (Mathf.Approximately(t, 1f))
            {
                return 1f;
            }

            if ((t *= 2f) < 1f)
            {
                return 0.5f * Mathf.Exp(Ln2Ten * (t - 1f));
            }

            return 0.5f * (2f - Mathf.Exp(-Ln2Ten * (t - 1f)));
        }

        public static float ExpoOutIn(this float t)
        {
            if (t < 0.5f)
            {
                return 0.5f * (1f - Mathf.Exp(-20f * Ln2 * t));
            }

            if (Mathf.Approximately(t, 0.5f))
            {
                return 0.5f;
            }

            return 0.5f * (Mathf.Exp(20f * Ln2 * (t - 1f)) + 1f);
        }

        // Circ
        public static float CircIn(this float t)
        {
            return (t < -1f || 1f < t) ? 0f : 1f - Mathf.Sqrt(1f - t * t);
        }

        public static float CircOut(this float t)
        {
            return (t < 0f || 2f < t) ? 0f : Mathf.Sqrt(t * (2f - t));
        }

        public static float CircInOut(this float t)
        {
            if (t < -0.5f || 1.5f < t)
            {
                return 0.5f;
            }

            if ((t *= 2f) < 1f)
            {
                return -0.5f * (Mathf.Sqrt(1f - t * t) - 1f);
            }

            return 0.5f * (Mathf.Sqrt(1f - (t -= 2f) * t) + 1f);
        }

        public static float CircOutIn(this float t)
        {
            if (t < 0f)
            {
                return 0f;
            }

            if (1f < t)
            {
                return 1f;
            }

            if (t < 0.5f)
            {
                return 0.5f * Mathf.Sqrt(1f - (t = t * 2f - 1f) * t);
            }

            return -0.5f * ((Mathf.Sqrt(1f - (t = t * 2f - 1f) * t) - 1f) - 1f);
        }

        // Bounce
        public static float BounceIn(this float t)
        {
            if ((t = 1f - t) < (1f / 2.75f))
            {
                return 1f - ((7.5625f * t * t));
            }

            if (t < (2f / 2.75f))
            {
                return 1f - ((7.5625f * (t -= (1.5f / 2.75f)) * t + 0.75f));
            }

            if (t < (2.5f / 2.75f))
            {
                return 1f - ((7.5625f * (t -= (2.25f / 2.75f)) * t + 0.9375f));
            }

            return 1f - ((7.5625f * (t -= (2.625f / 2.75f)) * t + 0.984375f));
        }

        public static float BounceOut(this float t)
        {
            if (t < (1f / 2.75f))
            {
                return (7.5625f * t * t);
            }

            if (t < (2f / 2.75f))
            {
                return (7.5625f * (t -= (1.5f / 2.75f)) * t + 0.75f);
            }

            if (t < (2.5f / 2.75f))
            {
                return (7.5625f * (t -= (2.25f / 2.75f)) * t + 0.9375f);
            }

            return (7.5625f * (t -= (2.625f / 2.75f)) * t + 0.984375f);
        }

        public static float BounceInOut(this float t)
        {
            if (t < 0.5f)
            {
                if ((t = (1f - t * 2f)) < (1f / 2.75f))
                {
                    return (1f - ((7.5625f * t * t))) * 0.5f;
                }

                if (t < (2f / 2.75f))
                {
                    return (1f - ((7.5625f * (t -= (1.5f / 2.75f)) * t + 0.75f))) * 0.5f;
                }

                if (t < (2.5f / 2.75f))
                {
                    return (1f - ((7.5625f * (t -= (2.25f / 2.75f)) * t + 0.9375f))) * 0.5f;
                }

                return (1f - ((7.5625f * (t -= (2.625f / 2.75f)) * t + 0.984375f))) * 0.5f;
            }

            if ((t = (t * 2f - 1f)) < (1f / 2.75f))
            {
                return ((7.5625f * t * t)) * 0.5f + 0.5f;
            }

            if (t < (2f / 2.75f))
            {
                return ((7.5625f * (t -= (1.5f / 2.75f)) * t + 0.75f)) * 0.5f + 0.5f;
            }

            if (t < (2.5f / 2.75f))
            {
                return ((7.5625f * (t -= (2.25f / 2.75f)) * t + 0.9375f)) * 0.5f + 0.5f;
            }

            return ((7.5625f * (t -= (2.625f / 2.75f)) * t + 0.984375f)) * 0.5f + 0.5f;
        }

        public static float BounceOutIn(this float t)
        {
            if (t < 0.5f)
            {
                if ((t = (t * 2f)) < (1f / 2.75f))
                {
                    return 0.5f * (7.5625f * t * t);
                }

                if (t < (2f / 2.75f))
                {
                    return 0.5f * (7.5625f * (t -= (1.5f / 2.75f)) * t + 0.75f);
                }

                if (t < (2.5f / 2.75f))
                {
                    return 0.5f * (7.5625f * (t -= (2.25f / 2.75f)) * t + 0.9375f);
                }

                return 0.5f * (7.5625f * (t -= (2.625f / 2.75f)) * t + 0.984375f);
            }

            if ((t = (1f - (t * 2f - 1f))) < (1f / 2.75f))
            {
                return 0.5f - (0.5f * (7.5625f * t * t)) + 0.5f;
            }

            if (t < (2f / 2.75f))
            {
                return 0.5f - (0.5f * (7.5625f * (t -= (1.5f / 2.75f)) * t + 0.75f)) + 0.5f;
            }

            if (t < (2.5f / 2.75f))
            {
                return 0.5f - (0.5f * (7.5625f * (t -= (2.25f / 2.75f)) * t + 0.9375f)) + 0.5f;
            }

            return 0.5f - (0.5f * (7.5625f * (t -= (2.625f / 2.75f)) * t + 0.984375f)) + 0.5f;
        }

        // Back
        public static float BackIn(this float t)
        {
            if (Mathf.Approximately(t, 0f))
            {
                return 0f;
            }

            if (Mathf.Approximately(t, 1f))
            {
                return 1f;
            }

            return t * t * ((Overshoot + 1f) * t - Overshoot);
        }

        public static float BackOut(this float t)
        {
            if (Mathf.Approximately(t, 0f))
            {
                return 0f;
            }

            if (Mathf.Approximately(t, 1f))
            {
                return 1f;
            }

            return ((t -= 1f) * t * ((Overshoot + 1f) * t + Overshoot) + 1f);
        }

        public static float BackInOut(this float t)
        {
            if (Mathf.Approximately(t, 0f))
            {
                return 0f;
            }

            if (Mathf.Approximately(t, 1f))
            {
                return 1f;
            }

            if ((t *= 2f) < 1f)
            {
                return 0.5f * (t * t * (((Overshoot * 0.984375f) + 1f) * t - Overshoot * 1.525f));
            }

            return 0.5f * ((t -= 2f) * t * (((Overshoot * 1.525f) + 1f) * t + Overshoot * 1.525f) + 2f);
        }

        public static float BackOutIn(this float t)
        {
            if (Mathf.Approximately(t, 0f))
            {
                return 0f;
            }

            if (Mathf.Approximately(t, 1f))
            {
                return 1f;
            }

            if (t < 0.5f)
            {
                return 0.5f * ((t = t * 2f - 1f) * t * ((Overshoot + 1f) * t + Overshoot) + 1f);
            }

            return 0.5f * (t = t * 2f - 1f) * t * ((Overshoot + 1f) * t - Overshoot) + 0.5f;
        }

        // Elastic
        public static float ElasticIn(this float t)
        {
            if (Mathf.Approximately(t, 0f))
            {
                return 0f;
            }

            if (Mathf.Approximately(t, 1f))
            {
                return 1f;
            }

            const float s = Period / 4f;
            return -(Amplitude *
                     Mathf.Exp(Ln2Ten * (t -= 1f)) *
                     Mathf.Sin((t * 0.001f - s) * (2f * Pi) / Period));
        }

        public static float ElasticOut(this float t)
        {
            if (Mathf.Approximately(t, 0f))
            {
                return 0f;
            }

            if (Mathf.Approximately(t, 1f))
            {
                return 1f;
            }

            const float s = Period / 4f;
            return Mathf.Exp(-Ln2Ten * t) * Mathf.Sin((t * 0.001f - s) * (2f * Pi) / Period) + 1f;
        }

        public static float ElasticInOut(this float t)
        {
            if (Mathf.Approximately(t, 0f))
            {
                return 0f;
            }

            if (Mathf.Approximately(t, 1f))
            {
                return 1f;
            }

            const float s = Period / 4f;

            if ((t *= 2f) < 1f)
            {
                return -0.5f * (Amplitude * Mathf.Exp(Ln2Ten * (t -= 1f)) *
                                Mathf.Sin((t * 0.001f - s) * (2f * Pi) / Period));
            }

            return Amplitude * Mathf.Exp(-Ln2Ten * (t -= 1f)) *
                   Mathf.Sin((t * 0.001f - s) * (2f * Pi) / Period) * 0.5f + 1f;
        }

        public static float ElasticOutIn(this float t)
        {
            if (t < 0.5f)
            {
                if (Mathf.Approximately((t *= 2f), 0f))
                {
                    return 0f;
                }

                return ((Amplitude / 2f) *
                        Mathf.Exp(-Ln2Ten * t) *
                        Mathf.Sin((t * 0.001f - Period / 4f) * (2f * Pi) / Period)) +
                       0.5f;
            }

            if (Mathf.Approximately(t, 0.5f))
            {
                return 0.5f;
            }

            if (Mathf.Approximately(t, 1f))
            {
                return 1f;
            }

            {
                t = t * 2f - 1f;
                return -((Amplitude / 2f) *
                         Mathf.Exp(Ln2Ten * (t -= 1f)) *
                         Mathf.Sin((t * 0.001f - Period / 4f) * (2f * Pi) / Period)) +
                       0.5f;
            }
        }

        // Warp
        public static float WarpOut(this float t)
        {
            return t <= 0f ? 0f : 1f;
        }

        public static float WarpIn(this float t)
        {
            return t < 1f ? 0f : 1f;
        }

        public static float WarpInOut(this float t)
        {
            return t < 0.5f ? 0f : 1f;
        }

        public static float WarpOutIn(this float t)
        {
            if (t <= 0f)
            {
                return 0f;
            }

            return t < 1f ? 0.5f : 1f;
        }
    }
}