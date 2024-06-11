using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Anthology
{
    [RequireComponent(typeof(CanvasGroup))]
    public class WindowFade : MonoBehaviour
    {
        private Window m_window;
        
        private CanvasGroup m_group;

        [SerializeField] private bool m_controlChildrenEnabled;

        [Title("Fade In")]
        [SerializeField] private float m_fadeInDuration = 1.0f;
        [SerializeField] private Ease m_fadeInEase = Ease.Linear;
        
        [Title("Fade Out")]
        [SerializeField] private float m_fadeOutDuration = 1.0f;
        [SerializeField] private Ease m_fadeOutEase = Ease.Linear;

        private Sequence m_fadeSequence;
        
        private void Awake()
        {
            m_window = GetComponentInParent<Window>();
            
            m_group = GetComponent<CanvasGroup>();
            
            m_window.OnEnabledChanged.AddListener(OnEnabledChanged);
        }

        private void Start()
        {
            m_group.alpha = m_window.Enabled ? 1.0f : 0.0f;
            EnableChildren(m_window.Enabled);
        }

        private void OnEnabledChanged(bool _enabled)
        {
            if(m_fadeSequence is { active: true }) { m_fadeSequence.Kill(); }
            
            var alpha = _enabled ? 1.0f : 0.0f;
            var duration = _enabled ? m_fadeInDuration : m_fadeOutDuration;
            var ease = _enabled ? m_fadeInEase : m_fadeOutEase;

            m_fadeSequence = DOTween.Sequence();
            m_fadeSequence.Append(DOTween.To(() => m_group.alpha, value => m_group.alpha = value, 
                alpha, duration).SetEase(ease));
            if(_enabled) { EnableChildren(true); }
            else { m_fadeSequence.AppendCallback(() => EnableChildren(false)); }
        }

        private void EnableChildren(bool _enabled)
        {
            if(!m_controlChildrenEnabled) { return; }
            
            for (var i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(_enabled);
            }
        }
    }
}
