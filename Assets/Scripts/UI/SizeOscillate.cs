using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Anthology
{
    public class SizeOscillate : MonoBehaviour
    {
        private RectTransform m_rectTransform;

        [SerializeField] private Vector2 m_min = Vector2.one, m_max = Vector2.one;
        [SerializeField] private float m_speed = 1.0f;

        private float m_timer;
        
        private void Awake()
        {
            m_rectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            m_timer = (m_timer + Time.deltaTime * m_speed) % (Mathf.PI * 2.0f);
            var t = Mathf.Sin(m_timer) * 0.5f + 0.5f;

            m_rectTransform.sizeDelta = Vector2.Lerp(m_min, m_max, t);
        }
    }
}
