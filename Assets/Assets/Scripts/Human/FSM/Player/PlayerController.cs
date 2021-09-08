using System;
using Human;
using UnityEngine;
using XftWeapon;

namespace FSM.Player
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController GetPlayerController { get; private set; }
        public StateMachine<PlayerController> m_StateMachine;
        [HideInInspector] public bool m_ActiveFlyAttack = true;
        [HideInInspector] public bool m_ActiveFullSwing = true;
        [HideInInspector] public bool m_ActiveArea = true;
        [HideInInspector] public bool m_IsLive = true;
        [HideInInspector] public bool m_NowExhausted;

        private CharacterController m_CharacterController;
        private const float GRAVITY = 9.8f;

        [Header("----- Player Attack Collider -----")] [SerializeField]
        private BoxCollider m_AttackLeftCollider;

        public XWeaponTrail m_AttackLeftTrail;
        [SerializeField] private BoxCollider m_AttackRightCollider;
        public XWeaponTrail m_AttackRightTrail;

        [Header("----- Player Status -----")] [SerializeField]
        private float m_HealthPoint;

        [SerializeField] private float m_MaxHealthPoint = 100;
        [SerializeField] private float m_StaminaPoint;
        [SerializeField] private float m_MaxStaminaPoint = 200;
        [Range(5f, 20f)] public float m_SubOrPlusStamina = 10f;

        public float Health
        {
            get => m_HealthPoint;
            set
            {
                if (!m_IsLive) return;

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
                if (!m_IsLive) return;

                m_StaminaPoint = value;
                if (m_StaminaPoint >= m_MaxStaminaPoint)
                {
                    m_StaminaPoint = m_MaxStaminaPoint;
                }
            }
        }

        private void Awake()
        {
            if (GetPlayerController != null && GetPlayerController != this)
            {
                Destroy(this);
            }

            m_CharacterController = GetComponent<CharacterController>();
            GetPlayerController = this;
        }

        private void Start()
        {
            var anim = GetComponent<Animator>();
            m_StateMachine = new StateMachine<PlayerController>(anim, this, new Player_Idle());
            m_StateMachine.AddState(new Player_Move());
            m_StateMachine.AddState(new Player_AttackL());
            m_StateMachine.AddState(new Player_AttackR());
            m_StateMachine.AddState(new Player_LastAttack());
            m_StateMachine.AddState(new Player_Area());
            m_StateMachine.AddState(new Player_FlyAttack());
            m_StateMachine.AddState(new Player_FullSwing());
            m_StateMachine.AddState(new Player_Exhausted());
            m_StateMachine.AddState(new Player_DIe());

            Health = m_MaxHealthPoint;
            Stamina = m_MaxStaminaPoint;
        }

        private void Update()
        {
            m_CharacterController.Move(Vector3.down * (GRAVITY * Time.deltaTime));
            m_StateMachine.Update(Time.deltaTime);

            // Debug
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                TakeDamage(35f);
            }
        }

        private void FixedUpdate()
        {
            m_StateMachine.FixedUpdate(Time.deltaTime);
        }

        #region AnimEvents

        private void AttackTrue(string animName)
        {
            switch (animName)
            {
                case "AttackL":
                    m_AttackLeftCollider.enabled = true;
                    break;
                case "AttackR":
                    m_AttackRightCollider.enabled = true;
                    break;
                case "LastAttack":
                    m_AttackLeftCollider.enabled = true;
                    m_AttackRightCollider.enabled = true;
                    break;
                case "FullSwing":
                    m_AttackLeftCollider.enabled = true;
                    m_AttackRightCollider.enabled = true;
                    break;
                case "FlyAttack":
                    m_AttackRightCollider.enabled = true;
                    break;
            }
        }

        private void AttackFalse(string animName)
        {
            switch (animName)
            {
                case "AttackL":
                    m_AttackLeftCollider.enabled = false;
                    break;
                case "AttackR":
                    m_AttackRightCollider.enabled = false;
                    break;
                case "LastAttack":
                    m_AttackLeftCollider.enabled = false;
                    m_AttackRightCollider.enabled = false;
                    break;
                case "FullSwing":
                    m_AttackLeftCollider.enabled = false;
                    m_AttackRightCollider.enabled = false;
                    break;
                case "FlyAttack":
                    m_AttackRightCollider.enabled = false;
                    break;
            }
        }

        // State Name "FlyAttack"
        private void IsGround()
        {
            var obj = ObjPool.ObjectPoolInstance.GetObject(EPrefabsName.FlyAttackDust);
            obj.transform.position = transform.position;
            ObjPool.ObjectPoolInstance.ReturnObject(obj, EPrefabsName.FlyAttackDust, 1f);
        }

        #endregion

        public void TakeDamage(float damage)
        {
            if (!m_IsLive) return;

            Health -= (int) Math.Round(damage);

            if (Health > 0)
            {
                return;
            }

            m_StateMachine.ChangeState<Player_DIe>();
        }

        public void StaminaChange(bool isIdle)
        {
            Stamina = isIdle switch
            {
                true => Stamina += m_SubOrPlusStamina * Time.deltaTime,
                false => Stamina -= m_SubOrPlusStamina * Time.deltaTime
            };

            if (m_StaminaPoint > 0 || m_NowExhausted)
            {
                return;
            }

            m_NowExhausted = true;
            m_StateMachine.ChangeState<Player_Exhausted>();
        }
    }
}