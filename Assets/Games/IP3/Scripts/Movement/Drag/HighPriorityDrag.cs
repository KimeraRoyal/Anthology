using IP3.Interaction.Click;
using UnityEngine;

namespace IP3.Movement.Drag
{
    [RequireComponent(typeof(Mover), typeof(Clickable))]
    public class HighPriorityDrag : MonoBehaviour
    {
        private Clickable m_clickable;

        [SerializeField] private float m_heldOffset;

        private void Awake()
        {
            m_clickable = GetComponentInParent<Clickable>();
        }

        private void Start()
        {
            m_clickable.OnHeld += OnHeld;
            m_clickable.OnReleased += OnReleased;
        }

        private void OnHeld()
        {
            var position = transform.localPosition;
            position.z = m_heldOffset;
            transform.localPosition = position;
        }
        
        private void OnReleased()
        {
            var position = transform.localPosition;
            position.z = 0;
            transform.localPosition = position;
        }

    }
}
