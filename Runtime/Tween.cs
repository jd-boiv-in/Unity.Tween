using UnityEngine;

namespace JD.Tween
{
    public enum TweenProperty : int
    {
        None,
        Alpha,
        Color,
        ColorNoAlpha,
        X,
        Y,
        XY,
        WorldX,
        WorldY,
        WorldXY,
        Rotation,
        Scale,
        ScaleV3,
        ScaleX,
        ScaleY,
        AnchorX,
        AnchorY,
        Size,
        Top,
        Bottom,
        Left,
        Right,
        OffsetMin,
        OffsetMax,
        Text,
        AnchorMax,
        OrthographicSize,
        ColorA,
        ColorB,
        Float
    }
    
    public delegate void TweenSetter(float value);
    public delegate void TweenSetterV2(Vector2 value);
    public delegate void TweenSetterV3(Vector3 value);
    public delegate void TweenSetterColor(Color value);
    public delegate void TweenCallback();
    
    public class Tween
    {
        public readonly int Id = Tweens.IdCounter++;
        
        public int TargetId;
        public long RefId;

        public TweenProperty Property = TweenProperty.None;
        public Ease Ease = Ease.Linear;

        public float Timer;
        
        public float TimeStart;
        public float Duration;

        public float Delay;

        public bool Removing;
        public bool Removed;
        
        public bool OneFrameDelay = false;
        protected bool FirstFrame = false;
        
        // For UI animation (pressing buttons, etc.), it "feels" better with the timer after
        // But for game animation, the timer before feels better and prevent issue with very rapid tween (block dropping)
        public bool TimerBefore = false;
        
        // Usually it's on `float`
        public float Start;
        public float End;

        public TweenCallback OnCompleteHandler;
        public TweenSetter OnSetHandler;
        public TweenSetterV2 OnSetV2Handler;
        public TweenSetterV3 OnSetV3Handler;
        public TweenSetterColor OnSetColorHandler;

        private bool _wait;
        
        public bool Debug;

        public void Update(float delta)
        {
            // For Coroutines animations to fast-forward
            if (Tweens.FakingTime && !_wait)
            {
                _wait = true;

                Timer = Tweens.Time - (TimeStart + Delay);
                if (Timer < 0) Timer = 0;
                else if (Timer > Duration) Timer = Duration;
                
                Delay = TimeStart + Delay - Tweens.Time;
                if (Timer > 0) FirstFrame = true;

                if (Timer >= Duration && Duration > 0)
                {
                    // Issue is the target could've been deleted... So immediately return
                    if (!IsAlive())
                    {
                        Return();
                        return;
                    }
                }
            }
            
            if (!FirstFrame)
            {
                FirstFrame = true;
                if (OneFrameDelay) return;
            }

            if (Delay > 0)
            {
                Delay -= delta;
                if (Delay > 0) return;

                delta = -Delay;
            }

            if (TimerBefore)
            {
                Timer += delta;
                if (Timer >= Duration) Timer = Duration;
            }
            
            SetProperty();
            
            if (Timer >= Duration)
            {
                Timer = Duration;
                
                if (OnCompleteHandler != null)
                    Tweens.Instance.OnComplete.Enqueue(OnCompleteHandler);
                
                // Delay to prevent iterator issue
                //OnCompleteHandler?.Invoke();
                OnCompleteHandler = null;

                Return();
            }

            if (!TimerBefore)
            {
                Timer += delta;
                if (Timer >= Duration) Timer = Duration;
            }
        }

        public void Complete()
        {
            Timer = Duration;
            SetProperty();
        }

        public void Refresh()
        {
            SetProperty();
        }

        protected virtual void SetProperty()
        {
            // Override me ;)
        }
        
        protected virtual void Return()
        {
            // Override me ;)
        }
        
        protected virtual bool IsAlive()
        {
            // Override me ;)
            return true;
        }
        
        public Tween SetEase(Ease ease)
        {
            Ease = ease;
            return this;
        }

        public Tween SetDelay(float delay)
        {
            Delay = delay;
            return this;
        }

        public Tween OnComplete(TweenCallback handler)
        {
            OnCompleteHandler = handler;
            return this;
        }

        public Tween OnSet(TweenSetter handler)
        {
            OnSetHandler = handler;
            return this;
        }

        public Tween OnSetV2(TweenSetterV2 handler)
        {
            OnSetV2Handler = handler;
            return this;
        }

        public Tween OnSetV3(TweenSetterV3 handler)
        {
            OnSetV3Handler = handler;
            return this;
        }

        public Tween AddOneFrameDelay(bool value = true)
        {
            OneFrameDelay = value;
            return this;
        }

        public Tween SetTimerBefore()
        {
            TimerBefore = true;
            return this;
        }
        
        public Tween SetTimerAfter()
        {
            TimerBefore = false;
            return this;
        }

        public virtual void SoftClear()
        {
            Delay = 0f;
            
            _wait = false;
            
            TimerBefore = false;
            FirstFrame = false;
            OneFrameDelay = false;
            OnCompleteHandler = null;
            OnSetHandler = null;
            OnSetV2Handler = null;
            OnSetV3Handler = null;
            OnSetColorHandler = null;
        }
        
        public virtual void Clear()
        {
            TargetId = 0;
            RefId = 0;

            Property = TweenProperty.None;
            Ease = Ease.Linear;

            Timer = 0f;
            TimeStart = 0f;
            Duration = 0f;

            Delay = 0f;
            Start = 0f;
            End = 0f;
            
            OneFrameDelay = false;
            FirstFrame = false;
            Removing = false;
            Removed = false;
            
            TimerBefore = false;

            _wait = false;

            Debug = false;
            
            OnCompleteHandler = null;
            OnSetHandler = null;
            OnSetV2Handler = null;
            OnSetV3Handler = null;
            OnSetColorHandler = null;
        }
    }
}