using UnityEngine;

namespace IP2.Timer
{
    public class TimerComponent : TimerComponentBase
    {
        [SerializeField] private float m_interval = 1.0f;

        private void Awake()
        {
            m_timer = new Timer(m_interval);
        }

        private void Update()
        {
            m_timer.Update(Time.deltaTime);
        }
    }
}
