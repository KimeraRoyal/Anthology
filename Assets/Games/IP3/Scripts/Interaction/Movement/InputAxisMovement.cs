using UnityEngine;

namespace IP3.Interaction.Movement
{
    public class InputAxisMovement : PlaneMovement
    {
        [SerializeField] private string m_horizontalAxis = "Horizontal";
        [SerializeField] private string m_verticalAxis = "Vertical";
        
        private void Update()
        {
            var keyboardMovement = new Vector2(Input.GetAxis(m_horizontalAxis), Input.GetAxis(m_verticalAxis));
            if(keyboardMovement.magnitude < 0.001f) { return; }
            
            Move(TransformMovementPlane(keyboardMovement) * Time.deltaTime);
        }
    }
}
