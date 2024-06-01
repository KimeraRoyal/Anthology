using DG.Tweening;
using UnityEngine;

namespace IP2
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class ExpandOnClicked : MonoBehaviour
    {
        private Clicker m_clicker;
        private Clickable m_clickable;
        
        private CircleCollider2D m_collider;

        [SerializeField] private float m_radius = 1.0f;
        [SerializeField] private float m_inactiveRadius = 0.01f;
        
        [SerializeField] private float m_expandDuration = 1.0f;
        [SerializeField] private Ease m_expandEase = Ease.Linear;
        
        [SerializeField] private float m_contractDuration = 1.0f;
        [SerializeField] private Ease m_contractEase = Ease.Linear;

        private Sequence m_sequence;

        private void Awake()
        {
            m_clicker = FindObjectOfType<Clicker>();
            
            m_clickable = GetComponentInParent<Clickable>();
            
            m_collider = GetComponent<CircleCollider2D>();
        }

        private void Start()
        {
            m_clicker.OnClick += OnClick;
        }

        private void OnClick(Clickable _clickable)
        {
            if(_clickable != m_clickable) { return; }
            
            if(m_sequence is { active: true }) { m_sequence.Kill(); }

            m_sequence = DOTween.Sequence();
            m_sequence.Append(DOTween.To(() => m_collider.radius, _radius => m_collider.radius = _radius, m_radius, m_expandDuration).SetEase(m_expandEase));
            m_sequence.Append(DOTween.To(() => m_collider.radius, _radius => m_collider.radius = _radius, m_inactiveRadius, m_contractDuration).SetEase(m_contractEase));
        }
    }
}
