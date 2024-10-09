using JD.Extensions;
using UnityEngine;

namespace JD.Tween
{
    public class MaterialTween : Tween
    {
        public Material Target;

        public int PropertyId;
        
        public Color StartColor;
        public Color EndColor;

        protected override void SetProperty()
        {
            // Necessary? The tradeoff of checking every frame the hierarchy might be not worth it?
            //if (!Target.gameObject.activeInHierarchy) return;
            
            var t = Duration <= 0 ? 1 : (Timer / Duration).Ease(Ease);
            switch (Property)
            {
                case TweenProperty.Color:
                case TweenProperty.ColorA:
                case TweenProperty.ColorB:
                {
                    var value = Color.Lerp(StartColor, EndColor, t);
                    Target.SetColor(PropertyId, value);
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
            Tweens.Instance.ReturnMaterial(this);
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