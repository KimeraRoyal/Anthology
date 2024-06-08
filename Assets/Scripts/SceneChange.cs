using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Anthology
{
    public class SceneChange : MonoBehaviour
    {
        [SerializeField] private float m_delay;
        
        private string m_queuedScene;

        public void LoadScene(string _scene)
            => StartCoroutine(LoadSceneWithDelay(_scene));

        private IEnumerator LoadSceneWithDelay(string _scene)
        {
            if(m_delay > 0.001f) { yield return new WaitForSeconds(m_delay); }
            SceneManager.LoadScene(_scene);
        }

        public void LoadScene()
        {
            if(string.IsNullOrEmpty(m_queuedScene)) { return; }
            LoadScene(m_queuedScene);
        }

        public void QueueScene(string _scene)
            => m_queuedScene = _scene;
    }
}
