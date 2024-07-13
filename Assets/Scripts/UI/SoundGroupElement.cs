using System;
using UnityEngine;

namespace Anthology
{
    public abstract class SoundGroupElement : MonoBehaviour
    {
        [SerializeField] private int m_soundIndex;
        
        public Action<int> OnInvoked;

        protected void InvokeElement()
            => OnInvoked?.Invoke(m_soundIndex);
    }
}
