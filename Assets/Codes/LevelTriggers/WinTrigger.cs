using UnityEngine;

using Logic;

public class WinTrigger : MonoBehaviour
{
    private Animator m_Animator;

    [SerializeField]
    private PlayerLogic m_PlayerLogic = null;

    [SerializeField]
    private WinWindow m_WinWindow = null;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }

    public void Win()
    {
        m_Animator.SetTrigger("WIN");
        m_PlayerLogic.CannotMove();

        m_WinWindow.gameObject.SetActive(true);
        m_WinWindow.Show();
    }
}
