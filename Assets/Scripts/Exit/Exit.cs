using UnityEngine;
using UnityEngine.Events;

namespace Anthology.Exit
{
    public class Exit : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnPaused;
        [SerializeField] private UnityEvent OnUnpaused;

        private bool m_paused;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SetPaused(!m_paused);
            }
        }

        public void Pause()
            => SetPaused(true);

        public void Unpause()
            => SetPaused(false);

        private void SetPaused(bool _paused)
        {
            if(m_paused == _paused) { return; }
            m_paused = _paused;

            Time.timeScale = m_paused ? 0.0f : 1.0f;
                
            if(m_paused) { OnPaused?.Invoke(); }
            else { OnUnpaused?.Invoke(); }
        }
    }
}
