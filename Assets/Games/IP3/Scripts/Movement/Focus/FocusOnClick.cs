using IP3.Interaction.Click;
using UnityEngine;

namespace IP2.Movement.Focus
{
    public class FocusOnClick : MonoBehaviour
    {
        private Clicker m_clicker;
        
        private IFocuser m_focuser;

        [SerializeField] private Vector3 m_factor = Vector3.one;

        private Clickable m_target;

        private void Awake()
        {
            m_clicker = FindObjectOfType<Clicker>();
            
            m_focuser = GetComponent<IFocuser>();
        }

        private void Start()
        {
            m_clicker.OnClick += OnClick;
        }

        private void Update()
        {
            if (m_target == null)
            {
                m_focuser.FocusOn(null);
                return;
            }
            
            var focusPoint = m_target.transform.position;
            for (var i = 0; i < 3; i++)
            {
                focusPoint[i] *= m_factor[i];
            }
            m_focuser.FocusOn(focusPoint);
        }

        private void OnClick(Clickable _clickable)
            => m_target = _clickable;
    }
}
