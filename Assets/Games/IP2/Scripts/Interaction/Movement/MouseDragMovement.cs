using UnityEngine;

namespace IP2.Interaction.Movement
{
    public class MouseDragMovement : PlaneMovement
    {
        private void Update()
        {
            var keyboardMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            if(keyboardMovement.magnitude < 0.001f) { return; }
            
            Move(TransformMovementPlane(keyboardMovement));
        }
        
        protected override void Move(Vector3 _amount)
        {
            if(!Input.GetMouseButton(0)) { return; }
            base.Move(_amount);
        }
    }
}
