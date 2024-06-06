using DG.Tweening;
using UnityEngine;

namespace Anthology
{
    public class MenuOptionScaler : MonoBehaviour
    {
        private MenuOption m_option;

        [SerializeField] private float m_deselectedScale = 1.0f;
        [SerializeField] private float m_selectedScale = 1.0f;

        [SerializeField] private float m_scaleChangeDuration = 1.0f;
        [SerializeField] private Ease m_scaleChangeEase = Ease.Linear;

        private Tween m_tween;

        private void Awake()
        {
            m_option = GetComponentInParent<MenuOption>();
            
            m_option.OnSelected.AddListener(OnSelected);
            m_option.OnDeselected.AddListener(OnDeselected);
        }

        private void OnSelected()
            => ChangeScale(m_selectedScale);

        private void OnDeselected()
            => ChangeScale(m_deselectedScale);

        private void ChangeScale(float _scale)
        {
            if(m_tween is { active: true }) { m_tween.Kill(); }

            m_tween = transform.DOScale(Vector3.one * _scale, m_scaleChangeDuration).SetEase(m_scaleChangeEase);
        }
    }
}
