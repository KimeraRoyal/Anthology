using UnityEngine;

namespace IP3.Movement
{
    public interface IMover
    {
        public Vector3 GetTargetPosition();
        public void SetTargetPosition(Vector3 _targetPosition);
    }
}
