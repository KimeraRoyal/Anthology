using UnityEngine;

namespace IP3.Graphics.RenderTexture
{
    [ExecuteInEditMode]
    public class RenderTextureScaler : MonoBehaviour
    {
        private Vector2Int m_screenSize;
        private int m_currentHeight;

        [SerializeField] private UnityEngine.RenderTexture m_renderTexture;
        [SerializeField] private int m_targetHeight = 100;

        private void Start()
        {
            UpdateScale();
        }

        private void Update()
        {
            UpdateScale();
        }

        private void UpdateScale()
        {
            var screenSize = new Vector2Int(Screen.width, Screen.height);
            if(!m_renderTexture || (screenSize == m_screenSize && m_currentHeight == m_targetHeight)) { return; }
            
            var aspect = (float) screenSize.x / screenSize.y;
            var targetWidth = Mathf.RoundToInt(m_targetHeight * aspect);

            m_renderTexture.Release();
            m_renderTexture.width = targetWidth;
            m_renderTexture.height = m_targetHeight;
            m_renderTexture.Create();

            m_screenSize = screenSize;
            m_currentHeight = m_targetHeight;
        }
    }
}
