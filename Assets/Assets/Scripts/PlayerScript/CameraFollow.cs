using System;
using UnityEngine;

namespace PlayerScript
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform m_CentralAxis;
        public Transform m_Player;      
        private float m_MouseX;

        private void CamMove()
        {
            if (Input.GetMouseButton(1))
            {
                m_MouseX += Input.GetAxis("Mouse X");

                m_CentralAxis.rotation = Quaternion.Euler(new Vector3(0f,
                    m_CentralAxis.rotation.y + m_MouseX, 0));
            }
        }

        private void Update()
        {
            CamMove();
        }

        private void LateUpdate()
        {
            var position = m_Player.transform.position;
            m_CentralAxis.position = new Vector3(position.x, 3f, position.z);
        }
    }
}