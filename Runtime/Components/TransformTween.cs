using JD.Extensions;
using UnityEngine;

namespace JD.Tween
{
    public class TransformTween : Tween
    {
        public Transform Target;

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
                    Target.rotation = Quaternion.Euler(Target.rotation.eulerAngles.SetZ(value));
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
                case TweenProperty.WorldX:
                {
                    var value = Start + (End - Start) * t;
                    Target.position.SetX(value);
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.WorldY:
                {
                    var value = Start + (End - Start) * t;
                    Target.position.SetY(value);
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.WorldXY:
                {
                    var value = StartV3 + (EndV3 - StartV3) * t;
                    Target.position = value;
                    OnSetV3Handler?.Invoke(value);
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
            }
        }
        
        protected override bool IsAlive()
        {
            return Target != null;
        }
        
        protected override void Return()
        {
            Tweens.Instance.ReturnTransform(this);
        }

        public override void Clear()
        {
            base.Clear();

            Target = null;
            StartV3 = Vector3.zero;
            EndV3 = Vector3.zero;
        }
    }
}