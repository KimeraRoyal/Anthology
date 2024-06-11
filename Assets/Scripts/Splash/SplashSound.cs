using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace Anthology
{
    public class SplashSound : MonoBehaviour
    {
        private Splash m_splash;

        [SerializeField] private EventReference m_event;

        [SerializeField] private string m_variableName;
        [SerializeField] private float m_variableValue;

        private EventDescription m_eventDescription;

        private void Awake()
        {
            m_splash = GetComponentInParent<Splash>();
            
            m_eventDescription = RuntimeManager.GetEventDescription(m_event);
            
            m_splash.OnShow.AddListener(OnShow);
        }

        private void OnShow()
        {
            m_eventDescription.createInstance(out var instance);
            instance.setParameterByName(m_variableName, m_variableValue);
            instance.start();
        }
    }
}
