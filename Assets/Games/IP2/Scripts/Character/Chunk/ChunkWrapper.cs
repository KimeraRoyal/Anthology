using IP2.Movement;
using UnityEngine;

namespace IP2
{
    [RequireComponent(typeof(MoverWrapper))]
    public class ChunkWrapper : MonoBehaviour
    {
        private Chunks m_chunks;

        private MoverWrapper m_wrapper;

        private void Awake()
        {
            m_chunks = FindObjectOfType<Chunks>();

            m_wrapper = GetComponent<MoverWrapper>();
        }

        private void Start()
        {
            var boundary = (m_chunks.ChunkSize * m_chunks.ChunkCount) / 2.0f;
            m_wrapper.Min = -boundary;
            m_wrapper.Max = boundary;
        }
    }
}
