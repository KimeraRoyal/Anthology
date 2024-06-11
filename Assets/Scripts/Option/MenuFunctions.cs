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

        private Window m_poemWindow;
        private PoemSwitcher m_poems;

        private bool m_loadingGame;
        private bool m_loadingPoem;

        public UnityEvent OnGameLoaded;
        public UnityEvent OnPoemLoaded;

        private void Awake()
        {
            m_sceneChange = FindObjectOfType<SceneChange>();
            m_fader = FindObjectOfType<FadeImageInOut>();
            
            m_poemWindow = FindObjectOfType<Window>();
            m_poems = FindObjectOfType<PoemSwitcher>();

            m_poemWindow.OnDisabled.AddListener(OnPoemWindowDisabled);
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
            
            m_poems.ShowPoem(_poemName);
            m_poemWindow.Show();
            OnPoemLoaded?.Invoke();
            
            m_loadingPoem = true;
        }

        private void OnPoemWindowDisabled()
        {
            m_loadingPoem = false;
        }
    }
}
