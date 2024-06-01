using System;
using UnityEngine;

namespace IP3.Interaction.Click
{
    public class Clicker : MonoBehaviour
    {
        [SerializeField] private Camera m_camera;

        [SerializeField] private LayerMask m_mask;
        [SerializeField] private bool m_hold;
        
        private Clickable m_currentClicked;

        private int m_blocking;

        public bool Blocked => m_blocking > 0;

        public Action<Clickable> OnClick;

        public Action<Clickable> OnHold;
        public Action<Clickable> OnRelease;

        private void Awake()
        {
            if (!m_camera) { m_camera = GetComponent<Camera>(); }
        }

        private void OnDisable()
        {
            Release();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Blocked) { return; }
                
                var clicked = Click();
                if (m_hold && clicked)
                {
                    m_currentClicked = clicked;
                    OnHold?.Invoke(clicked);
                }
            }
            else if(Input.GetMouseButtonUp(0))
            {
                Release();
            }
        }

        private Clickable Click()
        {
            Clickable clickable = null;
            if (ShootRay(out var _rayHit))
            {
                clickable = _rayHit.collider.GetComponentInParent<Clickable>();
                if (clickable) { clickable.Click(m_hold); }
            }
            OnClick?.Invoke(clickable);
            
            return clickable;
        }

        private void Release()
        {
            if(!m_currentClicked) { return; }

            m_currentClicked.Release();
            m_currentClicked = null;
            
            OnRelease?.Invoke(m_currentClicked);
        }

        private bool ShootRay(out RaycastHit2D o_rayHit)
        {
            var ray = m_camera.ScreenPointToRay(Input.mousePosition);
            o_rayHit = Physics2D.Raycast(ray.origin, Vector2.up, 0.001f, m_mask);
            return o_rayHit.collider;
        }

        public void Block()
            => m_blocking++;

        public void Unblock()
            => m_blocking--;
    }
}
