using UnityEngine;

namespace IP2.Movement
{
    public class InstantMover : Mover
    {
        protected override void Start()
        {
            base.Start();
            
            OnTargetPositionChanged += UpdatePosition;
        }

        private void UpdatePosition(Vector3 _targetPosition)
            => CurrentPosition = OffsetPosition;
    }
}