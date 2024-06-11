using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Anthology
{
    [RequireComponent(typeof(Image))]
    public class SplashFade : MonoBehaviour
    {
        private Splash m_splash;

        private Image m_image;

        [SerializeField] private float m_inDuration = 1.0f;
        [SerializeField] private Ease m_inEase = Ease.Linear;
        
        [SerializeField] private float m_outDuration = 1.0f;
        [SerializeField] private Ease m_outEase = Ease.Linear;

        private Tween m_tween;

        private void Awake()
        {
            m_splash = GetComponentInParent<Splash>();

            m_image = GetComponent<Image>();
            
            m_splash.OnShow.AddListener(OnShow);
            m_splash.OnHide.AddListener(OnHide);
            
            var targetColor = m_image.color;
            targetColor.a = 0.0f;
            m_image.color = targetColor;
        }

        private void OnShow()
            => Fade(true);

        private void OnHide()
            => Fade(false);

        private void Fade(bool _in)
        {
            if(m_tween is { active: true }) { m_tween.Kill(); }

            var targetColor = m_image.color;
            targetColor.a = _in ? 1.0f : 0.0f;
            
            var duration = _in ? m_inDuration : m_outDuration;
            var ease = _in ? m_inEase : m_outEase;

            if (duration < 0.001f)
            {
                m_image.color = targetColor;
                return;
            }

            m_tween = DOTween.To(() => m_image.color, value => m_image.color = value, targetColor, duration).SetEase(ease);
        }
    }
}
