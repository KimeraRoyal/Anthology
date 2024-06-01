using UnityEngine;

namespace IP2
{
    public class IncreaseMassOnClick : MonoBehaviour
    {
        private Clicker m_clicker;
        
        private Clickable m_clickable;
        private Rigidbody2D m_rigidbody;

        [SerializeField] private float m_mass = 1.0f;
        [SerializeField] private float m_inactiveMass = 1.0f;

        private bool m_clicked;

        private void Awake()
        {
            m_clicker = FindObjectOfType<Clicker>();
            m_clickable = GetComponentInParent<Clickable>();
            
            m_rigidbody = GetComponentInParent<Rigidbody2D>();
        }

        private void Start()
        {
            m_clicker.OnClick += OnClick;
        }

        private void OnClick(Clickable _clickable)
        {
            var clicked = _clickable == m_clickable;
            if (!m_clicked && clicked)
            {
                m_rigidbody.mass = m_mass;
                m_clicked = true;
            }
            else if (m_clicked && !clicked)
            {
                m_rigidbody.mass = m_inactiveMass;
                m_clicked = false;
            }
        }
    }
}
