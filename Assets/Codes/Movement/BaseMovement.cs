using UnityEngine;

namespace Movement
{
    public class BaseMovement : MonoBehaviour
    {
        public delegate void PlayActionAnimHandler(ObjectAnimations p_ObjectActions);
        public event PlayActionAnimHandler PlayActionAnimEvent;

        public delegate void PlayFloatAnimHandler(ObjectAnimations p_ObjectActions, float value);
        public event PlayFloatAnimHandler PlayFloatAnimEvent;

        public delegate void PlayBoolAnimHandler(ObjectAnimations p_ObjectActions, bool value);
        public event PlayBoolAnimHandler PlayBoolAnimEvent;

        private Transform   m_Transform;
        private Rigidbody2D m_RigidBody;
        private float       m_CurrentSpeed   = 0.0f;
        private bool        m_IsGrounded     = true;
        private bool        m_PrevIsGrounded = true;
        private Direction   m_Direction      = Direction.RIGHT;
        private float       m_SpeedCoeff = 0.0f;
        private ConstantForce2D m_ConstantForce = null;

        [SerializeField]
        private float m_Speed = 0.0f;

        [SerializeField]
        private Vector2 m_JumpForce = Vector2.zero;

        [SerializeField]
        private GroundCheck m_CheckGround = null;

        [SerializeField]
        private float m_JumpAirForce = 0.0f;

        protected virtual void Awake()
        {
            m_Transform = transform;
            m_RigidBody = GetComponent<Rigidbody2D>();
            m_ConstantForce = GetComponent<ConstantForce2D>();
        }

        public void Move(ObjectActions p_ObjectActions, float p_SpeedCoeff = 0.0f)
        {
            switch (p_ObjectActions)
            {
                case ObjectActions.GOING_LEFT:
                    m_CurrentSpeed = m_Speed;
                    m_Transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                    m_Direction = Direction.LEFT;
                    break;
                case ObjectActions.GOING_RIGHT:
                    m_CurrentSpeed = m_Speed;
                    m_Transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                    m_Direction = Direction.RIGHT;
                    break;
                case ObjectActions.STOP_RUN:
                    if (m_IsGrounded)
                    {
                        m_CurrentSpeed = 0.0f;
                    }
                    break;
                case ObjectActions.JUMP_START:
                    if (m_IsGrounded)
                    {
                        Jump();
                    }
                    break;
                case ObjectActions.JUMP_END:
                    if (!m_IsGrounded)
                    {
                        EndJump();
                    }
                    break;
            }
            m_SpeedCoeff = p_SpeedCoeff;
        }

        protected virtual void FixedUpdate()
        {
            m_IsGrounded = Physics2D.Linecast(m_Transform.position, m_CheckGround.position, 1 << LayerMask.NameToLayer("Ground"));

            if (m_IsGrounded == true && m_PrevIsGrounded == false)
            {
                Move(ObjectActions.STOP_RUN);
            }

            if (PlayBoolAnimEvent != null)
            {
                PlayBoolAnimEvent(ObjectAnimations.IDLE, m_IsGrounded);
            }

            if (m_IsGrounded)
            {
                m_RigidBody.velocity = new Vector2(m_CurrentSpeed * (int)m_Direction, m_RigidBody.velocity.y);
            }
            else
            {
                m_RigidBody.velocity = new Vector2(m_CurrentSpeed * m_SpeedCoeff, m_RigidBody.velocity.y);                
            }

            if (PlayFloatAnimEvent != null)
            {
                PlayFloatAnimEvent(ObjectAnimations.GOING, m_CurrentSpeed);
            }

            m_PrevIsGrounded = m_IsGrounded;
        }

        public void Jump()
        {
            m_RigidBody.AddForce(new Vector2(m_JumpForce.x, m_JumpForce.y));
            m_ConstantForce.force = new Vector2(m_ConstantForce.force.x, m_JumpAirForce);
            if (PlayActionAnimEvent != null)
            {
                PlayActionAnimEvent(ObjectAnimations.JUMPING);
            }
        }

        public void EndJump()
        {
            m_ConstantForce.force = new Vector2(m_ConstantForce.force.x, 0);
        }
    }
}