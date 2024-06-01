using UnityEngine;

namespace IP3.Movement
{
    [RequireComponent(typeof(Mover))]
    public class MoverClamper : MonoBehaviour
    {
        private Mover m_mover;

        [SerializeField] private Vector3 m_min, m_max;
        
        [SerializeField] private bool m_useColliderBounds;

        private Bounds m_colliderBounds;
        
        private void Awake()
        {
            m_mover = GetComponent<Mover>();
            
            m_mover.OnTargetPositionChanging += OnTargetPositionChanged;
            m_mover.OnCurrentPositionChanging += OnPositionChanged;
        }

        private void Start()
        {
            var childColliders = GetComponentsInChildren<PolygonCollider2D>();

            var min = Vector2.one * float.MaxValue;
            var max = Vector2.one * float.MinValue;

            foreach (var childCollider in childColliders)
            {
                foreach (var point in childCollider.points)
                {
                    var offset = (Vector2) childCollider.transform.localPosition;
                    min = Vector2.Min(min, point + offset);
                    max = Vector2.Max(max, point + offset);
                }
            }

            var size = max - min;
            var center = min + size / 2.0f;
            
            m_colliderBounds = new Bounds(center, size);
        }

        private Vector3 OnTargetPositionChanged(Vector3 _targetPosition)
            => RestrictPosition(_targetPosition);

        private Vector3 OnPositionChanged(Vector3 _position)
            => RestrictPosition(_position);

        private Vector3 RestrictPosition(Vector3 _position)
        {
            for (var i = 0; i < 3; i++)
            {
                if(m_useColliderBounds) { _position[i] = ClampValueBounded(_position[i], m_colliderBounds.min[i], m_colliderBounds.max[i], m_min[i], m_max[i]); }
                else { _position[i] = ClampValue(_position[i], m_min[i], m_max[i]); }
            }
            return _position;
        }

        private static float ClampValue(float _value, float _min, float _max)
            => Mathf.Clamp(_value, _min, _max);

        private static float ClampValueBounded(float _value, float _boundMin, float _boundMax, float _min, float _max)
        {
            if(_value + _boundMin < _min) { return Mathf.Clamp(_value + _boundMin, _min, _max) - _boundMin; }
            return Mathf.Clamp(_value + _boundMax, _min, _max) - _boundMax;
        }
    }
}
