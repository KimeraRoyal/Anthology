using System;
using UnityEngine;

namespace Anthology
{
    public class CubeRotate : MonoBehaviour
    {
        [SerializeField] private Vector3 m_speed;

        private void Update()
        {
            transform.localEulerAngles += m_speed * Time.deltaTime;
        }
    }
}
