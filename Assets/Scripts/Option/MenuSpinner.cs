using DG.Tweening;
using UnityEngine;

namespace Anthology
{
    [RequireComponent(typeof(Menu))]
    public class MenuSpinner : MonoBehaviour
    {
        private Menu m_menu;
        
        [SerializeField] private float m_defaultAngle;

        [SerializeField] private float m_rotateDuration = 1.0f;
        [SerializeField] private Ease m_rotateEase = Ease.Linear;

        private Tween m_rotateTween;

        private void Awake()
        {
            m_menu = GetComponent<Menu>();
            
            m_menu.OnOptionSelected.AddListener(OnOptionSelected);
        }

        private void OnOptionSelected(int _index, bool _firstSelected)
        {
            var angle = m_defaultAngle + -m_menu.Options[_index].Angle;
            Rotate(angle, _firstSelected);
        }

        private void Rotate(float _angle, bool _firstSelected)
        {
            var targetAngle = Vector3.up * _angle;
            
            if (_firstSelected)
            {
                transform.localEulerAngles = targetAngle;
                return;
            }
            
            if(m_rotateTween is { active: true }) { m_rotateTween.Kill(); }

            m_rotateTween = transform.DOLocalRotate(targetAngle, m_rotateDuration, RotateMode.Fast).SetEase(m_rotateEase);
        }
    }
}
