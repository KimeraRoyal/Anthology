using DG.Tweening;
using UnityEngine;

namespace Anthology
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class MenuOptionIcon : MonoBehaviour
    {
        private MenuOption m_option;

        private SpriteRenderer m_spriteRenderer;
        
        [SerializeField] private Color m_deselectedColor = Color.white;
        [SerializeField] private float m_deselectedDuration = 1.0f;
        [SerializeField] private Ease m_deselectedEase = Ease.Linear;
        
        [SerializeField] private Color m_selectedColor = Color.white;
        [SerializeField] private float m_selectedDuration = 1.0f;
        [SerializeField] private Ease m_selectedEase = Ease.Linear;

        private Tween m_colorTween;

        private void Awake()
        {
            m_option = GetComponentInParent<MenuOption>();

            m_spriteRenderer = GetComponent<SpriteRenderer>();
            
            m_option.OnDetailsChanged.AddListener(OnDetailsChanged);
            
            m_option.OnSelected.AddListener(OnSelected);
            m_option.OnDeselected.AddListener(OnDeselected);
            
            m_spriteRenderer.color = m_deselectedColor;
        }

        private void OnDetailsChanged(OptionDetails _details)
            => m_spriteRenderer.sprite = _details.Icon;

        private void OnSelected(bool _firstSelected)
            => OnSelectedChanged(true, _firstSelected);

        private void OnDeselected()
            => OnSelectedChanged(false, false);

        private void OnSelectedChanged(bool _selected, bool _firstSelected)
        {
            var color = _selected ? m_selectedColor : m_deselectedColor;
            
            if (_firstSelected)
            {
                m_spriteRenderer.color = color;
                return;
            }
            
            if(m_colorTween is { active: true }) { m_colorTween.Kill(); }

            var duration = _selected ? m_selectedDuration : m_deselectedDuration;
            var ease = _selected ? m_selectedEase : m_deselectedEase;

            m_colorTween = DOTween.To(() => m_spriteRenderer.color, value => m_spriteRenderer.color = value, color, duration).SetEase(ease);
        }
    }
}
