using UnityEngine;
using Random = UnityEngine.Random;

namespace IP2.Graphics.SpriteAnimation
{
    [CreateAssetMenu(fileName = "Sprite Animation", menuName = "Graphics/Sprite Animation")]
    public class SpriteAnimation : ScriptableObject
    {
        public enum RandomizationMethod
        {
            None,
            Random,
            NoRepeats
        }
        
        [SerializeField] private Sprite[] m_frames;

        [SerializeField] private bool m_startOnRandomFrame;
        [SerializeField] private RandomizationMethod m_randomizePerFrame;

        public Sprite[] Frames => m_frames;

        public bool StartOnRandomFrame => m_startOnRandomFrame;
        public RandomizationMethod RandomizePerFrame => m_randomizePerFrame;

        public int GetFirstFrameIndex()
            => !m_startOnRandomFrame ? 0 : GetRandomFrame();

        public int GetNextFrameIndex(int _currentFrameIndex)
            => m_randomizePerFrame switch
            {
                RandomizationMethod.None => GetConsecutiveFrame(_currentFrameIndex),
                RandomizationMethod.Random => GetRandomFrame(),
                RandomizationMethod.NoRepeats => GetRandomOtherFrame(_currentFrameIndex),
                _ => -1
            };

        private int GetConsecutiveFrame(int _currentFrameIndex)
            => (_currentFrameIndex + 1) % m_frames.Length;
        
        private int GetRandomFrame()
            => Random.Range(0, m_frames.Length);

        private int GetRandomOtherFrame(int _currentFrameIndex)
        {
            if (m_frames.Length < 2) { return _currentFrameIndex; }
                    
            var randomIndex = Random.Range(0, m_frames.Length - 1);
            if (randomIndex >= _currentFrameIndex) { randomIndex++; }

            return randomIndex;
        }
    }
}
