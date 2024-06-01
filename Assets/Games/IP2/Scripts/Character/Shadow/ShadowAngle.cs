using UnityEngine;

namespace IP2.Character.Shadow
{
    public class ShadowAngle : MonoBehaviour
    {
        private Shadows m_shadows;

        private void Awake()
        {
            m_shadows = GetComponentInParent<Shadows>();
        }

        private void Start()
        {
            SetAngle(m_shadows.ShadowAngle);

            m_shadows.OnShadowAngleChanged += SetAngle;
        }

        private void SetAngle(float _angle)
        {
            var euler = transform.eulerAngles;
            euler.z = _angle;
            transform.eulerAngles = euler;
        }
    }
}
