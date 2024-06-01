using IP3.Graphics.Show;
using UnityEngine;

namespace IP3.Interaction.Click
{
    [RequireComponent(typeof(IShowable))]
    public class ShownOnClick : MonoBehaviour
    {
        private IShowable m_panel;

        [SerializeField] private Clickable m_clickable;

        [SerializeField] private bool m_onlyThis;

        [SerializeField] private LayerMask m_mask;

        private void Awake()
        {
            var clicker = FindObjectOfType<Clicker>();
            if(!m_clickable) { m_clickable = GetComponentInParent<Clickable>(); }

            m_panel = GetComponent<IShowable>();
            
            clicker.OnClick += OnClick;
        }

        private void OnClick(Clickable _clicked)
        {
            if (_clicked == null)
            {
                m_panel.Hide();
                return;
            }

            if(((1 << _clicked.gameObject.layer) & m_mask) == 0) { return; }

            if (m_onlyThis && _clicked != m_clickable)
            {
                m_panel.Hide();
            }
            else
            {
                m_panel.Show();
            }
        }
    }
}
