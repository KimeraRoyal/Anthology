using System;
using DG.Tweening;
using IP2.Timer;
using UnityEngine;
using Random = UnityEngine.Random;

namespace IP2.Character.Shadow
{
    [RequireComponent(typeof(TimerComponentBase))]
    public class Shadows : MonoBehaviour
    {
        private TimerComponentBase m_timer;

        [SerializeField] private float m_increment = 1.0f;

        [SerializeField] private float m_minShadowScale, m_maxShadowScale = 1.0f;
        [SerializeField] private AnimationCurve m_scaleCurve = AnimationCurve.Linear(0.0f, 0.0f, 360.0f, 1.0f);

        [SerializeField] private float m_changeDuration = 1.0f;
        [SerializeField] private Ease m_changeEase = Ease.Linear;
        
        private float m_shadowAngle;
        private float m_shadowScale;

        private Tween m_changeTween;

        public float ShadowAngle
        {
            get => m_shadowAngle;
            set
            {
                m_shadowAngle = value;
                OnShadowAngleChanged?.Invoke(m_shadowAngle);
            }
        }

        public float ShadowScale
        {
            get => m_shadowScale;
            set
            {
                m_shadowScale = value;
                OnShadowScaleChanged?.Invoke(m_shadowScale);
            }
        }

        public Action<float> OnShadowAngleChanged;
        public Action<float> OnShadowScaleChanged;

        private void Awake()
        {
            m_timer = GetComponent<TimerComponentBase>();
            
            OnShadowAngleChanged += OnAngleChanged;

            ShadowAngle = Random.Range(0, 360);
        }

        private void Start()
        {
            m_timer.Timer.OnInterval += OnInterval;
        }

        private void OnInterval()
        {
            var newAngle = ShadowAngle + m_increment;
            if (newAngle > 360.0f)
            {
                newAngle -= 360.0f;
                ShadowAngle -= 360.0f;
            }
            
            if (m_changeDuration > 0.0f)
            {
                ShadowTween(newAngle);
                return;
            }
            ShadowAngle = newAngle;
        }

        private void ShadowTween(float _newAngle)
        {
            if(m_changeTween is { active: true }) { m_changeTween.Kill(); }
            
            m_changeTween = DOTween.To(() => ShadowAngle, _angle => ShadowAngle = _angle, _newAngle, m_changeDuration).SetEase(m_changeEase);
        }

        private void OnAngleChanged(float _angle)
        {
            ShadowScale = m_scaleCurve.Evaluate(_angle) * (m_maxShadowScale - m_minShadowScale) + m_minShadowScale;
        }
    }
}
