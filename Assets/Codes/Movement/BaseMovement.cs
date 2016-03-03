using UnityEngine;

namespace Movement
{
    public class BaseMovement : MonoBehaviour
    {
        public delegate void PlayActionAnimHandler(ObjectActions p_ObjectActions);
        public event PlayActionAnimHandler PlayActionAnimEvent;

        public delegate void PlayFloatAnimHandler(ObjectActions p_ObjectActions, float value);
        public event PlayFloatAnimHandler PlayFloatAnimEvent;

        public delegate void PlayBoolAnimHandler(ObjectActions p_ObjectActions, bool value);
        public event PlayBoolAnimHandler PlayBoolAnimEvent;

        private Transform   m_Transform;
        private Rigidbody2D m_RigidBody;
        private float       m_CurrentSpeed = 0.0f;
        private bool        m_IsGrounded = true;
        private Direction   m_Direction = Direction.RIGHT;

        [SerializeField]
        private float m_Speed = 0.0f;

        [SerializeField]
        private Vector2 m_JumpForce = Vector2.zero;

        [SerializeField]
        private GroundCheck m_CheckGround = null;

        protected virtual void Awake()
        {
            m_Transform = transform;
            m_RigidBody = GetComponent<Rigidbody2D>();
        }

        public void Move(ObjectActions p_ObjectActions)
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
                    m_CurrentSpeed = 0.0f;
                    break;
                case ObjectActions.JUMP:
                    if (m_IsGrounded)
                    {
                        Jump();
                    }
                    break;
            }
        }

        protected virtual void FixedUpdate()
        {
            m_IsGrounded = Physics2D.OverlapCircle(m_CheckGround.position, m_CheckGround.radius, m_CheckGround.ground);

            if (PlayBoolAnimEvent != null)
            {
                PlayBoolAnimEvent(ObjectActions.GROUNDED, m_IsGrounded);
            }

            if (m_IsGrounded)
            {
                m_RigidBody.velocity = new Vector2(m_CurrentSpeed * (int)m_Direction, m_RigidBody.velocity.y);
            }

            if (PlayFloatAnimEvent != null)
            {
                PlayFloatAnimEvent(ObjectActions.GOING, m_CurrentSpeed);
            }
        }

        public void Jump()
        {
            m_RigidBody.AddForce(new Vector2(m_JumpForce.x, m_JumpForce.y));

            if (PlayActionAnimEvent != null)
            {
                PlayActionAnimEvent(ObjectActions.JUMP);
            }
        }
    }
}