using System;
using IP1;
using UnityEngine;
using UnityEngine.Events;

namespace Anthology
{
    public class MenuFunctions : MonoBehaviour
    {
        private SceneChange m_sceneChange;
        private FadeImageInOut m_fader;

        private bool m_loadingGame;
        private bool m_loadingPoem;

        public UnityEvent OnGameLoaded;
        public UnityEvent OnPoemLoaded;

        private void Awake()
        {
            m_sceneChange = FindObjectOfType<SceneChange>();
            m_fader = FindObjectOfType<FadeImageInOut>();
        }

        public void LoadGame(string _gameName)
        {
            if(m_loadingGame || m_loadingPoem) { return; }
            
            m_sceneChange.QueueScene(_gameName);
            m_fader.Fade(true);
            
            OnGameLoaded?.Invoke();

            m_loadingGame = true;
        }

        public void LoadPoem(string _poemName)
        {
            if(m_loadingGame || m_loadingPoem) { return; }
            
            OnPoemLoaded?.Invoke();
            
            m_loadingPoem = true;
        }
    }
}
