using IP2.Character.Chunk;
using UnityEngine;

namespace IP2
{
    public class Chunks : MonoBehaviour
    {
        [SerializeField] private Chunk m_chunkPrefab;

        [SerializeField] private Vector2Int m_chunkCount = Vector2Int.one;

        private Chunk[] m_chunks;

        public Vector2 ChunkSize => m_chunkPrefab.ChunkSize;
        public Vector2Int ChunkCount => m_chunkCount;

        public Chunk[] ChunkArray => m_chunks;

        private void Awake()
        {
            m_chunks = new Chunk[m_chunkCount.x * m_chunkCount.y];
        }

        private void Start()
        {
            var midPoint = m_chunkCount / 2;
            
            for (var y = 0; y < m_chunkCount.y; y++)
            {
                for (var x = 0; x < m_chunkCount.x; x++)
                {
                    var chunk = SpawnChunk(x, y);
                    m_chunks[y * m_chunkCount.x + x] = chunk;
                }
            }
        }

        private Chunk SpawnChunk(int _x, int _y)
        {
            var position = new Vector3(m_chunkPrefab.ChunkSize.x * _x, m_chunkPrefab.ChunkSize.y * _y, 0);
            return Instantiate(m_chunkPrefab, position + transform.position, Quaternion.identity, transform);
        }
    }
}
