using UnityEngine;
using UnityEngine.UI;

public class PulseImageFade : MonoBehaviour
{
    private Image m_image;
    
    [SerializeField] private Color m_a = Color.white, m_b = Color.white;
    [SerializeField] private float m_speed = 1.0f;

    private float m_timer;

    private void Awake()
    {
        m_image = GetComponent<Image>();
    }

    private void Update()
    {
        m_timer += Time.deltaTime;
        var t = Mathf.Sin(m_timer * m_speed) * 0.5f + 0.5f;

        m_image.color = Color.Lerp(m_a, m_b, t);
    }
}
