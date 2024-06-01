using System;
using UnityEngine;

namespace IP2.Timer
{
    [Serializable]
    public class Timer
    {
        [SerializeField] private float m_interval = 1.0f;

        private float m_timer;

        public float Interval
        {
            get => m_interval;
            set => m_interval = value;
        }

        public Action OnInterval;

        public Timer()
        {
            
        }

        public Timer(float _interval)
        {
            m_interval = _interval;
        }
        
        public void Update(float _deltaTime)
        {
            m_timer += _deltaTime;
            if(m_timer < m_interval) { return; }
            m_timer -= m_interval;
            
            OnInterval?.Invoke();
        }
    }
}