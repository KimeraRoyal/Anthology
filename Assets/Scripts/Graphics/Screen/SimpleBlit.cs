using UnityEngine;

namespace Anthology
{
    [ExecuteInEditMode]
    public class SimpleBlit : MonoBehaviour
    {
        [SerializeField] private Material m_screenEffect;
        
        private void OnRenderImage(RenderTexture _source, RenderTexture _destination)
        {
            if(!m_screenEffect) { return; }

            ApplySourceTextureProperties(_source);            
            ApplyScreenEffectProperties(m_screenEffect);
            Graphics.Blit(_source, _destination, m_screenEffect);
        }
        
        protected virtual void ApplySourceTextureProperties(RenderTexture _source) {}
        protected virtual void ApplyScreenEffectProperties(Material _screenEffect) {}
    }
}
