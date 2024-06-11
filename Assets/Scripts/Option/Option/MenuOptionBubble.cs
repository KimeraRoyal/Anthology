using System;
using DG.Tweening;
using UnityEngine;

namespace Anthology
{
    [RequireComponent(typeof(MeshRenderer))]
    public class MenuOptionBubble : MonoBehaviour
    {
        private static readonly int s_color = Shader.PropertyToID("_Color");
        private static readonly int s_fresnelColor = Shader.PropertyToID("_FresnelColor");
        
        private MenuOption m_option;
        
        private MeshRenderer m_renderer;

        private MaterialPropertyBlock m_propertyBlock;

        [SerializeField] private Color m_deselectedColor = Color.white;
        [SerializeField] private Color m_deselectedFresnelColor = Color.white;
        [SerializeField] private float m_deselectedDuration = 1.0f;
        [SerializeField] private Ease m_deselectedEase = Ease.Linear;
        
        [SerializeField] private Color m_selectedColor = Color.white;
        [SerializeField] private Color m_selectedFresnelColor = Color.white;
        [SerializeField] private float m_selectedDuration = 1.0f;
        [SerializeField] private Ease m_selectedEase = Ease.Linear;

        private Color m_currentColor;
        private Color m_currentFresnelColor;

        private Sequence m_sequence;
        private bool m_dirty;

        private Color Color
        {
            get => m_currentColor;
            set
            {
                m_currentColor = value;
                m_dirty = true;
            }
        }

        private Color FresnelColor
        {
            get => m_currentFresnelColor;
            set
            {
                m_currentFresnelColor = value;
                m_dirty = true;
            }
        }
        
        private void Awake()
        {
            m_option = GetComponentInParent<MenuOption>();
            
            m_renderer = GetComponent<MeshRenderer>();

            m_propertyBlock = new MaterialPropertyBlock();
            
            m_option.OnSelected.AddListener(OnSelected);
            m_option.OnDeselected.AddListener(OnDeselected);

            FresnelColor = m_deselectedFresnelColor;
            Color = m_deselectedColor;
        }

        private void Update()
        {
            if(!m_dirty) { return; }

            m_renderer.GetPropertyBlock(m_propertyBlock);
            m_propertyBlock.SetColor(s_color, m_currentColor);
            m_propertyBlock.SetColor(s_fresnelColor, m_currentFresnelColor);
            m_renderer.SetPropertyBlock(m_propertyBlock);
            
            m_dirty = false;
        }

        private void OnSelected(bool _firstSelected)
            => OnSelectedChanged(true, _firstSelected);

        private void OnDeselected()
            => OnSelectedChanged(false, false);

        private void OnSelectedChanged(bool _selected, bool _firstSelected)
        {
            var color = _selected ? m_selectedColor : m_deselectedColor;
            var fresnelColor = _selected ? m_selectedFresnelColor : m_deselectedFresnelColor;
            
            if (_firstSelected)
            {
                Color = color;
                FresnelColor = fresnelColor;
                return;
            }
            
            if(m_sequence is { active: true }) { m_sequence.Kill(); }

            var duration = _selected ? m_selectedDuration : m_deselectedDuration;
            var ease = _selected ? m_selectedEase : m_deselectedEase;

            m_sequence = DOTween.Sequence();
            m_sequence.Append(DOTween.To(() => Color, value => Color = value, color, duration).SetEase(ease));
            m_sequence.Append(DOTween.To(() => FresnelColor, value => FresnelColor = value, fresnelColor, duration).SetEase(ease));
        }
    }
}
