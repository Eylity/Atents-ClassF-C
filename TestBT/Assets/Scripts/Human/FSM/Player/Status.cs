namespace FSM.Player
{
    public class Status
    {
        // 플레이어의 기본 스탯
        private float m_HealthPoint;
        private const float MAX_HEALTH_POINT = 100f;
        private float m_StaminaPoint;
        private const float MAX_STAMINA_POINT = 200f;

        public float damage = 5f;
        public const float RUN_STAMINA = 10f;
        public float rotateSpeed = 8f;
        public float moveSpeed = 4f;

        // 플레이어의 체력
        public float Health
        {
            // 현재 체력값을 리턴
            get => m_HealthPoint;
            set
            {
                m_HealthPoint = value;
                // 최대 체력 제한
                if (m_HealthPoint > MAX_HEALTH_POINT)
                {
                    m_HealthPoint = MAX_HEALTH_POINT;
                }
            }
        }

        // 플레이어의 스태미너
        public float Stamina
        {
            // 현재 스태미너값을 리턴
            get => m_StaminaPoint;
            set
            {
                m_StaminaPoint = value;
                // 최대 스태미너 제한
                if (m_StaminaPoint >= MAX_STAMINA_POINT)
                {
                    m_StaminaPoint = MAX_STAMINA_POINT;
                }
            }
        }

        // 현재 체력값과 스태미너값 대입
        public Status()
        {
            m_HealthPoint = MAX_HEALTH_POINT;
            m_StaminaPoint = MAX_STAMINA_POINT;
        }
    }
}