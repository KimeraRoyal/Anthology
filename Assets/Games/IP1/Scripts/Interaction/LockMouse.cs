using UnityEngine;

namespace IP1.Interaction
{
    public class LockMouse : MonoBehaviour
    {
        [SerializeField] private CursorLockMode m_cursorLockState = CursorLockMode.Confined;
        [SerializeField] private bool m_cursorVisible;
        
        private void Start()
        {
            Cursor.lockState = m_cursorLockState;
            Cursor.visible = m_cursorVisible;
        }
    }
}
