using IP2.Timer;
using UnityEngine;

namespace IP2.Graphics.SpriteAnimation
{
    public abstract class SpriteAnimator : MonoBehaviour
    {
        private TimerComponentBase m_timer;

        [SerializeField] private SpriteAnimation m_animation;

        private int m_currentFrameIndex;

        public int CurrentFrameIndex
        {
            get => m_currentFrameIndex;
            set
            {
                m_currentFrameIndex = value;
                ChangeSprite(m_animation.Frames[m_currentFrameIndex]);
            }
        }

        protected virtual void Awake()
        {
            m_timer = GetComponentInParent<TimerComponentBase>();
        }

        private void Start()
        {
            CurrentFrameIndex = m_animation.GetFirstFrameIndex();
                
            m_timer.Timer.OnInterval += NextFrame;
        }

        private void NextFrame()
            => CurrentFrameIndex = m_animation.GetNextFrameIndex(m_currentFrameIndex);

        protected abstract void ChangeSprite(Sprite _sprite);
    }
}
