using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace IP2
{
    public class Panel : MonoBehaviour, IShowable
    {
        private RectTransform m_rectTransform;
        
        [SerializeField] private bool m_open = true;
        [SerializeField] private bool m_reopenable = true;

        [BoxGroup("Open Animation")] [SerializeField] private float m_openWidthOffset = 0.0f;
        [BoxGroup("Open Animation")] [SerializeField] private float m_openWidthDuration = 1.0f;
        [BoxGroup("Open Animation")] [SerializeField] private Ease m_openWidthEase = Ease.Linear;

        [BoxGroup("Open Animation")] [SerializeField] private float m_openHeightOffset = 0.0f;
        [BoxGroup("Open Animation")] [SerializeField] private float m_openHeightDuration = 1.0f;
        [BoxGroup("Open Animation")] [SerializeField] private Ease m_openHeightEase = Ease.Linear;

        [BoxGroup("Close Animation")] [SerializeField] private float m_closeWidthOffset = 0.0f;
        [BoxGroup("Close Animation")] [SerializeField] private float m_closeWidthDuration = 1.0f;
        [BoxGroup("Close Animation")] [SerializeField] private Ease m_closeWidthEase = Ease.Linear;

        [BoxGroup("Close Animation")] [SerializeField] private float m_closeHeightOffset = 0.0f;
        [BoxGroup("Close Animation")] [SerializeField] private float m_closeHeightDuration = 1.0f;
        [BoxGroup("Close Animation")] [SerializeField] private Ease m_closeHeightEase = Ease.Linear;
        
        private Vector2 m_size;
        private Vector2 m_openFactor;

        private bool m_alreadyOpened;

        private Sequence m_sizeChangeSequence;

        public Action OnOpenAnimationCompleted;
        public Action OnCloseAnimationCompleted;

        public bool Open
        {
            get => m_open;
            set
            {
                if(m_open == value || (!m_open && m_alreadyOpened && !m_reopenable)) { return; }
                
                m_open = value;
                if (value) { m_alreadyOpened = true; }
                
                ChangeSize();
            }
        }

        public Action OnOpen;
        public Action OnClose;

        private void Awake()
        {
            m_rectTransform = GetComponent<RectTransform>();

            m_size = m_rectTransform.sizeDelta;
        }

        public void Start()
        {
            if (!m_open) { m_rectTransform.sizeDelta = Vector2.zero; }

            m_openFactor = m_open ? Vector2.one : Vector2.zero;
        }

        private void LateUpdate()
        {
            m_rectTransform.sizeDelta = m_size * m_openFactor;
        }

        private void ChangeSize()
        {
            if(m_sizeChangeSequence is { active: true }) { m_sizeChangeSequence.Kill(); }
            
            var openFactor = m_open ? Vector2.one : Vector2.zero;

            var widthOffset = m_open ? m_openWidthOffset : m_closeWidthOffset;
            var widthDuration = m_open ? m_openWidthDuration : m_closeWidthDuration;
            var widthEase = m_open ? m_openWidthEase : m_closeWidthEase;

            var heightOffset = m_open ? m_openHeightOffset : m_closeHeightOffset;
            var heightDuration = m_open ? m_openHeightDuration : m_closeHeightDuration;
            var heightEase = m_open ? m_openHeightEase : m_closeHeightEase;

            m_sizeChangeSequence = DOTween.Sequence();
            m_sizeChangeSequence.Insert(widthOffset, DOTween.To(() => m_openFactor.x, _x => m_openFactor.x = _x, openFactor.x, widthDuration).SetEase(widthEase));
            m_sizeChangeSequence.Insert(heightOffset, DOTween.To(() => m_openFactor.y, _y => m_openFactor.y = _y, openFactor.y, heightDuration).SetEase(heightEase));
            m_sizeChangeSequence.AppendCallback(AnimationCompleted);
            
            if(m_open) { OnOpen?.Invoke(); }
            else { OnClose?.Invoke(); }
        }

        private void AnimationCompleted()
        {
            if(m_open) { OnOpenAnimationCompleted?.Invoke(); }
            else { OnCloseAnimationCompleted?.Invoke(); }
        }

        public void Show()
            => Open = true;

        public void Hide()
            => Open = false;
    }
}
