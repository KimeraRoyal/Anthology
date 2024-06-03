using UnityEngine;
using UnityEngine.SceneManagement;

namespace Anthology
{
    public class SceneChange : MonoBehaviour
    {
        private string m_queuedScene;
        
        public void LoadScene(string _scene)
            => SceneManager.LoadScene(_scene);

        public void LoadScene()
        {
            if(string.IsNullOrEmpty(m_queuedScene)) { return; }
            LoadScene(m_queuedScene);
        }

        public void QueueScene(string _scene)
            => m_queuedScene = _scene;
    }
}
