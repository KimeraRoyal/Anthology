using UnityEngine;

public class Hoverer : MonoBehaviour
{
    [SerializeField] private Camera m_camera;

    [SerializeField] private LayerMask m_mask;
        
    private Hoverable m_hovered;

    private void Awake()
    {
        if (!m_camera) { m_camera = GetComponent<Camera>(); }
    }

    private void Update()
    {
        Hoverable hovered = null;
        if (ShootRay(out var _rayHit))
        {
            hovered = _rayHit.collider.GetComponentInParent<Hoverable>();
            if(!hovered || m_hovered == hovered) { return; }
            
            hovered.Hover();
        }
        
        if(m_hovered)
        {
            m_hovered.Unhover();
        }
        m_hovered = hovered;
    }

    private bool ShootRay(out RaycastHit o_rayHit)
    {
        var ray = m_camera.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out o_rayHit, m_camera.farClipPlane, m_mask);
    }
}
