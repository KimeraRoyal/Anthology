using System.Linq;
using DG.Tweening;
using IP3.Interaction.Click;
using IP3.Movement;
using UnityEngine;

namespace IP3.Gameplay.Clothes
{
    public class ClothingAttacher : Mover
    {
        private AttachmentPoint m_attachmentPoint;

        private Clickable m_clickable;
        private Clothing m_clothing;

        private ClothingStatModifiers m_statModifiers;

        [SerializeField] private float m_attachDistance = 1.0f;
        [SerializeField] private float m_movementSmoothTime = 1.0f;
        [SerializeField] private float m_resetDuration = 1.0f;

        private Transform m_detachedParent;
        private Transform m_attachedParent;
        private bool m_parentedToAttachedParent;

        private Vector3 m_startingPosition;
        private Vector3 m_truePosition;
        private Vector3 m_attachmentPosition;

        private bool m_attach;
        private float m_attachment;
        private float m_attachmentVelocity;

        private Tween m_resetTween;

        public ClothingStatModifiers StatModifiers => m_statModifiers;

        protected override void Awake()
        {
            base.Awake();

            m_clickable = GetComponent<Clickable>();
            m_clothing = GetComponent<Clothing>();

            m_statModifiers = GetComponent<ClothingStatModifiers>();

            m_detachedParent = transform.parent;
            m_attachedParent = m_detachedParent ? m_detachedParent.parent : null;
        }

        protected override void Start()
        {
            base.Start();

            var doll = FindObjectOfType<Doll>();
            m_attachmentPoint = doll.AttachmentPoints.First(_attachmentPoint => _attachmentPoint.gameObject.name == m_clothing.AttachmentPointName);
            
            OnTargetPositionChanged += UpdatePosition;
            UpdatePosition(TargetPosition);
            m_startingPosition = TargetPosition;
        
            m_clickable.OnClicked.AddListener(OnClicked);
            m_clickable.OnReleased.AddListener(OnReleased);
        }

        private void Update()
        {
            var attachmentAmount = m_attach ? 1.0f : 0.0f;

            m_attachment = Mathf.SmoothDamp(m_attachment, attachmentAmount, ref m_attachmentVelocity, m_movementSmoothTime);

            switch (m_attach)
            {
                case true when !m_parentedToAttachedParent:
                {
                    if (m_attachment >= 1.0f - 0.001f)
                    {
                        transform.SetParent(m_attachedParent);
                        m_parentedToAttachedParent = true;
                    }
                    break;
                }
                case false when m_parentedToAttachedParent:
                {
                    if (m_attachment <= 0.001f)
                    {
                        transform.SetParent(m_detachedParent);
                        m_parentedToAttachedParent = false;
                    }
                    break;
                }
            }
        
            var position = Vector3.Lerp(m_truePosition, m_attachmentPosition, m_attachment);
            position.z = m_clickable.Held ? -1 : 0;
            CurrentPosition = position;
        }

        private void UpdatePosition(Vector3 _targetPosition)
        {
            m_truePosition = OffsetPosition;
        
            m_attachmentPosition = m_attachmentPoint.transform.position;
            m_attach = Vector3.Distance(m_attachmentPosition, m_truePosition) < m_attachDistance;
        
            if(!m_attach) { m_attachmentPoint.DetachClothing(this, false); }
        }

        private void OnClicked()
        {
            if(m_resetTween is { active: true }) { m_resetTween.Kill(); }
        }

        private void OnReleased()
        {
            if (m_attach)
            {
                m_attachmentPoint.AttachClothing(this);
            }
            else
            {
                Reset();
            }
        }

        public void Reset()
        {
            if(m_resetTween is { active: true }) { m_resetTween.Kill(); }

            var distanceMagnitude = Vector3.Distance(CurrentPosition, TargetPosition);
            DOTween.To(() => TargetPosition, _value => TargetPosition = _value, m_startingPosition, m_resetDuration * distanceMagnitude);
        }
    }
}
