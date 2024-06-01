using UnityEngine;

namespace IP2.Movement.AxisCopy
{
    public class AxisCopy : MonoBehaviour
    {
        [SerializeField] private float m_factor = 1.0f;
        [SerializeField] private float m_offset;

        private void Update()
        {
            var position = transform.position;
            transform.position = new Vector3(position.x, position.y, position.y * m_factor + m_offset);
        }
    }
}
