using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class PulseSizeDelta : MonoBehaviour
{
    private RectTransform m_rectTransform;
    
    [SerializeField] private Vector2 m_a, m_b;
    [SerializeField] private float m_speed = 1.0f;

    private float m_timer;

    private void Awake()
    {
        m_rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        m_timer += Time.deltaTime;
        var t = Mathf.Sin(m_timer * m_speed) * 0.5f + 0.5f;

        m_rectTransform.sizeDelta = Vector2.Lerp(m_a, m_b, t);
    }
}
