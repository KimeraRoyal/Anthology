using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Anthology
{
    [RequireComponent(typeof(Button))]
    public class ButtonJump : MonoBehaviour
    {
        private RectTransform m_rectTransform;
        private Button m_button;
        
        [SerializeField] private float m_jumpHeight = 1.0f;
        [SerializeField] private float m_jumpDuration = 1.0f;
        [SerializeField] private Ease m_jumpEase = Ease.Linear;
        
        [SerializeField] private float m_fallDuration = 1.0f;
        [SerializeField] private Ease m_fallEase = Ease.Linear;

        private Sequence m_jumpSequence;
        private Vector2 m_startPosition;

        private void Awake()
        {
            m_rectTransform = GetComponent<RectTransform>();
            m_button = GetComponent<Button>();
            
            m_button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            if (m_jumpSequence is { active: true })
            {
                m_jumpSequence.Kill();
                m_rectTransform.anchoredPosition = m_startPosition;
                
                return;
            }

            m_startPosition = m_rectTransform.anchoredPosition;

            m_jumpSequence = DOTween.Sequence();
            m_jumpSequence.Append(DOTween.To(() => m_rectTransform.anchoredPosition, value => m_rectTransform.anchoredPosition = value, m_startPosition + Vector2.up * m_jumpHeight, m_jumpDuration).SetEase(m_jumpEase));
            m_jumpSequence.Append(DOTween.To(() => m_rectTransform.anchoredPosition, value => m_rectTransform.anchoredPosition = value, m_startPosition, m_fallDuration).SetEase(m_fallEase));
        }
    }
}
