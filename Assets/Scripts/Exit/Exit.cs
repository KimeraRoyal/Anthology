using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Anthology.Exit
{
    [RequireComponent(typeof(Image))]
    public class Exit : MonoBehaviour
    {
        [SerializeField] private int m_skipFrames = 2;
        
        [SerializeField] private float m_closeTime = 1.0f;
        [SerializeField] private float m_resetSpeed = 1.0f;
        
        private float m_timer;
        
        private bool m_holdingEscape;
        private int m_skippedFrames;

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
            if (m_skippedFrames < m_skipFrames) // Skip X frames to avoid recognising inputs from previous scene.
            {
                m_skippedFrames++;
                return;
            }

            if (Input.GetKeyDown(KeyCode.Escape)) { m_holdingEscape = true; }
            else if(Input.GetKeyUp(KeyCode.Escape)) { m_holdingEscape = false; }
            
            if(m_holdingEscape)
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
