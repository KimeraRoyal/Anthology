using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Anthology
{
    [RequireComponent(typeof(BackgroundDistortionBlit))]
    public class DistortAnimation : MonoBehaviour
    {
        [Serializable]
        private class AnimationInformation
        {
            [Title("Tiling")]
            [SerializeField] private bool m_animateTiling;
            [SerializeField] private float m_tilingOffset;
            [SerializeField] private TweenFloat m_tiling;

            [Title("Offset Amount")]
            [SerializeField] private bool m_animateAmount;
            [SerializeField] private float m_amountOffset;
            [SerializeField] private TweenFloat m_amount;

            [Title("Scroll Speed")]
            [SerializeField] private bool m_animateScrollSpeed;
            [SerializeField] private float m_scrollSpeedOffset;
            [SerializeField] private TweenFloat m_scrollSpeed;

            [Title("Scroll Amount")]
            [SerializeField] private bool m_animateScrollAmount;
            [SerializeField] private float m_scrollAmountOffset;
            [SerializeField] private TweenFloat m_scrollAmount;

            public Sequence PlayAnimation(BackgroundDistortionBlit _distortion)
            {
                var sequence = DOTween.Sequence();
                if (m_animateTiling) { sequence.Insert(m_tilingOffset, m_tiling.Animate(() => _distortion.Tiling, value => _distortion.Tiling = value)); }
                if (m_animateAmount) { sequence.Insert(m_amountOffset, m_amount.Animate(() => _distortion.OffsetAmount, value => _distortion.OffsetAmount = value)); }
                if (m_animateScrollSpeed) { sequence.Insert(m_scrollSpeedOffset, m_scrollSpeed.Animate(() => _distortion.OffsetScrollSpeed, value => _distortion.OffsetScrollSpeed = value)); }
                if (m_animateScrollAmount) { sequence.Insert(m_scrollAmountOffset, m_scrollAmount.Animate(() => _distortion.OffsetScrollAmount, value => _distortion.OffsetScrollAmount = value)); }
                return sequence;
            }
        }
        
        private BackgroundDistortionBlit m_distortion;

        [SerializeField] private AnimationInformation[] m_animations;

        private Sequence m_sequence;

        private void Awake()
        {
            m_distortion = GetComponent<BackgroundDistortionBlit>();
        }

        public void PlayAnimation(int _index)
        {
            if(_index >= m_animations.Length) { return; }
            
            if(m_sequence is { active: true }) { m_sequence.Kill(); }
            m_sequence = m_animations[_index].PlayAnimation(m_distortion);
        }
    }
}
