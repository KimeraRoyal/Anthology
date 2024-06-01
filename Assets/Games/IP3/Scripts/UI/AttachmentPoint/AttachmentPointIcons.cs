using IP3.Gameplay.Clothes;
using UnityEngine;

namespace UI.Icons
{
    public class AttachmentPointIcons : MonoBehaviour
    {
        [SerializeField] private AttachmentPointIcon m_iconPrefab;

        private AttachmentPointIcon[] m_icons;

        private void Start()
        {
            var doll = FindObjectOfType<Doll>();

            m_icons = new AttachmentPointIcon[doll.AttachmentPoints.Length];
            for(var i = 0; i < m_icons.Length; i++)
            {
                m_icons[i] = SpawnIcon(doll.AttachmentPoints[i]);
            }
        }

        private AttachmentPointIcon SpawnIcon(AttachmentPoint _attachmentPoint)
        {
            var icon = Instantiate(m_iconPrefab, transform);
            icon.LinkToPoint(_attachmentPoint);
            return icon;
        }
    }
}
