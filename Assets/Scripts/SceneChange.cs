using UnityEngine;
using UnityEngine.SceneManagement;

namespace Anthology
{
    public class SceneChange : MonoBehaviour
    {
        public void LoadScene(string _sceneName)
            => SceneManager.LoadScene(_sceneName);
    }
}
