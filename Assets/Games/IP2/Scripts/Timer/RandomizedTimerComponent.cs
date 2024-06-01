using UnityEngine;
using Random = UnityEngine.Random;

namespace IP2.Timer
{
    public class RandomizedTimerComponent : TimerComponentBase
    {
        [SerializeField] private float m_minInterval = 1.0f, m_maxInterval = 1.0f;

        private void Awake()
        {
            m_timer = new Timer(Random.Range(m_minInterval, m_maxInterval));
        }

        private void Update()
        {
            m_timer.Update(Time.deltaTime);
        }
    }
}