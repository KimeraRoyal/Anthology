using System;
using UnityEngine;

namespace IP3.Movement
{
    [RequireComponent(typeof(Mover))]
    public class MoverWrapper : MonoBehaviour
    {
        private Mover m_mover;

        [SerializeField] private bool m_xWrap, m_yWrap, m_zWrap;
        [SerializeField] private Vector3 m_min, m_max;

        public Action<Vector3> OnWrapped;

        public Vector3 Min
        {
            get => m_min;
            set => m_min = value;
        }

        public Vector3 Max
        {
            get => m_max;
            set => m_max = value;
        }

        private void Awake()
        {
            m_mover = GetComponent<Mover>();

            m_mover.OnTargetPositionChanging += OnTargetPositionChanged;
        }

        private Vector3 OnTargetPositionChanged(Vector3 _targetPosition)
        {
            var targetPosition = RestrictPosition(_targetPosition);
            var offset = targetPosition - _targetPosition;

            if (offset.magnitude > 0.001f)
            {
                OnWrapped?.Invoke(offset);
                m_mover.CurrentPosition += offset;
            }
            
            return targetPosition;
        }

        private Vector3 RestrictPosition(Vector3 _position)
        {
            var wrapAxis = new[] { m_xWrap, m_yWrap, m_zWrap };
            
            for (var i = 0; i < 3; i++)
            {
                if(!wrapAxis[i]) { continue; }
                _position[i] = WrapValue(_position[i], m_min[i], m_max[i]);
            }

            return _position;
        }

        private static float WrapValue(float _value, float _min, float _max)
        {
            var offset = _max - _min;
            if (_value < _min) { _value += offset; }
            if (_value > _max) { _value -= offset; }
            return _value;
        }
    }
}