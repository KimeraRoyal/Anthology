using System;
using DG.Tweening;
using UnityEngine;

namespace Anthology
{
    [RequireComponent(typeof(BackgroundDistortionBlit))]
    public class DistortAnimation : MonoBehaviour
    {
        [Serializable]
        private class AnimationInformation
        {
            [SerializeField] private float m_tilingOffset;
            [SerializeField] private TweenFloat m_tiling;
            
            [SerializeField] private float m_amountOffset;
            [SerializeField] private TweenFloat m_amount;

            public Sequence PlayAnimation(BackgroundDistortionBlit _distortion)
            {
                var sequence = DOTween.Sequence();
                sequence.Insert(m_tilingOffset, m_tiling.Animate(() => _distortion.Tiling, value => _distortion.Tiling = value));
                sequence.Insert(m_amountOffset, m_amount.Animate(() => _distortion.OffsetAmount, value => _distortion.OffsetAmount = value));
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
