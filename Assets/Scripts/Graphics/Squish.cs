using UnityEngine;

public class Squish : MonoBehaviour
{
    [SerializeField] private Vector3 m_scale = Vector3.one;
    [SerializeField] private Vector3 m_minScale = Vector3.one, m_maxScale = Vector3.one;
    
    [SerializeField] private float m_minSpeed = 1.0f, m_maxSpeed = 1.0f;

    private float m_angle;
    private float m_speed;

    private void Awake()
    {
        m_angle = Random.Range(0.0f, Mathf.PI * 2.0f);
        m_speed = Random.Range(m_minSpeed, m_maxSpeed);
    }

    private void Update()
    {
        m_angle += Time.deltaTime * m_speed;

        var t = Mathf.Sin(m_angle) / 2.0f + 0.5f;
        var squishScale = Vector3.Lerp(m_minScale, m_maxScale, t);
        
        transform.localScale = new Vector3(squishScale.x * m_scale.x, squishScale.y * m_scale.y, squishScale.z * m_scale.z);
    }
}
