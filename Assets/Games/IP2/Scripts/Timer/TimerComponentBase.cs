using UnityEngine;

namespace IP2.Timer
{
    public abstract class TimerComponentBase : MonoBehaviour
    {
        protected Timer m_timer;

        public Timer Timer => m_timer;
    }
}