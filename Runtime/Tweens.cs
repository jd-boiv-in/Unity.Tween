using System.Collections.Generic;
using UnityEngine;

namespace JD.Tween
{
    // A small replacement for DOTweenPro since it was allocating / was not performant enough imho
    // We only use a handful of different class to which we tween on so we create a small override / pool for each
    // Shouldn't alloc + everything is in one place so easy to remove all (`DOKill` was a pain...)
    public class Tweens
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void ResetStatic()
        {
            _instance = new Tweens();
            HasInstance = true;
            
            Time = 0;
            RealTime = 0;
            FakeTime = 0;
            FakingTime = false;
        }

        public static Tweens Load()
        {
            if (HasInstance) return _instance;
            
            _instance = new Tweens();
            HasInstance = true;
            return _instance;
        }
        
        public static int IdCounter = 0;
        
        public static float Time;
        public static float RealTime;
        public static float FakeTime;
        public static bool FakingTime;
        
        public static bool HasInstance;
        private static Tweens _instance;
        public static Tweens Instance
        {
            get
            {
#if UNITY_EDITOR
                // Annoying issue with `[ExecuteAlways]` in editor since the instance doesn't exist yet...
                if (!HasInstance)
                {
                    HasInstance = true;
                    _instance = new Tweens();
                }
#endif
                return _instance;
            }
        }

        public readonly Queue<TweenCallback> OnComplete = new Queue<TweenCallback>(5);
        
        public TweenPoolStats GetStats()
        {
            var all = AddStats(_poolRectTransform.GetStats(), _poolImage.GetStats());
            all = AddStats(all, _poolCanvasGroup.GetStats());
            all = AddStats(all, _poolTextMeshProUGUI.GetStats());
            all = AddStats(all, _poolGraphic.GetStats());
            all = AddStats(all, _poolTextMeshPro.GetStats());
            all = AddStats(all, _poolTransform.GetStats());
            all = AddStats(all, _poolSprite.GetStats());
            all = AddStats(all, _poolCamera.GetStats());
            all = AddStats(all, _poolMaterial.GetStats());
            return all;
        }

        public string GetStatsString()
        {
            var stats = GetStats();
            return $"Current: {stats.Total}, Refs: {stats.Refs} ({stats.MinList} / {stats.MaxList}), Removing: {stats.Removing}, Lifetime: {stats.TotalLifetime}, Pool: {stats.Pool} ({stats.PoolList})";
        }
        
        private TweenPoolStats AddStats(TweenPoolStats a, TweenPoolStats b)
        {
            return new TweenPoolStats()
            {
                Total = a.Total + b.Total,
                Refs = a.Refs + b.Refs,
                MaxList = Mathf.Max(a.MaxList, b.MaxList),
                MinList = Mathf.Min(a.MinList, b.MinList),
                Removing = a.Removing + b.Removing,
                TotalLifetime = a.TotalLifetime + b.TotalLifetime,
                Pool = a.Pool + b.Pool,
                PoolList = a.PoolList + b.PoolList
            };
        }

        // RectTransform
        private readonly TweenPool<RectTransformTween> _poolRectTransform = new TweenPool<RectTransformTween>(25);
        public RectTransformTween GetRectTransform(int targetId, TweenProperty property) => _poolRectTransform.Get(targetId, property);
        public bool TryGetRectTransform(int targetId, TweenProperty property, out RectTransformTween tween) => _poolRectTransform.TryGet(targetId, property, out tween);
        public bool HasRectTransform(int targetId, TweenProperty property) => _poolRectTransform.Has(targetId, property);
        public bool ReturnRectTransform(RectTransformTween tween) => _poolRectTransform.Return(tween);
        public bool ReturnRectTransform(int targetId, bool complete = false) => _poolRectTransform.Return(targetId, true, complete);
        public bool ReturnRectTransform(int targetId, TweenProperty property, bool complete = false) => _poolRectTransform.Return(targetId, property, true, complete);
        
        // Transform
        private readonly TweenPool<TransformTween> _poolTransform = new TweenPool<TransformTween>(25);
        public TransformTween GetTransform(int targetId, TweenProperty property) => _poolTransform.Get(targetId, property);
        public bool TryGetTransform(int targetId, TweenProperty property, out TransformTween tween) => _poolTransform.TryGet(targetId, property, out tween);
        public bool HasTransform(int targetId, TweenProperty property) => _poolTransform.Has(targetId, property);
        public bool ReturnTransform(TransformTween tween) => _poolTransform.Return(tween);
        public bool ReturnTransform(int targetId, bool complete = false) => _poolTransform.Return(targetId, true, complete);
        public bool ReturnTransform(int targetId, TweenProperty property, bool complete = false) => _poolTransform.Return(targetId, property, true, complete);

        // Image
        private readonly TweenPool<ImageTween> _poolImage = new TweenPool<ImageTween>(25);
        public ImageTween GetImage(int targetId, TweenProperty property) => _poolImage.Get(targetId, property);
        public bool TryGetImage(int targetId, TweenProperty property, out ImageTween tween) => _poolImage.TryGet(targetId, property, out tween);
        public bool HasImage(int targetId, TweenProperty property) => _poolImage.Has(targetId, property);
        public bool ReturnImage(ImageTween tween) => _poolImage.Return(tween);
        public bool ReturnImage(int targetId, bool complete = false) => _poolImage.Return(targetId, true, complete);
        public bool ReturnImage(int targetId, TweenProperty property, bool complete = false) => _poolImage.Return(targetId, property, true, complete);
        
        // CanvasGroup
        private readonly TweenPool<CanvasGroupTween> _poolCanvasGroup = new TweenPool<CanvasGroupTween>(25);
        public CanvasGroupTween GetCanvasGroup(int targetId, TweenProperty property) => _poolCanvasGroup.Get(targetId, property);
        public bool TryGetCanvasGroup(int targetId, TweenProperty property, out CanvasGroupTween tween) => _poolCanvasGroup.TryGet(targetId, property, out tween);
        public bool HasCanvasGroup(int targetId, TweenProperty property) => _poolCanvasGroup.Has(targetId, property);
        public bool ReturnCanvasGroup(CanvasGroupTween tween) => _poolCanvasGroup.Return(tween);
        public bool ReturnCanvasGroup(int targetId, bool complete = false) => _poolCanvasGroup.Return(targetId, true, complete);
        public bool ReturnCanvasGroup(int targetId, TweenProperty property, bool complete = false) => _poolCanvasGroup.Return(targetId, property, true, complete);

        // TextMeshProUGUI
        private readonly TweenPool<TextMeshProUGUITween> _poolTextMeshProUGUI = new TweenPool<TextMeshProUGUITween>(25);
        public TextMeshProUGUITween GetTextMeshProUGUI(int targetId, TweenProperty property) => _poolTextMeshProUGUI.Get(targetId, property);
        public bool TryGetTextMeshProUGUI(int targetId, TweenProperty property, out TextMeshProUGUITween tween) => _poolTextMeshProUGUI.TryGet(targetId, property, out tween);
        public bool HasTextMeshProUGUI(int targetId, TweenProperty property) => _poolTextMeshProUGUI.Has(targetId, property);
        public bool ReturnTextMeshProUGUI(TextMeshProUGUITween tween) => _poolTextMeshProUGUI.Return(tween);
        public bool ReturnTextMeshProUGUI(int targetId, bool complete = false) => _poolTextMeshProUGUI.Return(targetId, true, complete);
        public bool ReturnTextMeshProUGUI(int targetId, TweenProperty property, bool complete = false) => _poolTextMeshProUGUI.Return(targetId, property, true, complete);
        
        // Graphic
        private readonly TweenPool<GraphicTween> _poolGraphic = new TweenPool<GraphicTween>(25);
        public GraphicTween GetGraphic(int targetId, TweenProperty property) => _poolGraphic.Get(targetId, property);
        public bool TryGetGraphic(int targetId, TweenProperty property, out GraphicTween tween) => _poolGraphic.TryGet(targetId, property, out tween);
        public bool HasGraphic(int targetId, TweenProperty property) => _poolGraphic.Has(targetId, property);
        public bool ReturnGraphic(GraphicTween tween) => _poolGraphic.Return(tween);
        public bool ReturnGraphic(int targetId, bool complete = false) => _poolGraphic.Return(targetId, true, complete);
        public bool ReturnGraphic(int targetId, TweenProperty property, bool complete = false) => _poolGraphic.Return(targetId, property, true, complete);
        
        // TextMeshPro
        private readonly TweenPool<TextMeshProTween> _poolTextMeshPro = new TweenPool<TextMeshProTween>(25);
        public TextMeshProTween GetTextMeshPro(int targetId, TweenProperty property) => _poolTextMeshPro.Get(targetId, property);
        public bool TryGetTextMeshPro(int targetId, TweenProperty property, out TextMeshProTween tween) => _poolTextMeshPro.TryGet(targetId, property, out tween);
        public bool HasTextMeshPro(int targetId, TweenProperty property) => _poolTextMeshPro.Has(targetId, property);
        public bool ReturnTextMeshPro(TextMeshProTween tween) => _poolTextMeshPro.Return(tween);
        public bool ReturnTextMeshPro(int targetId, bool complete = false) => _poolTextMeshPro.Return(targetId, true, complete);
        public bool ReturnTextMeshPro(int targetId, TweenProperty property, bool complete = false) => _poolTextMeshPro.Return(targetId, property, true, complete);
        
        // SpriteRenderer
        private readonly TweenPool<SpriteTween> _poolSprite = new TweenPool<SpriteTween>(25);
        public SpriteTween GetSprite(int targetId, TweenProperty property) => _poolSprite.Get(targetId, property);
        public bool TryGetSprite(int targetId, TweenProperty property, out SpriteTween tween) => _poolSprite.TryGet(targetId, property, out tween);
        public bool HasSprite(int targetId, TweenProperty property) => _poolSprite.Has(targetId, property);
        public bool ReturnSprite(SpriteTween tween) => _poolSprite.Return(tween);
        public bool ReturnSprite(int targetId, bool complete = false) => _poolSprite.Return(targetId, true, complete);
        public bool ReturnSprite(int targetId, TweenProperty property, bool complete = false) => _poolSprite.Return(targetId, property, true, complete);
        
        // Camera
        private readonly TweenPool<CameraTween> _poolCamera = new TweenPool<CameraTween>(25);
        public CameraTween GetCamera(int targetId, TweenProperty property) => _poolCamera.Get(targetId, property);
        public bool TryGetCamera(int targetId, TweenProperty property, out CameraTween tween) => _poolCamera.TryGet(targetId, property, out tween);
        public bool HasCamera(int targetId, TweenProperty property) => _poolCamera.Has(targetId, property);
        public bool ReturnCamera(CameraTween tween) => _poolCamera.Return(tween);
        public bool ReturnCamera(int targetId, bool complete = false) => _poolCamera.Return(targetId, true, complete);
        public bool ReturnCamera(int targetId, TweenProperty property, bool complete = false) => _poolCamera.Return(targetId, property, true, complete);
        
        // Material
        private readonly TweenPool<MaterialTween> _poolMaterial = new TweenPool<MaterialTween>(25);
        public MaterialTween GetMaterial(int targetId, TweenProperty property) => _poolMaterial.Get(targetId, property);
        public bool TryGetMaterial(int targetId, TweenProperty property, out MaterialTween tween) => _poolMaterial.TryGet(targetId, property, out tween);
        public bool HasMaterial(int targetId, TweenProperty property) => _poolMaterial.Has(targetId, property);
        public bool ReturnMaterial(MaterialTween tween) => _poolMaterial.Return(tween);
        public bool ReturnMaterial(int targetId, bool complete = false) => _poolMaterial.Return(targetId, true, complete);
        public bool ReturnMaterial(int targetId, TweenProperty property, bool complete = false) => _poolMaterial.Return(targetId, property, true, complete);
        
        public void KillAll()
        {
            _poolRectTransform.KillAll();
            _poolImage.KillAll();
            _poolCanvasGroup.KillAll();
            _poolTextMeshProUGUI.KillAll();
            _poolGraphic.KillAll();
            _poolTextMeshPro.KillAll();
            _poolTransform.KillAll();
            _poolSprite.KillAll();
            _poolCamera.KillAll();
            _poolMaterial.KillAll();
        }
        
        public void Update()
        {
            Time = RealTime = FakeTime = UnityEngine.Time.time;
            
            var delta = UnityEngine.Time.deltaTime;
            
            _poolRectTransform.Update(delta);
            _poolTransform.Update(delta);
            _poolImage.Update(delta);
            _poolCanvasGroup.Update(delta);
            _poolTextMeshProUGUI.Update(delta);
            _poolGraphic.Update(delta);
            _poolTextMeshPro.Update(delta);
            _poolSprite.Update(delta);
            _poolCamera.Update(delta);
            _poolMaterial.Update(delta);
            
            // Delay `OnComplete` so we don't interfere with collection iterator
            while (OnComplete.Count > 0)
            {
                var a = OnComplete.Dequeue();
                a.Invoke();
            }
            
            //Debug.Log(GetStatsString());
        }
    }
}