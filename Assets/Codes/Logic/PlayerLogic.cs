using UnityEngine;

using Movement;
using Animations;

namespace Logic
{
    public class PlayerLogic : MonoBehaviour
    {
        private BaseAnimation m_BaseAnimation = null;
        private BaseInput     m_BaseInput = null;
        private BaseMovement  m_BaseMovement = null;

        public BaseAnimation baseAnimation
        {
            get { return m_BaseAnimation; }
        }

        public BaseMovement baseMovement
        {
            get { return m_BaseMovement; }
        }

        public BaseInput baseInput
        {
            get { return m_BaseInput; }
        }

        protected virtual void Awake()
        {
            m_BaseAnimation = GetComponent<BaseAnimation>();
            m_BaseInput     = GetComponent<BaseInput>();
            m_BaseMovement  = GetComponent<BaseMovement>();

            m_BaseInput.MoveEvent += m_BaseMovement.Move;
            m_BaseMovement.PlayFloatAnimEvent  += m_BaseAnimation.PlayAnimation;
            m_BaseMovement.PlayActionAnimEvent += m_BaseAnimation.PlayAnimation;
            m_BaseMovement.PlayBoolAnimEvent   += m_BaseAnimation.PlayAnimation;
        }

        public void CannotMove()
        {
            m_BaseInput.MoveEvent -= m_BaseMovement.Move;
            m_BaseMovement.Move(ObjectActions.STOP_RUN);
        }
    }
}
