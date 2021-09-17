using UnityEngine;

namespace Skill
{
    public class Arrow : MonoBehaviour
    {
        private Collider m_Box;
        private const int DAMAGE = 5;

        // 공격판정을 확인할 콜라이더
        private void Awake() => m_Box = GetComponent<BoxCollider>();
        
        // 활성화시 콜라이더 활성화
        private void OnEnable() => m_Box.enabled = true;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Dragon"))
            {
                DragonController.instance.hp -= DAMAGE;
                // 연속해서 대미지 받는것을 방지하기위해 비활성화
                m_Box.enabled = false;
            }
        }
    }
}