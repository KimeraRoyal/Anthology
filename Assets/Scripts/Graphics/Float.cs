using UnityEngine;
using Random = UnityEngine.Random;

public class Float : MonoBehaviour
{
    [SerializeField] private Vector3 m_offset;
    [SerializeField] private Vector3 m_minPosition, m_maxPosition;
    
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
        m_angle = (m_angle + Time.deltaTime * m_speed) % (Mathf.PI * 2.0f);

        var t = Mathf.Sin(m_angle) / 2.0f + 0.5f;
        transform.localPosition = Vector3.Lerp(m_minPosition, m_maxPosition, t) + m_offset;
    }
}
