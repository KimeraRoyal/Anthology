using IP2.Timer;
using UnityEngine;

namespace IP2.Graphics.SpriteAnimation
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpritesetAnimator : MonoBehaviour
    {
        private SpriteRenderer m_spriteRenderer;
        private TimerComponentBase m_timer;

        [SerializeField] private SpriteAnimationSet m_animationSet;

        private int m_currentAnimationIndex;
        private int m_currentFrameIndex;

        public int CurrentAnimationIndex
        {
            get => m_currentAnimationIndex;
            set
            {
                m_currentAnimationIndex = value;
                CurrentFrameIndex = m_animationSet.GetAnimation(m_currentAnimationIndex).GetFirstFrameIndex();
            }
        }

        public int CurrentFrameIndex
        {
            get => m_currentFrameIndex;
            set
            {
                m_currentFrameIndex = value;
                m_spriteRenderer.sprite = m_animationSet.GetAnimation(m_currentAnimationIndex).Frames[m_currentFrameIndex];
            }
        }

        private void Awake()
        {
            m_spriteRenderer = GetComponent<SpriteRenderer>();
            m_timer = GetComponentInParent<TimerComponentBase>();
        }

        private void Start()
        {
            CurrentAnimationIndex = m_animationSet.GetFirstAnimationIndex();
                
            m_timer.Timer.OnInterval += NextFrame;
        }

        private void NextFrame()
            => CurrentFrameIndex = m_animationSet.GetAnimation(m_currentAnimationIndex).GetNextFrameIndex(m_currentFrameIndex);
    }
}
