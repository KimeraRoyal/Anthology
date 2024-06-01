using System;
using UnityEngine;

namespace IP3.Interaction.Click
{
    public class Clickable : MonoBehaviour
    {
        public Action OnClicked;
        
        public Action OnHeld;
        public Action OnReleased;

        private bool m_held;

        public bool Held => m_held;

        public void Click(bool _hold)
        {
            OnClicked?.Invoke();

            if (!_hold || m_held) { return; }
            
            OnHeld?.Invoke();
            m_held = true;
        }

        public void Release()
        {
            if(!m_held) { return; }
            
            OnReleased?.Invoke();
            m_held = false;
        }
    }
}
