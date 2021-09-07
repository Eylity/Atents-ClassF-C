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

        [HideInInspector] public CharacterController m_CharacterController;
        [HideInInspector] public bool m_ActiveFlyAttack = true;
        [HideInInspector] public bool m_ActiveFullSwing = true;
        [HideInInspector] public bool m_ActiveArea = true;
        [HideInInspector] public bool m_IsLive = true;
        [HideInInspector] public bool m_NowExhausted;

        private const float GRAVITY = 9.8f;

        [Header("----- Player Attack Collider -----")]
        [SerializeField] private BoxCollider m_AttackLeftCollider;
        public XWeaponTrail m_AttackLeftTrail;
        [SerializeField] private BoxCollider m_AttackRightCollider;
        public XWeaponTrail m_AttackRightTrail;

        [Header("----- Player Status -----")] 
        [SerializeField] private float m_HealthPoint;
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
            m_StateMachine.ONStateChanged += () => { Debug.Log("state changed: " + m_StateMachine.CurrentState); };

            Health = m_MaxHealthPoint;
            Stamina = m_MaxStaminaPoint;
        }

        private void Update()
        {
            m_CharacterController.Move(Vector3.down * (GRAVITY * Time.deltaTime));
            m_StateMachine.Update(Time.deltaTime);
            // StaminaChange();

            // Debug
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                TakeDamage(35f);
            }

           
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

            if (Health <= 0)
            {
                m_StateMachine.ChangeState<Player_DIe>();
            }
        }

        
        public void StaminaChange(bool isIdle)
        {
            switch (isIdle)
            {
                case true:
                    Stamina += m_SubOrPlusStamina * Time.deltaTime;
                    break;
                case false:
                    Stamina -= m_SubOrPlusStamina * Time.deltaTime;
                    break;
            }
            
            if (m_StaminaPoint <= 0 && !m_NowExhausted)
            {
                m_NowExhausted = true;
                m_StateMachine.ChangeState<Player_Exhausted>();
            }
        }
    }
}