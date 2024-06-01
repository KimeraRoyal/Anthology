using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    [SerializeField] private bool m_focused;

    [SerializeField] private Vector3 m_unfocusedPosition, m_focusedPosition;
    [SerializeField] private float m_smoothTime = 1.0f;

    private Vector3 m_velocity;
    
    public bool Focused
    {
        get => m_focused;
        set => m_focused = value;
    }

    private void Update()
    {
        var target = m_focused ? m_focusedPosition : m_unfocusedPosition;
        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, target, ref m_velocity, m_smoothTime);
    }
}
