using UnityEngine;

namespace IP2.UI.Panel
{
    public class DestroyOnPanelClosed : MonoBehaviour
    {
        private IP2.Panel m_panel;

        private void Awake()
        {
            m_panel = GetComponentInChildren<IP2.Panel>();
        }

        private void Start()
        {
            m_panel.OnCloseAnimationCompleted += OnCloseAnimationCompleted;
        }

        private void OnCloseAnimationCompleted()
        {
            Destroy(gameObject);
        }
    }
}