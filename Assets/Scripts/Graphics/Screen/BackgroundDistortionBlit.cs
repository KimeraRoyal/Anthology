using Sirenix.OdinInspector;
using UnityEngine;

namespace Anthology
{
    public class BackgroundDistortionBlit : SimpleBlit
    {
        private static readonly int s_interlaceTexSt = Shader.PropertyToID("_InterlaceTex_ST");
        
        private static readonly int s_tiling = Shader.PropertyToID("_Tiling");
        
        private static readonly int s_offset = Shader.PropertyToID("_Offset");
        private static readonly int s_offsetSpeed = Shader.PropertyToID("_OffsetSpeed");
        private static readonly int s_offsetScroll = Shader.PropertyToID("_OffsetScroll");
        
        [SerializeField] private TextureWrapMode m_wrapMode = TextureWrapMode.Repeat;

        [MinValue(2)] [SerializeField] private int m_interlaceDivision = 4;
        private int m_lastInterlaceDivision = -1;
        private int m_lastScreenHeight = -1;

        [SerializeField] private float m_tiling = 1.0f;
        
        [Range(-1.0f, 1.0f)]  [SerializeField] private float m_offsetAmount;
        [Range(-10.0f, 10.0f)] [SerializeField] private float m_offsetScrollSpeed = 1.0f;
        [Range(0.0f, 1.0f)] [SerializeField] private float m_offsetScrollAmount;

        public float Tiling
        {
            get => m_tiling;
            set => m_tiling = value;
        }

        public float OffsetAmount
        {
            get => m_offsetAmount;
            set => m_offsetAmount = value;
        }

        public float OffsetScrollSpeed
        {
            get => m_offsetScrollSpeed;
            set => m_offsetScrollSpeed = value;
        }

        public float OffsetScrollAmount
        {
            get => m_offsetScrollAmount;
            set => m_offsetScrollAmount = value;
        }

        protected override void ApplySourceTextureProperties(RenderTexture _source)
        {
            _source.wrapMode = m_wrapMode;
        }

        protected override void ApplyScreenEffectProperties(Material _screenEffect)
        {
            ApplyInterlaceDivision(_screenEffect);
            
            _screenEffect.SetFloat(s_tiling, m_tiling);
            
            _screenEffect.SetFloat(s_offset, m_offsetAmount);
            _screenEffect.SetFloat(s_offsetSpeed, m_offsetScrollSpeed);
            _screenEffect.SetFloat(s_offsetScroll, m_offsetScrollAmount);
        }

        private void ApplyInterlaceDivision(Material _screenEffect)
        {
            var screenHeight = Screen.height;
            if(m_interlaceDivision == m_lastInterlaceDivision && screenHeight == m_lastScreenHeight) { return; }

            var tilingOffset = _screenEffect.GetVector(s_interlaceTexSt);
            tilingOffset.y = screenHeight / m_interlaceDivision;
            _screenEffect.SetVector(s_interlaceTexSt, tilingOffset);
            
            m_lastInterlaceDivision = m_interlaceDivision;
            m_lastScreenHeight = screenHeight;
        }
    }
}
