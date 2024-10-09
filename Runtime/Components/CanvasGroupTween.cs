using UnityEngine;

namespace JD.Tween
{
    public class CanvasGroupTween : Tween
    {
        public CanvasGroup Target;

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
                    Target.alpha = value;
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
            Tweens.Instance.ReturnCanvasGroup(this);
        }

        public override void Clear()
        {
            base.Clear();
            
            Target = null;
        }
    }
}