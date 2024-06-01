using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Anthology.Exit
{
    [RequireComponent(typeof(Image))]
    public class Exit : MonoBehaviour
    {
        [SerializeField] private float m_closeTime = 1.0f;
        [SerializeField] private float m_resetSpeed = 1.0f;
    
        private float m_timer;

        public float Timer
        {
            get => m_timer;
            private set
            {
                m_timer = value;
                OnTimerCounter?.Invoke(m_timer / m_closeTime);
            }
        }
        
        public UnityEvent<float> OnTimerCounter;
        public UnityEvent OnExit;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Close();
            }
            else
            {
                Timer = Mathf.Clamp(Timer - Time.deltaTime * m_resetSpeed, 0.0f, m_closeTime);
            }
        }

        private void Close()
        {
            Timer += Time.deltaTime;
            if(Timer < m_closeTime) { return; }

            OnExit.Invoke();
        }
    }
}
