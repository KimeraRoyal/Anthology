using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Anthology
{
    public class Splashes : MonoBehaviour
    {
        private Splash[] m_splashes;

        [SerializeField] private string m_nextScene;

        [SerializeField] private float m_initialPauseDuration;
        [SerializeField] private float m_pauseDuration;
        [SerializeField] private float m_finalPauseDuration;

        private void Awake()
        {
            m_splashes = GetComponentsInChildren<Splash>();
        }

        private void Start()
        {
            EndSplash(-1);
        }

        private void StartSplash(int _index)
        {
            if (_index == m_splashes.Length)
            {
                SceneManager.LoadScene(m_nextScene);
                return;
            }
            
            m_splashes[_index].OnHide.AddListener(() => EndSplash(_index));
            m_splashes[_index].Show();
        }

        private void EndSplash(int _index)
        {
            var pause = _index < 0
                ? m_initialPauseDuration
                : _index >= m_splashes.Length - 1
                    ? m_finalPauseDuration
                    : m_pauseDuration;
            
            if (pause < 0.001f)
            {
                StartSplash(_index + 1);
                return;
            }
            
            var sequence = DOTween.Sequence();
            sequence.AppendInterval(pause);
            sequence.AppendCallback(() => StartSplash(_index + 1));
        }
    }
}
