using JD.Extensions;
using UnityEngine;

namespace JD.Tween
{
    public class CameraTween : Tween
    {
        public Camera Target;

        protected override void SetProperty()
        {
            // Necessary? The tradeoff of checking every frame the hierarchy might be not worth it?
            //if (!Target.gameObject.activeInHierarchy) return;
            
            var t = Duration <= 0 ? 1 : (Timer / Duration).Ease(Ease);
            switch (Property)
            {
                case TweenProperty.OrthographicSize:
                {
                    var value = Start + (End - Start) * t;
                    Target.orthographicSize = value;
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
            Tweens.Instance.ReturnCamera(this);
        }

        public override void Clear()
        {
            base.Clear();

            Target = null;
        }
    }
}