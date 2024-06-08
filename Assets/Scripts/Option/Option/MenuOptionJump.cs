using DG.Tweening;
using UnityEngine;

namespace Anthology
{
    public class MenuOptionJump : MonoBehaviour
    {
        private MenuOption m_option;

        [SerializeField] private float m_jumpPower;
        [SerializeField] private int m_numJumps = 1;
        [SerializeField] private float m_jumpDuration = 1.0f;
        [SerializeField] private Ease m_jumpEase = Ease.Linear;

        private Tween m_tween;
        private Vector3 m_startingPosition;

        private void Awake()
        {
            m_option = GetComponentInParent<MenuOption>();
            
            m_option.OnSelected.AddListener(OnSelected);
        }

        private void OnSelected()
        {
            if (m_tween is { active: true })
            {
                m_tween.Kill();
                transform.localPosition = m_startingPosition;
            }

            m_startingPosition = transform.localPosition;
            m_tween = transform.DOLocalJump(transform.localPosition, m_jumpPower, m_numJumps, m_jumpDuration).SetEase(m_jumpEase);
        }
    }
}
