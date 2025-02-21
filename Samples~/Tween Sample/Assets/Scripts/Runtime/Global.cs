using System;
using JD.Tween;
using UnityEngine;

namespace JD.Samples
{
    public class Global : MonoBehaviour
    {
        private void Update()
        {
            Tweens.Instance.Update();
        }
    }
}