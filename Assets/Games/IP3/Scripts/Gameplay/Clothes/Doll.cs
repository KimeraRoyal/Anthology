using UnityEngine;

namespace IP3.Gameplay.Clothes
{
    public class Doll : MonoBehaviour
    {
        private AttachmentPoint[] m_attachmentPoints;

        public AttachmentPoint[] AttachmentPoints => m_attachmentPoints;

        private void Awake()
        {
            m_attachmentPoints = GetComponentsInChildren<AttachmentPoint>();
        }
    }
}
