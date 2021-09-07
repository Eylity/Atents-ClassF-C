using System;
using UnityEngine;
using XftWeapon;
using Human;

namespace Human
{
    public enum EPlayerState
    {
        IDLE,
        MOVE,
        RUN,
        ATTACK,
        ATTACKR,
        FLY_ATTACK,
        FULL_SWING,
        SKILL,
        EXHAUSTED,
        DIE,
        LENGTH
    }

    public class PlayerController : MonoBehaviour
    {
        public StateMachine<PlayerController> m_StateMachine;

        public static PlayerController GetPlayerController { get; private set; }

        [HideInInspector] public CharacterController m_CharacterController;
        [HideInInspector] public Animator m_Anim;

        private const float MASS = 3f;
        private const float GRAVITY = 9.8f;
        private Vector3 m_Impact = Vector3.zero;

        public EPlayerState m_CurState;
        [HideInInspector] public bool m_ActiveFlyAttack = true;
        [HideInInspector] public bool m_ActiveFullSwing = true;
        [HideInInspector] public bool m_ActiveArea = true;
        [HideInInspector] public bool m_IsLive = true;
        [HideInInspector] public bool m_NowExhausted;

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
        [SerializeField] private float m_PlayerDamage = 20f;

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

            GetPlayerController = this;
            m_CharacterController = GetComponent<CharacterController>();
            m_Anim = GetComponent<Animator>();
        }

        private void Start()
        {
            m_StateMachine = new StateMachine<PlayerController>(m_Anim, this, new Idle());
            m_StateMachine.AddState(new AttackL());
            m_StateMachine.AddState(new AttackR());
            m_StateMachine.AddState(new LastAttack());
            m_StateMachine.AddState(new Area());
            m_StateMachine.AddState(new FlyAttack());
            m_StateMachine.AddState(new FullSwing());
            m_StateMachine.AddState(new Exhausted());
            m_StateMachine.AddState(new DIe());
            m_StateMachine.ONStateChanged += () => { Debug.Log("state changed: " + m_StateMachine.CurrentState); };

            Health = m_MaxHealthPoint;
            Stamina = m_MaxStaminaPoint;
        }

        private void Update()
        {
            m_CharacterController.Move(Vector3.down * (GRAVITY * Time.deltaTime));
            m_StateMachine.Update(Time.deltaTime);
            StaminaChange();

            // Debug
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                TakeDamage(35f);
            }

            if (m_Impact.magnitude > 0.2)
            {
                m_CharacterController.Move(m_Impact * Time.deltaTime);
            }

            m_Impact = Vector3.Lerp(m_Impact, Vector3.zero, 5 * Time.deltaTime);
        }


        public void AddImpact(Vector3 dir, float force)
        {
            dir.Normalize();
            if (dir.y < 0) dir.y = -dir.y;
            m_Impact += dir.normalized * force / MASS;
        }

        #region AnimEvents

        private void AttackTrue(string animName)
        {
            switch (animName)
            {
                case "AttackL":
                    CollSwitch(true, m_AttackLeftCollider);
                    break;
                case "AttackR":
                    CollSwitch(true, m_AttackRightCollider);
                    break;
                case "LastAttack":
                    CollSwitch(true);
                    break;
                case "FullSwing":
                    CollSwitch(true);
                    break;
                case "FlyAttack":
                    CollSwitch(true, m_AttackRightCollider);
                    break;
            }
        }

        private void AttackFalse(string animName)
        {
            switch (animName)
            {
                case "AttackL":
                    CollSwitch(false, m_AttackLeftCollider);
                    break;
                case "AttackR":
                    CollSwitch(false, m_AttackRightCollider);
                    break;
                case "LastAttack":
                    CollSwitch(false);
                    break;
                case "FullSwing":
                    CollSwitch(false);
                    break;
                case "FlyAttack":
                    CollSwitch(false, m_AttackRightCollider);
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

        private void CollSwitch(bool isActive)
        {
            m_AttackLeftCollider.enabled = isActive;
            m_AttackRightCollider.enabled = isActive;
        }

        private void CollSwitch(bool isActive, Collider leftOrRight)
        {
            leftOrRight.enabled = isActive;
        }

        public void TakeDamage(float damage)
        {
            if (!m_IsLive) return;

            Health -= (int) Math.Round(damage);

            // if (Health <= 0)
            // {
            //     ChangeState(EPlayerState.DIE);
            // }
        }


        private void StaminaChange()
        {
            switch (m_CurState)
            {
                case EPlayerState.RUN:
                    Stamina -= m_SubOrPlusStamina * 1.5f * Time.deltaTime;
                    break;
                case EPlayerState.IDLE:
                    Stamina += m_SubOrPlusStamina * 1.5f * Time.deltaTime;
                    break;
                default:
                    Stamina += m_SubOrPlusStamina * Time.deltaTime;
                    break;
            }
            //
            // if (m_StaminaPoint <= 0 && !m_NowExhausted)
            // {
            //     m_NowExhausted = true;
            //     m_State.StateChange(m_ArrState[(int)EPlayerState.EXHAUSTED]);
            // }
        }
    }
}