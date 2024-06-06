using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera m_camera;

    private void Awake()
    {
        m_camera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        transform.LookAt(m_camera.transform);
    }
}
