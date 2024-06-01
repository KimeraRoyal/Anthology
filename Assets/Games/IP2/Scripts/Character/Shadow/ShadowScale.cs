using UnityEngine;

namespace IP2.Character.Shadow
{
    public class ShadowScale : MonoBehaviour
    {
        private Shadows m_shadows;

        private void Awake()
        {
            m_shadows = GetComponentInParent<Shadows>();
        }

        private void Start()
        {
            SetScale(m_shadows.ShadowScale);

            m_shadows.OnShadowScaleChanged += SetScale;
        }

        private void SetScale(float _scale)
        {
            var scale = transform.localScale;
            scale.y = _scale;
            transform.localScale = scale;
        }
    }
}
