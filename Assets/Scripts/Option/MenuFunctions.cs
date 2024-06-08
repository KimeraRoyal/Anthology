using System;
using IP1;
using UnityEngine;

namespace Anthology
{
    public class MenuFunctions : MonoBehaviour
    {
        private SceneChange m_sceneChange;
        private FadeImageInOut m_fader;

        private bool m_loadingGame;

        private void Awake()
        {
            m_sceneChange = FindObjectOfType<SceneChange>();
            m_fader = FindObjectOfType<FadeImageInOut>();
        }

        public void LoadGame(string _gameName)
        {
            if(m_loadingGame) { return; }
            
            m_sceneChange.QueueScene(_gameName);
            m_fader.Fade(true);

            m_loadingGame = true;
        }
    }
}
