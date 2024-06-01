using System;
using UnityEngine;

namespace IP2.Movement
{
    public class Mover : MonoBehaviour, IMover
    {
        [SerializeField] private bool m_useLocalPosition;

        [SerializeField] private Vector3 m_factor = Vector3.one;
        [SerializeField] private Vector3 m_offset;

        private Vector3 m_targetPosition;
        private Vector3 m_currentPosition;

        public bool UseLocalPosition => m_useLocalPosition;

        public Vector3 Offset
        {
            get => m_offset;
            set => m_offset = value;
        }

        public Vector3 TargetPosition
        {
            get => m_targetPosition;
            set
            {
                if(OnTargetPositionChanging != null) { value = OnTargetPositionChanging.Invoke(value); }
                
                m_targetPosition = value;
                OnTargetPositionChanged?.Invoke(value);
            }
        }

        public Vector3 CurrentPosition
        {
            get => m_currentPosition;
            set
            {
                if(Mathf.Abs((value - CurrentPosition).magnitude) < 0.001f) { return; }

                if(OnCurrentPositionChanging != null) { value = OnCurrentPositionChanging.Invoke(value); }

                m_currentPosition = value;
                OnCurrentPositionChanged?.Invoke(m_currentPosition);
            }
        }

        public Vector3 ScaledPosition => new Vector3(TargetPosition.x * m_factor.x, TargetPosition.y * m_factor.y, TargetPosition.z * m_factor.z);
        public Vector3 OffsetPosition => ScaledPosition + Offset;

        public Func<Vector3, Vector3> OnTargetPositionChanging;
        public Action<Vector3> OnTargetPositionChanged;

        public Func<Vector3, Vector3> OnCurrentPositionChanging;
        public Action<Vector3> OnCurrentPositionChanged;

        public Func<Vector3, Vector3> OnTruePositionChanging;
        public Action<Vector3> OnTruePositionChanged;

        protected virtual void Awake()
        {
            OnCurrentPositionChanged += UpdateTruePosition;
        }

        protected virtual void Start()
        {
            m_targetPosition = m_useLocalPosition ? transform.localPosition : transform.position;
            m_currentPosition = m_targetPosition;
        }

        public Vector3 GetTargetPosition()
            => m_targetPosition;

        public void SetTargetPosition(Vector3 _targetPosition)
            => TargetPosition = _targetPosition;

        private void UpdateTruePosition(Vector3 _position)
        {
            if (OnTruePositionChanging != null) { _position = OnTruePositionChanging.Invoke(_position);  }
            
            if (m_useLocalPosition)
            {
                transform.localPosition = _position;
            }
            else
            {
                transform.position = _position;
            }
            
            OnTruePositionChanged?.Invoke(_position);
        }
    }
}
