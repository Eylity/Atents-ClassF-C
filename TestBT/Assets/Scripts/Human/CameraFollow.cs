using DG.Tweening;
using FSM.Player;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private const float CAM_MOVE_SPEED = 5f;
    
    // 몬스터 피격시 카메라가 흔들리는 강도
    private const float DURATION = 0.2f;
    private const float STRENGTH = 0.5f;
    private const int VIBRATO = 100;
    
    // 카메라 오프셋
    [SerializeField] private Vector3 rigOffset = new Vector3(0f, 5f, 0f);
    [SerializeField] private float mouseRotateSpeed = 2f;
    private Transform m_Player;
    private float m_MouseX;
    private float m_MouseY;

    private void Awake()
    {
        m_Player = FindObjectOfType<PlayerController>().transform;

        // 무기로 타격시 카메라 흔들리는 효과 주기위한 Action함수
        var _weapons = FindObjectsOfType<Weapon>();
        foreach (var _weapon in _weapons)
        {
            _weapon.Shake += () => this.transform.DOShakePosition(DURATION, STRENGTH, VIBRATO);
        }
    }
 
    private void Update()
    {
        CamRot();
    }

    private void FixedUpdate()
    {
        FollowCam();
    }

    private void FollowCam()
    {
        // 플레이어 위치 + 오프셋만큼의 위치로 부드럽게 이동
        var _nextCamPos = m_Player.TransformPoint(rigOffset);
        transform.position = Vector3.Lerp(transform.position, _nextCamPos,CAM_MOVE_SPEED * Time.deltaTime);
    }

    private void CamRot()
    {
        // 우클릭을 누르고 있을시 카메라 회전
        if (Input.GetMouseButton(1))
        {
            m_MouseX += Input.GetAxis("Mouse X") * mouseRotateSpeed;
            
            // -를 하지 않으면 카메라가 반대로 이동
            m_MouseY += -Input.GetAxis("Mouse Y");
            
            // y값을 제한하지 않을시 카메라가 매우 이상해질수 있기에 제한값을 둠
            m_MouseY = Mathf.Clamp(m_MouseY, -50f, 0f);
            var _rotation = transform.rotation;
            _rotation = Quaternion.Euler(new Vector3(_rotation.x + m_MouseY,_rotation.y + m_MouseX, 0));
            transform.rotation = _rotation;
        }
    }
}