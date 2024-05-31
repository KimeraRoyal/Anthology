using UnityEngine;

namespace IP1
{
    public class Pill : MonoBehaviour
    {
        [SerializeField] private float m_despawnHeight;

        private void Update()
        {
            if(transform.localPosition.y > m_despawnHeight) { return; }
            Destroy(gameObject);
        }
    }
}
