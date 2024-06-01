using IP2.Movement;
using UnityEngine;

namespace IP2
{
    [RequireComponent(typeof(Chunks))]
    public class ChunkInfiniteWorld : MonoBehaviour
    {
        private Chunks m_chunks;
        
        private Mover m_mover;
        private MoverWrapper m_wrapper;

        [SerializeField] private GameObject m_moverObject;

        private void Awake()
        {
            m_chunks = GetComponent<Chunks>();
            
            m_mover = m_moverObject.GetComponent<Mover>();
            m_wrapper = m_moverObject.GetComponent<MoverWrapper>();
        }

        private void Start()
        {
            m_mover.OnCurrentPositionChanged += OnMoverPositionChanged;
            m_wrapper.OnWrapped += OnMoverWrapped;
        }

        private void OnMoverPositionChanged(Vector3 _position)
        {
            var cameraPosition = m_moverObject.transform.position;

            var boundarySize = new Vector2(m_chunks.ChunkSize.x * m_chunks.ChunkCount.x, m_chunks.ChunkSize.y * m_chunks.ChunkCount.y);
            var boundary = boundarySize / 2.0f;
            
            foreach (var chunk in m_chunks.ChunkArray)
            {
                var dirty = false;
                
                var position = chunk.transform.position - cameraPosition;
                for (var axis = 0; axis < 2; axis++)
                {
                    if (position[axis] < -boundary[axis])
                    {
                        position[axis] += m_chunks.ChunkSize[axis] * m_chunks.ChunkCount[axis];
                        dirty = true;
                    }

                    if (position[axis] > boundary[axis])
                    {
                        position[axis] -= m_chunks.ChunkSize[axis] * m_chunks.ChunkCount[axis];
                        dirty = true;
                    }
                }
                chunk.transform.position = position + cameraPosition;
                
                if (dirty) { chunk.Populate(); }
            }
        }

        private void OnMoverWrapped(Vector3 _offset)
        {
            foreach (var chunk in m_chunks.ChunkArray)
            {
                chunk.transform.position += _offset;
            }
        }
    }
}
