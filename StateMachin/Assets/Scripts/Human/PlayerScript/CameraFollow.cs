using UnityEngine;

namespace Human.PlayerScript
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform m_Rig;
        public Transform m_Player;
        public float m_RigYPos;
        private float m_MouseX;
        void CamMove()
        {
            if (Input.GetMouseButton(1))
            {
                m_MouseX += Input.GetAxis("Mouse X");

                m_Rig.rotation = Quaternion.Euler(new Vector3(0f,
                    m_Rig.rotation.y + m_MouseX, 0));
            }
        }

        private void Update()
        {
            CamMove();
            m_Rig.position = new Vector3(m_Player.transform.position.x, m_RigYPos, m_Player.transform.position.z);
        }
    }
}