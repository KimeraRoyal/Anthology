using UnityEngine;

namespace IP2.Movement.Focus
{
    public interface IFocuser
    {
        public bool GetFocused();
        
        public void FocusOn(Vector3? _targetPosition);
    }
}
