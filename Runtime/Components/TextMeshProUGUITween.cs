using JD.Extensions;
using JD.Text;
using TMPro;
using UnityEngine;

namespace JD.Tween
{
    public class TextMeshProUGUITween : Tween
    {
        public TextMeshProUGUI Target;
        public bool Optimized;

        public Color StartColor;
        public Color EndColor;
        
        protected override void SetProperty()
        {
            // Necessary? The tradeoff of checking every frame the hierarchy might be not worth it?
            //if (!Target.gameObject.activeInHierarchy) return;
            
            var t = Duration <= 0 ? 1 : (Timer / Duration).Ease(Ease);
            switch (Property)
            {
                case TweenProperty.Text:
                {
                    var value = Start + (End - Start) * t;
                    Target.SetText("{0}", Mathf.RoundToInt(value));
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.Alpha:
                {
                    var value = Start + (End - Start) * t;
                    SetAlpha(value);
                    //Target.alpha = value;
                    OnSetHandler?.Invoke(value);
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
                case TweenProperty.ColorNoAlpha:
                {
                    var value = Color.Lerp(StartColor, EndColor, t);
                    value.a = Target.color.a;
                    SetColor(value);
                    //Target.color = value;
                    OnSetColorHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.Scale:
                {
                    var value = Start + (End - Start) * t;
                    Target.rectTransform.localScale = new Vector3(value, value, value);
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.ScaleX:
                {
                    var value = Start + (End - Start) * t;
                    var trs = Target.rectTransform;
                    trs.localScale = trs.localScale.SetX(value);
                    OnSetHandler?.Invoke(value);
                    break;
                }
                case TweenProperty.ScaleY:
                {
                    var value = Start + (End - Start) * t;
                    var trs = Target.rectTransform;
                    trs.localScale = trs.localScale.SetY(value);
                    OnSetHandler?.Invoke(value);
                    break;
                }
            }
        }

        // Really puzzling why this is isn't this way by default...
        // Basically, changing color / alpha means we need to rebuild every texts...
        private void SetColor(Color32 color)
        {
            if (Optimized) ((TextMeshUI) Target).SetColor(color);
            else Target.color = color;
        }
        
        private void SetAlpha(float value)
        {
            if (Optimized) ((TextMeshUI) Target).SetAlpha(value);
            else Target.alpha = value;
        }
        
        protected override bool IsAlive()
        {
            return Target != null;
        }
        
        protected override void Return()
        {
            Tweens.Instance.ReturnTextMeshProUGUI(this);
        }

        public override void Clear()
        {
            base.Clear();
            
            Optimized = false;
            StartColor = Color.white;
            EndColor = Color.white;
            Target = null;
        }
    }
}