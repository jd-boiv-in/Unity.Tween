using JD.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace JD.Tween
{
    public class GraphicTween : Tween
    {
        public Graphic Target;
        
        public Color StartColor;
        public Color EndColor;

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
                    Target.color = Target.color.ToAlpha(value);
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.Color:
                {
                    var value = Color.Lerp(StartColor, EndColor, t);
                    Target.color = value;
                    OnSetColorHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.ColorNoAlpha:
                {
                    var value = Color.Lerp(StartColor, EndColor, t);
                    value.a = Target.color.a;
                    Target.color = value;
                    OnSetColorHandler?.Invoke(value);
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
            Tweens.Instance.ReturnGraphic(this);
        }

        public override void Clear()
        {
            base.Clear();

            StartColor = Color.white;
            EndColor = Color.white;
            Target = null;
        }
    }
}