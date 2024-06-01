using IP2.Movement;
using UnityEngine;

namespace IP2
{
    [RequireComponent(typeof(Mover))]
    public class MoverClamper : MonoBehaviour
    {
        private Mover m_mover;

        [SerializeField] private Vector3 m_min, m_max;
        
        private void Awake()
        {
            m_mover = GetComponent<Mover>();
            
            m_mover.OnTargetPositionChanging += OnTargetPositionChanged;
            m_mover.OnCurrentPositionChanging += OnPositionChanged;
        }

        private Vector3 OnTargetPositionChanged(Vector3 _targetPosition)
            => RestrictPosition(_targetPosition);

        private Vector3 OnPositionChanged(Vector3 _position)
            => RestrictPosition(_position);

        private Vector3 RestrictPosition(Vector3 _position)
        {
            for (var i = 0; i < 3; i++)
            {
                _position[i] = ClampValue(_position[i], m_min[i], m_max[i]);
            }
            return _position;
        }

        private static float ClampValue(float _value, float _min, float _max)
            => Mathf.Clamp(_value, _min, _max);
    }
}
