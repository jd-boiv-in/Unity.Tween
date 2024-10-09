using JD.Extensions;
using jd.boivin.unity.text;
using TMPro;
using UnityEngine;

namespace JD.Tween
{
    public class TextMeshProTween : Tween
    {
        public TextMeshPro Target;
        public bool Optimized;

        public Color StartColor;
        public Color EndColor;
        
        public Vector3 StartV3;
        public Vector3 EndV3;
        
        protected override void SetProperty()
        {
            // Necessary? The tradeoff of checking every frame the hierarchy might be not worth it?
            //if (!Target.gameObject.activeInHierarchy) return;
            
            var t = Duration <= 0 ? 1 : (Timer / Duration).Ease(Ease);
            switch (Property)
            {
                case TweenProperty.Alpha:
                {
                    var value = Start + (End - Start) * t;
                    SetAlpha(value);
                    //Target.alpha = value;
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.X:
                {
                    var value = Start + (End - Start) * t;
                    Target.transform.localPosition = Target.transform.localPosition.SetX(value);
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.Y:
                {
                    var value = Start + (End - Start) * t;
                    Target.transform.localPosition = Target.transform.localPosition.SetY(value);
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.XY:
                {
                    var value = StartV3 + (EndV3 - StartV3) * t;
                    Target.transform.localPosition = value;
                    OnSetV3Handler?.Invoke(value);
                    break;
                }
                case TweenProperty.Color:
                {
                    var value = Color.Lerp(StartColor, EndColor, t);
                    SetColor(value);
                    //Target.color = value;
                    OnSetColorHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.Scale:
                {
                    var value = Start + (End - Start) * t;
                    Target.transform.localScale = value.ToV3();
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.ScaleX:
                {
                    var value = Start + (End - Start) * t;
                    Target.transform.SetScaleX(value);
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.ScaleY:
                {
                    var value = Start + (End - Start) * t;
                    Target.transform.SetScaleY(value);
                    OnSetHandler?.Invoke(value);
                    break;
                }
            }
        }
        
        private void SetColor(Color32 color)
        {
            if (Optimized) ((TextMeshWorld) Target).SetColor(color);
            else Target.color = color;
        }
        
        private void SetAlpha(float value)
        {
            if (Optimized) ((TextMeshWorld) Target).SetAlpha(value);
            else Target.alpha = value;
        }
        
        protected override bool IsAlive()
        {
            return Target != null;
        }
        
        protected override void Return()
        {
            Tweens.Instance.ReturnTextMeshPro(this);
        }

        public override void Clear()
        {
            base.Clear();

            Optimized = false;
            StartColor = Color.white;
            EndColor = Color.white;
            StartV3 = Vector3.zero;
            EndV3 = Vector3.zero;
            Target = null;
        }
    }
}