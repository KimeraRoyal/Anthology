using FMODUnity;
using UnityEngine;

namespace IP2
{
    [RequireComponent(typeof(Panel), typeof(StudioEventEmitter))]
    public class PanelSound : MonoBehaviour
    {
        private Panel m_panel;
        
        private StudioEventEmitter m_emitter;

        private void Awake()
        {
            m_panel = GetComponent<Panel>();
            m_emitter = GetComponent<StudioEventEmitter>();
            
            m_panel.OnOpenAnimationStarted += m_emitter.Play;
            m_panel.OnCloseAnimationStarted += m_emitter.Play;
        }
    }
}
