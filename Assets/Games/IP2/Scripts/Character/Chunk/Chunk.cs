using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace IP2.Character.Chunk
{
    public class Chunk : MonoBehaviour
    {
        [SerializeField] private CharacterInfo m_characterPrefab;

        [Range(1, 100)] [SerializeField] private int m_minCharacterCount = 1, m_maxCharacterCount = 1;
        [SerializeField] private Vector2 m_chunkSize = Vector2.one;

        private CharacterInfo[] m_characters;
        private int m_spawnedCharacterCount;

        public Vector2Int CharacterCountRange => new Vector2Int(m_minCharacterCount, m_maxCharacterCount);
        public int CharacterCount => m_spawnedCharacterCount;

        public Vector2 ChunkSize => m_chunkSize;

        private void Awake()
        {
            m_characters = new CharacterInfo[m_maxCharacterCount];
        }

        private void Start()
        {
            Populate();
        }

        public void Populate()
        {
            var count = Random.Range(m_minCharacterCount, m_maxCharacterCount);
            var quadrant = Random.Range(0, 4);
            
            for (var i = 0; i < count; i++)
            {
                SpawnCharacter(i, quadrant);
                quadrant = (quadrant + 1) % 4;
            }

            for (var i = count; i < m_spawnedCharacterCount; i++)
            {
                m_characters[i].gameObject.SetActive(false);
            }
        }

        private void SpawnCharacter(int _index, int _quadrant)
        {
            var left = _quadrant % 2 == 0;
            var up = _quadrant < 2;

            var xRange = (left ? Vector2.left : Vector2.right) * (m_chunkSize.x / 2.0f);
            var yRange = (up ? Vector2.up : Vector2.down) * (m_chunkSize.y / 2.0f);
            
            var position = new Vector3(Random.Range(xRange[0], xRange[1]), Random.Range(yRange[0], yRange[1]), 0) + transform.position;

            if (m_spawnedCharacterCount > _index)
            {
                m_characters[_index].gameObject.SetActive(true);
                
                m_characters[_index].transform.position = position;
                m_characters[_index].Personify();
            }
            else
            {
                m_characters[_index] = Instantiate(m_characterPrefab, position, Quaternion.identity, transform);
            }
            m_spawnedCharacterCount = Math.Max(m_spawnedCharacterCount, _index + 1);
        }

        private void OnValidate()
        {
            if (m_minCharacterCount > m_maxCharacterCount) { m_minCharacterCount = m_maxCharacterCount; }
        }
    }
}
