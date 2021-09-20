using UnityEngine;

namespace Skill
{
    public class Arrow : MonoBehaviour
    {
        private const int DAMAGE = 5;
        private Collider m_HitArea;

        // 공격판정을 확인할 콜라이더
        private void Awake() => m_HitArea = GetComponent<BoxCollider>();
        
        // 활성화시 콜라이더 활성화
        private void OnEnable() => m_HitArea.enabled = true;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Dragon"))
            {
                DragonController.instance.hp -= DAMAGE;
                // 연속해서 대미지 받는것을 방지하기위해 비활성화
                m_HitArea.enabled = false;
            }
        }
    }
}