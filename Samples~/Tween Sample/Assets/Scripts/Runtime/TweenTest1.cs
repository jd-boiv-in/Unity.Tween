using System;
using JD.Tween;
using UnityEngine;
using UnityEngine.UI;

namespace JD.Samples
{
    public class TweenTest1 : MonoBehaviour
    {
        public RectTransform Rect;
        
        private void Start()
        {
            Rect.TweenAnchorPosX(200, 0.25f, Ease.QuadOut);
        }
    }
}