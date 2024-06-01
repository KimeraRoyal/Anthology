using UnityEngine;

namespace IP3.Movement
{
    [RequireComponent(typeof(IMover), typeof(Interaction.Movement.Movement))]
    public class MoverMovementLink : MonoBehaviour
    {
        private IMover m_mover;
        
        private Interaction.Movement.Movement[] m_movement;

        private void Awake()
        {
            m_mover = GetComponent<IMover>();

            m_movement = GetComponents<Interaction.Movement.Movement>();
        }

        private void Start()
        {
            foreach (var movement in m_movement)
            {
                movement.OnMove += Move;
            }
        }

        private void Move(Vector3 _amount)
            => m_mover.SetTargetPosition(m_mover.GetTargetPosition() + _amount);
    }
}
