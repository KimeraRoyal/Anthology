using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.EventSystems;
using STOP_MODE = FMOD.Studio.STOP_MODE;

namespace Anthology
{
    public class HoverSound : MonoBehaviour, IPointerEnterHandler
    {
        [SerializeField] private EventReference m_hoverSound;
        [SerializeField] private bool m_retrigger;

        private EventDescription m_soundDescription;
        private EventInstance m_soundInstance;

        private void Awake()
        {
            m_soundDescription = RuntimeManager.GetEventDescription(m_hoverSound);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (m_soundInstance.isValid() && m_retrigger)
            {
                m_soundInstance.stop(STOP_MODE.ALLOWFADEOUT);
            }
            else
            { 
                m_soundDescription.createInstance(out m_soundInstance);
            }

            m_soundInstance.start();
        }
    }
}
