using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace IP1
{
    [RequireComponent(typeof(Image))]
    public class FadeImageInOut : MonoBehaviour
    {
        private Image m_image;

        [SerializeField] private bool m_fadeInOnStart;
        
        [SerializeField] private float m_fadeInTime = 1.0f;
        [SerializeField] private Ease m_fadeInEase = Ease.Linear;
        
        [SerializeField] private float m_fadeOutTime = 1.0f;
        [SerializeField] private Ease m_fadeOutEase = Ease.Linear;

        private Sequence m_sequence;

        public UnityEvent<bool> OnFaded;
        public UnityEvent OnFadeIn;
        public UnityEvent OnFadeOut;

        private void Awake()
        {
            m_image = GetComponent<Image>();
        }

        private void Start()
        {
            if(!m_fadeInOnStart) { return; }
            Fade(false);
        }

        public void Fade(bool _visible)
        {
            if(m_sequence is { active: true }) { m_sequence.Kill(); }
            
            var time = _visible ? m_fadeOutTime : m_fadeInTime;
            var ease = _visible ? m_fadeOutEase : m_fadeInEase;
            
            var targetColor = m_image.color;
            targetColor.a = _visible ? 1.0f : 0.0f;

            if (time < 0.001f)
            {
                m_image.color = targetColor;
            }
            else
            {
                m_sequence = DOTween.Sequence();
                m_sequence.Append(DOTween.To(() => m_image.color, _color => m_image.color = _color, targetColor, time).SetEase(ease));
                m_sequence.AppendCallback(() => FadeCallback(_visible));
            }
        }

        private void FadeCallback(bool _visible)
        {
            OnFaded?.Invoke(_visible);
            
            if(_visible) { OnFadeOut?.Invoke(); }
            else { OnFadeIn?.Invoke(); }
        }
    }
}
