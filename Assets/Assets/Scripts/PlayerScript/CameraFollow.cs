using System;
using UnityEngine;

namespace PlayerScript
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset = new Vector3(0f, 3f, -6f);
        public float currentZoom = 7.0f;

        float minZoom = 5.0f;
        float maxZoom = 10.0f;

        void Update()
        {
            if (Input.GetKey("z"))
            {
                // rotate toward left Yaxis
                transform.RotateAround(target.position, Vector3.up, 5.0f);

                offset = transform.position - target.position;
                offset.Normalize();
            }

            if (Input.GetKey("c"))
            {
                transform.RotateAround(target.position, Vector3.up, -5.0f);

                offset = transform.position - target.position;
                offset.Normalize();
            }

            currentZoom -= Input.GetAxis("Mouse ScrollWheel");
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        }

        void LateUpdate()
        {
            // 변경된 카메라 위치 적용
            transform.position = target.position + offset * currentZoom;
            transform.LookAt(target);
        }
    }
}