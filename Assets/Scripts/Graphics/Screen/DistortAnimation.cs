using DG.Tweening;
using UnityEngine;

namespace Anthology
{
    [RequireComponent(typeof(BackgroundDistortionBlit))]
    public class DistortAnimation : MonoBehaviour
    {
        private BackgroundDistortionBlit m_distortion;

        [SerializeField] private float m_tilingOffset;
        [SerializeField] private float m_tilingTarget = 1.0f;
        [SerializeField] private float m_tilingDuration = 1.0f;
        [SerializeField] private Ease m_tilingEase = Ease.Linear;
        
        [SerializeField] private float m_amountOffset;
        [SerializeField] private float m_amountTarget = 1.0f;
        [SerializeField] private float m_amountDuration = 1.0f;
        [SerializeField] private Ease m_amountEase = Ease.Linear;

        private Sequence m_sequence;

        private void Awake()
        {
            m_distortion = GetComponent<BackgroundDistortionBlit>();
        }

        public void Play()
        {
            if(m_sequence is { active: true }) { m_sequence.Kill(); }

            m_sequence = DOTween.Sequence();
            m_sequence.Insert(m_tilingOffset, DOTween
                .To(() => m_distortion.Tiling, value => m_distortion.Tiling = value, m_tilingTarget, m_tilingDuration)
                .SetEase(m_tilingEase));
            m_sequence.Insert(m_amountOffset, DOTween
                .To(() => m_distortion.OffsetAmount, value => m_distortion.OffsetAmount = value, m_amountTarget, m_amountDuration)
                .SetEase(m_amountEase));
        }
    }
}
