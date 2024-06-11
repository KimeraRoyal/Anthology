using DG.Tweening;
using UnityEngine;

namespace Anthology
{
    public class MenuOptionMover : MonoBehaviour
    {
        private MenuOption m_option;
        
        [SerializeField] private float m_deselectedDistance, m_selectedDistance;
        [SerializeField] private float m_movementDuration = 1.0f;
        [SerializeField] private Ease m_movementEase = Ease.Linear;

        private Tween m_moveTween;

        private void Awake()
        {
            m_option = GetComponentInParent<MenuOption>();
            
            m_option.OnSelected.AddListener(OnSelected);
            m_option.OnDeselected.AddListener(OnDeselected);
        }

        private void OnSelected(bool _firstSelected)
            => ChangePosition(m_selectedDistance, _firstSelected);

        private void OnDeselected()
            => ChangePosition(m_deselectedDistance, false);

        private void ChangePosition(float _distance, bool _firstSelected)
        {
            var targetPosition = Vector3.forward * _distance;

            if (_firstSelected)
            {
                transform.localPosition = targetPosition;
                return;
            }
            
            if(m_moveTween is { active: true }) { m_moveTween.Kill(); }

            m_moveTween = transform.DOLocalMove(targetPosition, m_movementDuration).SetEase(m_movementEase);
        }
    }
}