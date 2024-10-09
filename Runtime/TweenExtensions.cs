using jd.boivin.unity.text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JD.Tween
{
    // TODO: Add optimization on `duration` 0
    public static class TweenExtensions
    {
        // Sprite
        public static SpriteTween TweenFade(this SpriteRenderer sprite, float alpha, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetSprite(sprite.GetInstanceID(), TweenProperty.Alpha);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = sprite.color.a;
            tween.End = alpha;
            tween.Ease = ease;
            tween.TimerBefore = true;
            
            tween.Target = sprite;
            
            return tween;
        }
        
        public static SpriteTween TweenColor(this SpriteRenderer sprite, Color color, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetSprite(sprite.GetInstanceID(), TweenProperty.Color);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartColor = sprite.color;
            tween.EndColor = color;
            tween.Ease = ease;
            tween.TimerBefore = true;
            
            tween.Target = sprite;
            
            return tween;
        }
        
        public static TransformTween TweenScale(this SpriteRenderer sprite, float scale, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            return sprite.transform.TweenScale(scale, duration, ease);
        }
        
        public static TransformTween TweenScaleX(this SpriteRenderer sprite, float scale, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            return sprite.transform.TweenScaleX(scale, duration, ease);
        }
        
        public static TransformTween TweenScaleY(this SpriteRenderer sprite, float scale, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            return sprite.transform.TweenScaleY(scale, duration, ease);
        }
        
        public static TransformTween TweenLocalMove(this SpriteRenderer sprite, Vector3 move, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            return sprite.transform.TweenLocalMove(move, duration, ease);
        }
        
        public static TransformTween TweenLocalMoveX(this SpriteRenderer sprite, float x, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            return sprite.transform.TweenLocalMoveX(x, duration, ease);
        }
        
        public static TransformTween TweenLocalMoveY(this SpriteRenderer sprite, float y, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            return sprite.transform.TweenLocalMoveY(y, duration, ease);
        }
        
        public static bool TweenLocalOffsetX(this SpriteRenderer sprite, float x)
        {
            return sprite.transform.TweenLocalOffsetX(x);
        }
        
        public static bool TweenLocalOffsetY(this SpriteRenderer sprite, float y)
        {
            return sprite.transform.TweenLocalOffsetY(y);
        }
        
        public static bool TweenLocalOffset(this SpriteRenderer sprite, Vector3 offset)
        {
            return sprite.transform.TweenLocalOffset(offset);
        }
        
        public static bool TweenHas(this SpriteRenderer sprite, TweenProperty property)
        {
            return Tweens.Instance.HasSprite(sprite.GetInstanceID(), property);
        }
        
        public static bool TweenKill(this SpriteRenderer sprite, bool complete = false)
        {
            return Tweens.Instance.ReturnSprite(sprite.GetInstanceID(), complete);
        }
        
        public static bool TweenKill(this SpriteRenderer sprite, TweenProperty property, bool complete = false)
        {
            return Tweens.Instance.ReturnSprite(sprite.GetInstanceID(), property, complete);
        }
        
        // Graphic
        public static GraphicTween TweenFade(this Graphic graphic, float alpha, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetGraphic(graphic.GetInstanceID(), TweenProperty.Alpha);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = graphic.color.a;
            tween.End = alpha;
            tween.Ease = ease;
            
            tween.Target = graphic;
            
            return tween;
        }
        
        public static GraphicTween TweenColor(this Graphic graphic, Color color, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetGraphic(graphic.GetInstanceID(), TweenProperty.Color);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartColor = graphic.color;
            tween.EndColor = color;
            tween.Ease = ease;
            
            tween.Target = graphic;
            
            return tween;
        }
        
        public static GraphicTween TweenColorNoAlpha(this Graphic graphic, Color color, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetGraphic(graphic.GetInstanceID(), TweenProperty.ColorNoAlpha);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartColor = graphic.color;
            tween.EndColor = color;
            tween.Ease = ease;
            
            tween.Target = graphic;
            
            return tween;
        }
        
        public static bool TweenKill(this Graphic text, bool complete = false)
        {
            return Tweens.Instance.ReturnGraphic(text.GetInstanceID(), complete);
        }
        
        public static bool TweenKill(this Graphic text, TweenProperty property, bool complete = false)
        {
            return Tweens.Instance.ReturnGraphic(text.GetInstanceID(), property, complete);
        }
        
        // TextMeshUI
        public static TextMeshProUGUITween TweenText(this TextMeshUI text, int n, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetTextMeshProUGUI(text.GetInstanceID(), TweenProperty.Text);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = int.TryParse(text.text, out var result) ? result : 0;
            tween.End = n;
            tween.Ease = ease;
            
            tween.Target = text;
            tween.Optimized = true;
            
            return tween;
        }
        
        public static TextMeshProUGUITween TweenFade(this TextMeshUI text, float alpha, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetTextMeshProUGUI(text.GetInstanceID(), TweenProperty.Alpha);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = text.alpha;
            tween.End = alpha;
            tween.Ease = ease;
            
            tween.Target = text;
            tween.Optimized = true;
            
            return tween;
        }
        
        public static TextMeshProUGUITween TweenColor(this TextMeshUI text, Color color, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetTextMeshProUGUI(text.GetInstanceID(), TweenProperty.Color);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartColor = text.color;
            tween.EndColor = color;
            tween.Ease = ease;
            
            tween.Target = text;
            tween.Optimized = true;
            
            return tween;
        }
        
        public static TextMeshProUGUITween TweenColorNoAlpha(this TextMeshUI text, Color color, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetTextMeshProUGUI(text.GetInstanceID(), TweenProperty.ColorNoAlpha);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartColor = text.color;
            tween.EndColor = color;
            tween.Ease = ease;
            
            tween.Target = text;
            tween.Optimized = true;
            
            return tween;
        }
        
        public static TextMeshProUGUITween TweenScale(this TextMeshUI text, float scale, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTextMeshProUGUI(text.GetInstanceID(), TweenProperty.Scale);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = text.rectTransform.localScale.x;
            tween.End = scale;
            tween.Ease = ease;
            
            tween.Target = text;
            tween.Optimized = true;
            
            return tween;
        }
        
        public static bool TweenKill(this TextMeshUI text, bool complete = false)
        {
            return Tweens.Instance.ReturnTextMeshProUGUI(text.GetInstanceID(), complete);
        }
        
        public static bool TweenKill(this TextMeshUI text, TweenProperty property, bool complete = false)
        {
            return Tweens.Instance.ReturnTextMeshProUGUI(text.GetInstanceID(), property, complete);
        }
        
        // TextMeshWorld
        public static TextMeshProTween TweenFade(this TextMeshWorld text, float alpha, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetTextMeshPro(text.GetInstanceID(), TweenProperty.Alpha);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = text.alpha;
            tween.End = alpha;
            tween.Ease = ease;
            
            tween.Target = text;
            tween.Optimized = true;
            
            return tween;
        }
        
        public static TextMeshProTween TweenColor(this TextMeshWorld text, Color color, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetTextMeshPro(text.GetInstanceID(), TweenProperty.Color);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartColor = text.color;
            tween.EndColor = color;
            tween.Ease = ease;
            
            tween.Target = text;
            tween.Optimized = true;
            
            return tween;
        }
        
        public static TextMeshProTween TweenScale(this TextMeshWorld text, float scale, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTextMeshPro(text.GetInstanceID(), TweenProperty.Scale);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = text.transform.localScale.x;
            tween.End = scale;
            tween.Ease = ease;
            
            tween.Target = text;
            tween.Optimized = true;
            
            return tween;
        }
        
        public static TextMeshProTween TweenScaleX(this TextMeshWorld text, float scale, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTextMeshPro(text.GetInstanceID(), TweenProperty.ScaleX);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = text.transform.localScale.x;
            tween.End = scale;
            tween.Ease = ease;
            
            tween.Target = text;
            tween.Optimized = true;
            
            return tween;
        }
        
        public static TextMeshProTween TweenScaleY(this TextMeshWorld text, float scale, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTextMeshPro(text.GetInstanceID(), TweenProperty.ScaleY);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = text.transform.localScale.y;
            tween.End = scale;
            tween.Ease = ease;
            
            tween.Target = text;
            tween.Optimized = true;
            
            return tween;
        }
        
        public static TextMeshProTween TweenLocalMoveX(this TextMeshWorld text, float x, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTextMeshPro(text.GetInstanceID(), TweenProperty.X);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = text.transform.localPosition.x;
            tween.End = x;
            tween.Ease = ease;
            
            tween.Target = text;
            tween.Optimized = true;
            
            return tween;
        }
        
        public static TextMeshProTween TweenLocalMoveY(this TextMeshWorld text, float y, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTextMeshPro(text.GetInstanceID(), TweenProperty.Y);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = text.transform.localPosition.y;
            tween.End = y;
            tween.Ease = ease;
            
            tween.Target = text;
            tween.Optimized = true;
            
            return tween;
        }
        
        public static TextMeshProTween TweenLocalMove(this TextMeshWorld text, Vector3 move, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTextMeshPro(text.GetInstanceID(), TweenProperty.XY);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartV3 = text.transform.localPosition;
            tween.EndV3 = move;
            tween.Ease = ease;
            
            tween.Target = text;
            tween.Optimized = true;
            
            return tween;
        }
        
        public static bool TweenKill(this TextMeshWorld text, bool complete = false)
        {
            return Tweens.Instance.ReturnTextMeshPro(text.GetInstanceID(), complete);
        }
        
        public static bool TweenKill(this TextMeshWorld text, TweenProperty property, bool complete = false)
        {
            return Tweens.Instance.ReturnTextMeshPro(text.GetInstanceID(), property, complete);
        }
        
        // TextMeshProUGUI
        public static TextMeshProUGUITween TweenText(this TextMeshProUGUI text, int n, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetTextMeshProUGUI(text.GetInstanceID(), TweenProperty.Text);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = int.TryParse(text.text, out var result) ? result : 0;
            tween.End = n;
            tween.Ease = ease;
            
            tween.Target = text;
            
            return tween;
        }
        
        public static TextMeshProUGUITween TweenFade(this TextMeshProUGUI text, float alpha, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetTextMeshProUGUI(text.GetInstanceID(), TweenProperty.Alpha);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = text.alpha;
            tween.End = alpha;
            tween.Ease = ease;
            
            tween.Target = text;
            
            return tween;
        }
        
        public static TextMeshProUGUITween TweenColor(this TextMeshProUGUI text, Color color, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetTextMeshProUGUI(text.GetInstanceID(), TweenProperty.Color);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartColor = text.color;
            tween.EndColor = color;
            tween.Ease = ease;
            
            tween.Target = text;
            
            return tween;
        }
        
        public static TextMeshProUGUITween TweenColorNoAlpha(this TextMeshProUGUI text, Color color, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetTextMeshProUGUI(text.GetInstanceID(), TweenProperty.ColorNoAlpha);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartColor = text.color;
            tween.EndColor = color;
            tween.Ease = ease;
            
            tween.Target = text;
            
            return tween;
        }
        
        public static TextMeshProUGUITween TweenScale(this TextMeshProUGUI text, float scale, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTextMeshProUGUI(text.GetInstanceID(), TweenProperty.Scale);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = text.rectTransform.localScale.x;
            tween.End = scale;
            tween.Ease = ease;
            
            tween.Target = text;
            
            return tween;
        }
        
        public static bool TweenKill(this TextMeshProUGUI text, bool complete = false)
        {
            return Tweens.Instance.ReturnTextMeshProUGUI(text.GetInstanceID(), complete);
        }
        
        public static bool TweenKill(this TextMeshProUGUI text, TweenProperty property, bool complete = false)
        {
            return Tweens.Instance.ReturnTextMeshProUGUI(text.GetInstanceID(), property, complete);
        }
        
        // TextMeshPro
        public static TextMeshProTween TweenFade(this TextMeshPro text, float alpha, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetTextMeshPro(text.GetInstanceID(), TweenProperty.Alpha);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = text.alpha;
            tween.End = alpha;
            tween.Ease = ease;
            
            tween.Target = text;
            
            return tween;
        }
        
        public static TextMeshProTween TweenColor(this TextMeshPro text, Color color, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetTextMeshPro(text.GetInstanceID(), TweenProperty.Color);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartColor = text.color;
            tween.EndColor = color;
            tween.Ease = ease;
            
            tween.Target = text;
            
            return tween;
        }
        
        public static TextMeshProTween TweenScale(this TextMeshPro text, float scale, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTextMeshPro(text.GetInstanceID(), TweenProperty.Scale);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = text.transform.localScale.x;
            tween.End = scale;
            tween.Ease = ease;
            
            tween.Target = text;
            
            return tween;
        }
        
        public static TextMeshProTween TweenScaleX(this TextMeshPro text, float scale, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTextMeshPro(text.GetInstanceID(), TweenProperty.ScaleX);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = text.transform.localScale.x;
            tween.End = scale;
            tween.Ease = ease;
            
            tween.Target = text;
            
            return tween;
        }
        
        public static TextMeshProTween TweenScaleY(this TextMeshPro text, float scale, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTextMeshPro(text.GetInstanceID(), TweenProperty.ScaleY);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = text.transform.localScale.y;
            tween.End = scale;
            tween.Ease = ease;
            
            tween.Target = text;
            
            return tween;
        }
        
        public static TextMeshProTween TweenLocalMoveX(this TextMeshPro text, float x, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTextMeshPro(text.GetInstanceID(), TweenProperty.X);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = text.transform.localPosition.x;
            tween.End = x;
            tween.Ease = ease;
            
            tween.Target = text;
            
            return tween;
        }
        
        public static TextMeshProTween TweenLocalMoveY(this TextMeshPro text, float y, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTextMeshPro(text.GetInstanceID(), TweenProperty.Y);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = text.transform.localPosition.y;
            tween.End = y;
            tween.Ease = ease;
            
            tween.Target = text;
            
            return tween;
        }
        
        public static TextMeshProTween TweenLocalMove(this TextMeshPro text, Vector3 move, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTextMeshPro(text.GetInstanceID(), TweenProperty.XY);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartV3 = text.transform.localPosition;
            tween.EndV3 = move;
            tween.Ease = ease;
            
            tween.Target = text;
            
            return tween;
        }
        
        public static bool TweenKill(this TextMeshPro text, bool complete = false)
        {
            return Tweens.Instance.ReturnTextMeshPro(text.GetInstanceID(), complete);
        }
        
        public static bool TweenKill(this TextMeshPro text, TweenProperty property, bool complete = false)
        {
            return Tweens.Instance.ReturnTextMeshPro(text.GetInstanceID(), property, complete);
        }
        
        // CanvasGroup
        public static CanvasGroupTween TweenFade(this CanvasGroup canvasGroup, float alpha, float duration = 0.25f, Ease ease = Ease.Linear, bool oneFrameDelay = false)
        {
            var tween = Tweens.Instance.GetCanvasGroup(canvasGroup.GetInstanceID(), TweenProperty.Alpha);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = canvasGroup.alpha;
            tween.End = alpha;
            tween.Ease = ease;
            
            tween.Target = canvasGroup;
            tween.OneFrameDelay = oneFrameDelay;
            
            return tween;
        }
        
        public static bool TweenKill(this CanvasGroup canvasGroup, bool complete = false)
        {
            return Tweens.Instance.ReturnCanvasGroup(canvasGroup.GetInstanceID(), complete);
        }
        
        public static bool TweenKill(this CanvasGroup canvasGroup, TweenProperty property, bool complete = false)
        {
            return Tweens.Instance.ReturnCanvasGroup(canvasGroup.GetInstanceID(), property, complete);
        }
        
        // Image
        public static ImageTween TweenFade(this Image image, float alpha, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetImage(image.GetInstanceID(), TweenProperty.Alpha);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = image.color.a;
            tween.End = alpha;
            tween.Ease = ease;
            
            tween.Target = image;
            
            return tween;
        }
        
        public static ImageTween TweenColor(this Image image, Color color, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetImage(image.GetInstanceID(), TweenProperty.Color);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartColor = image.color;
            tween.EndColor = color;
            tween.Ease = ease;
            
            tween.Target = image;
            
            return tween;
        }
        
        public static ImageTween TweenColorNoAlpha(this Image image, Color color, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetImage(image.GetInstanceID(), TweenProperty.ColorNoAlpha);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartColor = image.color;
            tween.EndColor = color;
            tween.Ease = ease;
            
            tween.Target = image;
            
            return tween;
        }
        
        public static bool TweenKill(this Image image, bool complete = false)
        {
            return Tweens.Instance.ReturnImage(image.GetInstanceID(), complete);
        }
        
        public static bool TweenKill(this Image image, TweenProperty property, bool complete = false)
        {
            return Tweens.Instance.ReturnImage(image.GetInstanceID(), property, complete);
        }
        
        // Camera
        public static CameraTween TweenOrthographicSize(this Camera camera, float value, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetCamera(camera.GetInstanceID(), TweenProperty.OrthographicSize);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = camera.orthographicSize;
            tween.End = value;
            tween.Ease = ease;
            
            tween.Target = camera;
            
            return tween;
        }
        
        public static bool TweenKill(this Camera camera, bool complete = false)
        {
            return Tweens.Instance.ReturnCamera(camera.GetInstanceID(), complete);
        }
        
        public static bool TweenKill(this Camera camera, TweenProperty property, bool complete = false)
        {
            return Tweens.Instance.ReturnCamera(camera.GetInstanceID(), property, complete);
        }
        
        // Material
        public static MaterialTween TweenFloat(this Material material, float value, int id, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetMaterial(material.GetInstanceID(), TweenProperty.Float);

            tween.PropertyId = id;
            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = material.GetFloat(id);
            tween.End = value;
            tween.Ease = ease;
            tween.TimerBefore = true;
            
            tween.Target = material;
            
            return tween;
        }
        
        public static MaterialTween TweenColor(this Material material, Color color, int id, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetMaterial(material.GetInstanceID(), TweenProperty.Color);

            tween.PropertyId = id;
            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartColor = material.GetColor(id);
            tween.EndColor = color;
            tween.Ease = ease;
            tween.TimerBefore = true;
            
            tween.Target = material;
            
            return tween;
        }
        
        public static MaterialTween TweenColorA(this Material material, Color color, int id, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetMaterial(material.GetInstanceID(), TweenProperty.ColorA);

            tween.PropertyId = id;
            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartColor = material.GetColor(id);
            tween.EndColor = color;
            tween.Ease = ease;
            tween.TimerBefore = true;
            
            tween.Target = material;
            
            return tween;
        }
        
        public static MaterialTween TweenColorB(this Material material, Color color, int id, float duration = 0.25f, Ease ease = Ease.Linear)
        {
            var tween = Tweens.Instance.GetMaterial(material.GetInstanceID(), TweenProperty.ColorB);

            tween.PropertyId = id;
            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartColor = material.GetColor(id);
            tween.EndColor = color;
            tween.Ease = ease;
            tween.TimerBefore = true;
            
            tween.Target = material;
            
            return tween;
        }
        
        public static bool TweenKill(this Material material, bool complete = false)
        {
            return Tweens.Instance.ReturnMaterial(material.GetInstanceID(), complete);
        }
        
        public static bool TweenKill(this Material material, TweenProperty property, bool complete = false)
        {
            return Tweens.Instance.ReturnMaterial(material.GetInstanceID(), property, complete);
        }
        
        // RectTransform
        public static RectTransformTween TweenTop(this RectTransform rect, float value, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetRectTransform(rect.GetInstanceID(), TweenProperty.Top);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = rect.offsetMax.y;
            tween.End = -value;
            tween.Ease = ease;
            
            tween.Target = rect;
            
            return tween;
        }
        
        public static RectTransformTween TweenBottom(this RectTransform rect, float value, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetRectTransform(rect.GetInstanceID(), TweenProperty.Bottom);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = rect.offsetMin.y;
            tween.End = value;
            tween.Ease = ease;
            
            tween.Target = rect;
            
            return tween;
        }
        
        public static RectTransformTween TweenLeft(this RectTransform rect, float value, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetRectTransform(rect.GetInstanceID(), TweenProperty.Left);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = rect.offsetMin.x;
            tween.End = value;
            tween.Ease = ease;
            
            tween.Target = rect;
            
            return tween;
        }
        
        public static RectTransformTween TweenRight(this RectTransform rect, float value, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetRectTransform(rect.GetInstanceID(), TweenProperty.Right);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = rect.offsetMax.x;
            tween.End = -value;
            tween.Ease = ease;
            
            tween.Target = rect;
            
            return tween;
        }
        
        public static RectTransformTween TweenAnchorPosX(this RectTransform rect, float x, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetRectTransform(rect.GetInstanceID(), TweenProperty.AnchorX);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = rect.anchoredPosition.x;
            tween.End = x;
            tween.Ease = ease;
            
            tween.Target = rect;
            
            return tween;
        }
        
        public static RectTransformTween TweenAnchorPosY(this RectTransform rect, float y, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetRectTransform(rect.GetInstanceID(), TweenProperty.AnchorY);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = rect.anchoredPosition.y;
            tween.End = y;
            tween.Ease = ease;
            
            tween.Target = rect;
            
            return tween;
        }
        
        public static RectTransformTween TweenLocalMoveX(this RectTransform rect, float x, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetRectTransform(rect.GetInstanceID(), TweenProperty.X);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = rect.localPosition.x;
            tween.End = x;
            tween.Ease = ease;
            
            tween.Target = rect;
            
            return tween;
        }
        
        public static RectTransformTween TweenLocalMoveY(this RectTransform rect, float y, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetRectTransform(rect.GetInstanceID(), TweenProperty.Y);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = rect.localPosition.y;
            tween.End = y;
            tween.Ease = ease;
            
            tween.Target = rect;
            
            return tween;
        }
        
        public static RectTransformTween TweenLocalMove(this RectTransform rect, Vector3 move, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetRectTransform(rect.GetInstanceID(), TweenProperty.XY);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartV3 = rect.localPosition;
            tween.EndV3 = move;
            tween.Ease = ease;
            
            tween.Target = rect;
            
            return tween;
        }
        
        public static RectTransformTween TweenSizeDelta(this RectTransform rect, Vector2 size, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetRectTransform(rect.GetInstanceID(), TweenProperty.Size);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartV2 = rect.sizeDelta;
            tween.EndV2 = size;
            tween.Ease = ease;
            
            tween.Target = rect;
            
            return tween;
        }
        
        public static RectTransformTween TweenOffsetMin(this RectTransform rect, Vector2 offset, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetRectTransform(rect.GetInstanceID(), TweenProperty.OffsetMin);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartV2 = rect.offsetMin;
            tween.EndV2 = offset;
            tween.Ease = ease;
            
            tween.Target = rect;
            
            return tween;
        }
        
        public static RectTransformTween TweenOffsetMax(this RectTransform rect, Vector2 offset, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetRectTransform(rect.GetInstanceID(), TweenProperty.OffsetMax);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartV2 = rect.offsetMax;
            tween.EndV2 = offset;
            tween.Ease = ease;
            
            tween.Target = rect;
            
            return tween;
        }
        
        public static RectTransformTween TweenAnchorMax(this RectTransform rect, Vector2 anchorMax, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetRectTransform(rect.GetInstanceID(), TweenProperty.AnchorMax);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartV2 = rect.anchorMax;
            tween.EndV2 = anchorMax;
            tween.Ease = ease;
            
            tween.Target = rect;
            
            return tween;
        }

        public static RectTransformTween TweenRotate(this RectTransform rect, float angle, float duration = 0.25f, Ease ease = Ease.QuadOut, bool normalize = true)
        {
            var tween = Tweens.Instance.GetRectTransform(rect.GetInstanceID(), TweenProperty.Rotation);

            if (normalize) angle = angle % 360;
            
            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = rect.localEulerAngles.z;
            tween.End = angle;
            tween.Ease = ease;

            // Normalize angle
            if (normalize && angle < 0 && tween.Start > 0) 
                tween.Start = -360 + tween.Start;
            
            tween.Target = rect;
            
            return tween;
        }
        
        public static RectTransformTween TweenRotateMinus(this RectTransform rect, float angle, float duration = 0.25f, Ease ease = Ease.QuadOut, bool normalize = true)
        {
            var tween = Tweens.Instance.GetRectTransform(rect.GetInstanceID(), TweenProperty.Rotation);

            if (normalize) angle = angle % 360;

            var start = rect.localEulerAngles.z;
            
            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = start > 180 ? start - 360 : start;
            tween.End = angle;
            tween.Ease = ease;

            // Normalize angle
            //if (normalize && angle < 0 && tween.Start > 0) 
            //    tween.Start = -360 + tween.Start;
            
            tween.Target = rect;
            
            return tween;
        }
        
        public static RectTransformTween TweenScale(this RectTransform rect, Vector3 scale, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetRectTransform(rect.GetInstanceID(), TweenProperty.ScaleV3);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartV3 = rect.localScale;
            tween.EndV3 = scale;
            tween.Ease = ease;
            
            tween.Target = rect;
            
            return tween;
        }
        
        public static RectTransformTween TweenScale(this RectTransform rect, float scale, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetRectTransform(rect.GetInstanceID(), TweenProperty.Scale);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = rect.localScale.x;
            tween.End = scale;
            tween.Ease = ease;
            
            tween.Target = rect;
            
            return tween;
        }
        
        public static RectTransformTween TweenScaleX(this RectTransform rect, float scale, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetRectTransform(rect.GetInstanceID(), TweenProperty.ScaleX);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = rect.localScale.x;
            tween.End = scale;
            tween.Ease = ease;
            
            tween.Target = rect;
            
            return tween;
        }
        
        public static RectTransformTween TweenScaleY(this RectTransform rect, float scale, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetRectTransform(rect.GetInstanceID(), TweenProperty.ScaleY);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = rect.localScale.y;
            tween.End = scale;
            tween.Ease = ease;
            
            tween.Target = rect;
            
            return tween;
        }
        
        public static bool TweenKill(this RectTransform rect, bool complete = false)
        {
            return Tweens.Instance.ReturnRectTransform(rect.GetInstanceID(), complete);
        }
        
        public static bool TweenKill(this RectTransform rect, TweenProperty property, bool complete = false)
        {
            return Tweens.Instance.ReturnRectTransform(rect.GetInstanceID(), property, complete);
        }
        
        // Transform
        public static TransformTween TweenLocalMoveX(this Transform trs, float x, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTransform(trs.GetInstanceID(), TweenProperty.X);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = trs.localPosition.x;
            tween.End = x;
            tween.Ease = ease;
            tween.TimerBefore = true;
            
            tween.Target = trs;
            
            return tween;
        }
        
        public static TransformTween TweenLocalMoveY(this Transform trs, float y, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTransform(trs.GetInstanceID(), TweenProperty.Y);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = trs.localPosition.y;
            tween.End = y;
            tween.Ease = ease;
            tween.TimerBefore = true;
            
            tween.Target = trs;
            
            return tween;
        }
        
        public static TransformTween TweenLocalMoveOffsetX(this Transform trs, float x, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTransform(trs.GetInstanceID(), TweenProperty.X);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = trs.localPosition.x;
            tween.End = tween.Start + x;
            tween.Ease = ease;
            tween.TimerBefore = true;
            
            tween.Target = trs;
            
            return tween;
        }
        
        public static TransformTween TweenLocalMoveOffsetY(this Transform trs, float y, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTransform(trs.GetInstanceID(), TweenProperty.Y);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = trs.localPosition.y;
            tween.End = tween.Start + y;
            tween.Ease = ease;
            tween.TimerBefore = true;
            
            tween.Target = trs;
            
            return tween;
        }
        
        public static TransformTween TweenLocalMove(this Transform trs, Vector3 move, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTransform(trs.GetInstanceID(), TweenProperty.XY);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartV3 = trs.localPosition;
            tween.EndV3 = move;
            tween.Ease = ease;
            tween.TimerBefore = true;
            
            tween.Target = trs;
            
            return tween;
        }
        
        public static TransformTween TweenMoveX(this Transform trs, float x, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTransform(trs.GetInstanceID(), TweenProperty.WorldX);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = trs.position.x;
            tween.End = x;
            tween.Ease = ease;
            tween.TimerBefore = true;
            
            tween.Target = trs;
            
            return tween;
        }
        
        public static TransformTween TweenMoveY(this Transform trs, float y, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTransform(trs.GetInstanceID(), TweenProperty.WorldY);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = trs.position.y;
            tween.End = y;
            tween.Ease = ease;
            tween.TimerBefore = true;
            
            tween.Target = trs;
            
            return tween;
        }
        
        public static TransformTween TweenMoveOffsetX(this Transform trs, float x, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTransform(trs.GetInstanceID(), TweenProperty.WorldX);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = trs.position.x;
            tween.End = tween.Start + x;
            tween.Ease = ease;
            tween.TimerBefore = true;
            
            tween.Target = trs;
            
            return tween;
        }
        
        public static TransformTween TweenMoveOffsetY(this Transform trs, float y, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTransform(trs.GetInstanceID(), TweenProperty.WorldY);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = trs.position.y;
            tween.End = tween.Start + y;
            tween.Ease = ease;
            tween.TimerBefore = true;
            
            tween.Target = trs;
            
            return tween;
        }
        
        public static TransformTween TweenMove(this Transform trs, Vector3 move, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTransform(trs.GetInstanceID(), TweenProperty.WorldXY);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartV3 = trs.position;
            tween.EndV3 = move;
            tween.Ease = ease;
            tween.TimerBefore = true;
            
            tween.Target = trs;
            
            return tween;
        }
        
        public static bool TweenLocalOffsetX(this Transform trs, float x)
        {
            if (Tweens.Instance.TryGetTransform(trs.GetInstanceID(), TweenProperty.X, out var tween))
            {
                tween.Start += x;
                tween.End += x;
                return true;
            }
            
            return false;
        }
        
        public static bool TweenLocalOffsetY(this Transform trs, float y)
        {
            if (Tweens.Instance.TryGetTransform(trs.GetInstanceID(), TweenProperty.Y, out var tween))
            {
                tween.Start += y;
                tween.End += y;
                return true;
            }
            
            return false;
        }
        
        public static bool TweenLocalOffset(this Transform trs, Vector3 offset)
        {
            if (Tweens.Instance.TryGetTransform(trs.GetInstanceID(), TweenProperty.XY, out var tween))
            {
                tween.StartV3 += offset;
                tween.EndV3 += offset;
                return true;
            }
            
            return false;
        }
        
        public static bool TweenHas(this Transform trs, TweenProperty property)
        {
            return Tweens.Instance.HasTransform(trs.GetInstanceID(), property);
        }
        
        public static TransformTween TweenRotate(this Transform trs, float angle, float duration = 0.25f, Ease ease = Ease.QuadOut, bool normalize = false)
        {
            var tween = Tweens.Instance.GetTransform(trs.GetInstanceID(), TweenProperty.Rotation);

            if (normalize) angle = angle % 360;
            
            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = trs.rotation.eulerAngles.z;
            tween.End = angle;
            tween.Ease = ease;
            tween.TimerBefore = true;

            // Normalize angle
            if (normalize && angle < 0 && tween.Start > 0) 
                tween.Start = -360 + tween.Start;
            
            tween.Target = trs;
            
            return tween;
        }
        
        public static TransformTween TweenScale(this Transform trs, Vector3 scale, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTransform(trs.GetInstanceID(), TweenProperty.ScaleV3);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.StartV3 = trs.localScale;
            tween.EndV3 = scale;
            tween.Ease = ease;
            tween.TimerBefore = true;
            
            tween.Target = trs;
            
            return tween;
        }
        
        public static TransformTween TweenScale(this Transform trs, float scale, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTransform(trs.GetInstanceID(), TweenProperty.Scale);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = trs.localScale.x;
            tween.End = scale;
            tween.Ease = ease;
            tween.TimerBefore = true;
            
            tween.Target = trs;
            
            return tween;
        }
        
        public static TransformTween TweenScaleX(this Transform trs, float scale, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTransform(trs.GetInstanceID(), TweenProperty.ScaleX);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = trs.localScale.x;
            tween.End = scale;
            tween.Ease = ease;
            tween.TimerBefore = true;
            
            tween.Target = trs;
            
            return tween;
        }
        
        public static TransformTween TweenScaleY(this Transform trs, float scale, float duration = 0.25f, Ease ease = Ease.QuadOut)
        {
            var tween = Tweens.Instance.GetTransform(trs.GetInstanceID(), TweenProperty.ScaleY);

            tween.Timer = 0f;
            tween.TimeStart = Tweens.Time;
            tween.Duration = duration;
            tween.Start = trs.localScale.y;
            tween.End = scale;
            tween.Ease = ease;
            tween.TimerBefore = true;
            
            tween.Target = trs;
            
            return tween;
        }
        
        public static bool TweenKill(this Transform trs, bool complete = false)
        {
            return Tweens.Instance.ReturnTransform(trs.GetInstanceID(), complete);
        }
        
        public static bool TweenKill(this Transform trs, TweenProperty property, bool complete = false)
        {
            return Tweens.Instance.ReturnTransform(trs.GetInstanceID(), property, complete);
        }
    }
}