using UnityEngine;

namespace Anthology
{
    public class BackgroundDistortionBlit : SimpleBlit
    {
        [SerializeField] private TextureWrapMode m_wrapMode = TextureWrapMode.Repeat;
        
        protected override void ApplySourceTextureProperties(RenderTexture _source)
        {
            _source.wrapMode = m_wrapMode;
        }
    }
}
