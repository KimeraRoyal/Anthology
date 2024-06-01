using System;
using UnityEngine;

namespace IP3.Interaction.Mouse
{
    public class MousePosition : MonoBehaviour
    {
        [SerializeField] private Camera m_camera;

        private Vector3 m_mouseWorldPosition;

        public Vector3 MouseWorldPosition => m_mouseWorldPosition;

        public Action<Vector3> OnMouseMoved;

        private void Awake()
        {
            if (!m_camera) { m_camera = GetComponent<Camera>(); }
        }

        private void Update()
        {
            var mouseWorldPosition = CalculateMouseWorldPosition();

            var distance = mouseWorldPosition - m_mouseWorldPosition;
            if(distance.magnitude < 0.001f) { return; }

            OnMouseMoved?.Invoke(distance);
            
            m_mouseWorldPosition = mouseWorldPosition;
        }

        private Vector3 CalculateMouseWorldPosition()
        {
            var mousePosition = Input.mousePosition;
            mousePosition.z = m_camera.nearClipPlane;
            
            return m_camera.ScreenToWorldPoint(mousePosition);
        }
    }
}
