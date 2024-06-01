using UnityEngine;

namespace IP2
{
    public interface IFocuser
    {
        public bool GetFocused();
        
        public void FocusOn(Vector3? _targetPosition);
    }
}
