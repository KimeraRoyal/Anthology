using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace Anthology
{
    public class SoundGroup : MonoBehaviour
    {
        [SerializeField] private EventReference[] m_sounds;
        [SerializeField] private string m_indexParameterName;
        [SerializeField] private bool m_retrigger;

        private EventDescription[] m_soundDescriptions;
        private EventInstance[] m_soundInstances;

        private void Awake()
        {
            m_soundDescriptions = new EventDescription[m_sounds.Length];
            m_soundInstances = new EventInstance[m_sounds.Length];
            
            for (var i = 0; i < m_sounds.Length; i++)
            {
                m_soundDescriptions[i] = RuntimeManager.GetEventDescription(m_sounds[i]);
            }
        }

        private void Start()
        {
            for (var i = 0; i < transform.childCount; i++)
            {
                var index = i;
                var elements = transform.GetChild(i).GetComponentsInChildren<SoundGroupElement>();

                foreach (var element in elements)
                {
                    element.OnInvoked += _soundIndex => { OnInvoked(_soundIndex,index); };
                }
            }
        }

        private void OnInvoked(int _soundIndex, int _groupIndex)
        {
            if (m_soundInstances[_soundIndex].isValid() && m_retrigger)
            {
                m_soundInstances[_soundIndex].stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            }
            else
            { 
                m_soundDescriptions[_soundIndex].createInstance(out m_soundInstances[_soundIndex]);
            }

            m_soundInstances[_soundIndex].setParameterByName(m_indexParameterName, _groupIndex);
            m_soundInstances[_soundIndex].start();
        }
    }
}
