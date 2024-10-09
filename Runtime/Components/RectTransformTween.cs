using JD.Extensions;
using UnityEngine;

namespace JD.Tween
{
    public class RectTransformTween : Tween
    {
        public RectTransform Target;

        public Vector2 StartV2;
        public Vector2 EndV2;
        
        public Vector3 StartV3;
        public Vector3 EndV3;
        
        protected override void SetProperty()
        {
            // Necessary? The tradeoff of checking every frame the hierarchy might be not worth it?
            //if (!Target.gameObject.activeInHierarchy) return;
            
            var t = Duration <= 0 ? 1 : (Timer / Duration).Ease(Ease);
            switch (Property)
            {
                case TweenProperty.Rotation:
                {
                    var value = Start + (End - Start) * t;
                    Target.localEulerAngles = Target.localEulerAngles.SetZ(value);
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.X:
                {
                    var value = Start + (End - Start) * t;
                    Target.localPosition = Target.localPosition.SetX(value);
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.Y:
                {
                    var value = Start + (End - Start) * t;
                    Target.localPosition = Target.localPosition.SetY(value);
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.XY:
                {
                    var value = StartV3 + (EndV3 - StartV3) * t;
                    Target.localPosition = value;
                    OnSetV3Handler?.Invoke(value);
                    break;
                }
                case TweenProperty.AnchorX:
                {
                    var value = Start + (End - Start) * t;
                    Target.anchoredPosition = Target.anchoredPosition.SetX(value);
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.AnchorY:
                {
                    var value = Start + (End - Start) * t;
                    Target.anchoredPosition = Target.anchoredPosition.SetY(value);
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.Scale:
                {
                    var value = Start + (End - Start) * t;
                    Target.localScale = new Vector3(value, value, value);
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.ScaleV3:
                {
                    var value = StartV3 + (EndV3 - StartV3) * t;
                    Target.localScale = value;
                    OnSetV3Handler?.Invoke(value);
                    break;
                }
                case TweenProperty.ScaleX:
                {
                    var value = Start + (End - Start) * t;
                    Target.localScale = Target.localScale.SetX(value);
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.ScaleY:
                {
                    var value = Start + (End - Start) * t;
                    Target.localScale = Target.localScale.SetY(value);
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.Size:
                {
                    var value = StartV2 + (EndV2 - StartV2) * t;
                    Target.sizeDelta = value;
                    OnSetV2Handler?.Invoke(value);
                    break;
                }
                case TweenProperty.Top:
                {
                    var value = Start + (End - Start) * t;
                    Target.offsetMax = Target.offsetMax.SetY(value);
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.Bottom:
                {
                    var value = Start + (End - Start) * t;
                    Target.offsetMin = Target.offsetMin.SetY(value);
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.Left:
                {
                    var value = Start + (End - Start) * t;
                    Target.offsetMin = Target.offsetMin.SetX(value);
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.Right:
                {
                    var value = Start + (End - Start) * t;
                    Target.offsetMax = Target.offsetMax.SetX(value);
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.OffsetMin:
                {
                    var value = StartV2 + (EndV2 - StartV2) * t;
                    Target.offsetMin = value;
                    OnSetV2Handler?.Invoke(value);
                    break;
                }
                case TweenProperty.OffsetMax:
                {
                    var value = StartV2 + (EndV2 - StartV2) * t;
                    Target.offsetMax = value;
                    OnSetV2Handler?.Invoke(value);
                    break;
                }
                case TweenProperty.AnchorMax:
                {
                    var value = StartV2 + (EndV2 - StartV2) * t;
                    Target.anchorMax = value;
                    OnSetV2Handler?.Invoke(value);
                    break;
                }
            }
        }
        
        protected override bool IsAlive()
        {
            return Target != null;
        }
        
        protected override void Return()
        {
            Tweens.Instance.ReturnRectTransform(this);
        }

        public override void Clear()
        {
            base.Clear();

            Target = null;
            StartV2 = Vector2.zero;
            EndV2 = Vector2.zero;
            StartV3 = Vector3.zero;
            EndV3 = Vector3.zero;
        }
    }
}