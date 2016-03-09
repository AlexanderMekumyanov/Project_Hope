using UnityEngine;

namespace Animations
{
    public class BaseAnimation : MonoBehaviour
    {
        private Animator m_Animator = null;

        protected virtual void Awake()
        {
            m_Animator = GetComponentInChildren<Animator>();
        }

        public void PlayAnimation(ObjectAnimations p_ObjectActions)
        {
            m_Animator.SetTrigger(p_ObjectActions.ToString());
        }

        public void PlayAnimation(ObjectAnimations p_ObjectActions, float p_Value)
        {
            m_Animator.SetFloat(p_ObjectActions.ToString(), p_Value);
        }

        public void PlayAnimation(ObjectAnimations p_ObjectActions, bool p_Value)
        {
            m_Animator.SetBool(p_ObjectActions.ToString(), p_Value);
        }
    }
}
