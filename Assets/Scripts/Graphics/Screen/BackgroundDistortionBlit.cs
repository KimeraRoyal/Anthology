using Sirenix.OdinInspector;
using UnityEngine;

namespace Anthology
{
    public class BackgroundDistortionBlit : SimpleBlit
    {
        private static readonly int s_interlaceTexSt = Shader.PropertyToID("_InterlaceTex_ST");
        
        [SerializeField] private TextureWrapMode m_wrapMode = TextureWrapMode.Repeat;

        [MinValue(2)] [SerializeField] private int m_interlaceDivision = 4;
        private int m_lastInterlaceDivision = -1;
        private int m_lastScreenHeight = -1;

        protected override void ApplySourceTextureProperties(RenderTexture _source)
        {
            _source.wrapMode = m_wrapMode;
        }

        protected override void ApplyScreenEffectProperties(Material _screenEffect)
        {
            ApplyInterlaceDivision(_screenEffect);
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
