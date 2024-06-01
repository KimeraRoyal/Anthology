using UnityEngine;

namespace Graphics.Reflection
{
    [RequireComponent(typeof(Renderer))] [ExecuteInEditMode]
    public class ScreenSpaceScaler : MonoBehaviour
    {
        private static readonly int MainTexSt = Shader.PropertyToID("_MainTex_ST");
    
        private Renderer m_renderer;

        [SerializeField] private Vector2Int m_targetScreenSize;

        [SerializeField] private Vector2 m_tiling = Vector2.one;
        [SerializeField] private Vector2 m_offset;

        private Vector2Int m_screenSize;
        private Vector2Int m_currentTargetScreenSize;

        private Vector2 m_currentTiling;
        private Vector2 m_currentOffset;

        private MaterialPropertyBlock m_propertyBlock;

        private MaterialPropertyBlock PropertyBlock
        {
            get
            {
                if(m_propertyBlock == null) { m_propertyBlock = new MaterialPropertyBlock(); }
                return m_propertyBlock;
            }
        }

        private void Awake()
        {
            m_renderer = GetComponent<Renderer>();
        }

        private void Update()
        {
            if(m_targetScreenSize.magnitude < 0.001f) { return; }
        
            var screenSize = new Vector2Int(Screen.width, Screen.height);
        
            if(screenSize == m_screenSize &&
               m_targetScreenSize == m_currentTargetScreenSize &&
               (m_currentTiling - m_tiling).magnitude < 0.001f &&
               (m_currentOffset - m_offset).magnitude < 0.001f) { return; }
        
            var aspect = (float)screenSize.x / screenSize.y;
            var targetAspect = (float)m_targetScreenSize.x / m_targetScreenSize.y;
            var factor = aspect / targetAspect;
        
            var textureTransform = new Vector4(m_tiling.x, m_tiling.y, m_offset.x / factor, m_offset.y);
        
            m_renderer.GetPropertyBlock(PropertyBlock);
            PropertyBlock.SetVector(MainTexSt, textureTransform);
            m_renderer.SetPropertyBlock(PropertyBlock);
        }
    }
}
