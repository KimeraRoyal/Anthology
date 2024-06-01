using UnityEngine;
using UnityEngine.UI;

namespace Anthology.Exit
{
    [RequireComponent(typeof(Image))]
    public class ExitFade : MonoBehaviour
    {
        private Exit m_exit;
        
        private Image m_fade;
        
        [SerializeField] private AnimationCurve m_fadeCurve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);

        private void Awake()
        {
            m_exit = FindObjectOfType<Exit>();

            m_fade = GetComponent<Image>();
            
            m_exit.OnTimerCounter.AddListener(OnTimerCounter);
        }

        private void OnTimerCounter(float _a)
        {
            var color = m_fade.color;
            color.a = m_fadeCurve.Evaluate(_a);
            m_fade.color = color;
        }
    }
}
