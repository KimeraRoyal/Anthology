using UnityEngine;
using UnityEngine.Events;

namespace Anthology
{
    public class Splash : MonoBehaviour
    {
        [SerializeField] private float m_duration = 1.0f;

        public float Duration => m_duration;
        
        public UnityEvent OnShow;
        public UnityEvent OnHide;

        private float m_timer = -1.0f;

        private void Update()
        {
            if(m_timer < 0.0f) { return; }

            m_timer -= Time.deltaTime;
            if(m_timer > 0.0f) { return; }
            
            OnHide?.Invoke();
        }

        public void Show()
        {
            if(m_timer > 0.0f) { return; }
            
            m_timer = m_duration;
            OnShow?.Invoke();
            
            if(m_duration < 0.001f) { OnHide?.Invoke(); }
        }
    }
}
