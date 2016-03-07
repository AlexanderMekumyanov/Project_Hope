using UnityEngine;

namespace UI
{
    public class ScreenSystem : MonoBehaviour
    {
        private CanvasGroup m_CanvasGroup = null;

        private static ScreenSystem m_Instance;

        public void Awake()
        {
            m_Instance = this;
            m_CanvasGroup = GetComponent<CanvasGroup>();
        }

        public static ScreenSystem instance
        {
            get { return m_Instance; }
        }

        public void Interactive(bool m_Flag)
        {
            m_CanvasGroup.interactable = m_Flag;
        }
    }
}
