using UnityEngine;
using UnityEngine.UI;

namespace IP1
{
    [RequireComponent(typeof(CanvasScaler))] [ExecuteInEditMode]
    public class ScalePixelCanvas : MonoBehaviour
    {
        private CanvasScaler m_scaler;
        
        [SerializeField] private int m_heightToFit = 100;

        private int m_previousHeightToFit;
        private int m_previousHeight;

        private void Awake()
        {
            m_scaler = GetComponent<CanvasScaler>();
        }

        private void Start()
        {
            Scale();
        }

        private void Update()
        {
            if(Screen.height == m_previousHeight && m_heightToFit == m_previousHeightToFit) { return; }

            Scale();
            
            m_previousHeight = Screen.height;
            m_previousHeightToFit = m_heightToFit;
        }

        private void Scale()
        {
            var factorInteger = Screen.height / m_heightToFit;
            var factor = (float) factorInteger;
            if (factorInteger < 1) { factor = (float) Screen.height / m_heightToFit; }
            
            m_scaler.scaleFactor = factor;
        }
    }
}
