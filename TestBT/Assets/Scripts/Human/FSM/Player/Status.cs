namespace FSM.Player
{
    public class Status
    {
        private float m_HealthPoint;
        private readonly float m_MaxHealthPoint;
        private float m_StaminaPoint;
        private readonly float m_MAXStaminaPoint;

        public float m_Damage;
        public readonly float m_RunStamina;

        public Status(float maxHealthPoint, float maxStaminaPoint, float runStamina, float damage)
        {
            this.m_MaxHealthPoint = maxHealthPoint;
            this.m_MAXStaminaPoint = maxStaminaPoint;
            m_RunStamina = runStamina;
            m_Damage = damage;
            this.m_HealthPoint = m_MaxHealthPoint;
            this.m_StaminaPoint = m_MAXStaminaPoint;
        }
        
               
        public float Health
        {
            get => m_HealthPoint;
            set
            {
                m_HealthPoint = value;
                if (m_HealthPoint > m_MaxHealthPoint)
                {
                    m_HealthPoint = m_MaxHealthPoint;
                }
            }
        }

        public float Stamina
        {
            get => m_StaminaPoint;
            set
            {
                m_StaminaPoint = value;
                if (m_StaminaPoint >= m_MAXStaminaPoint)
                {
                    m_StaminaPoint = m_MAXStaminaPoint;
                }
            }
        }
    }
}