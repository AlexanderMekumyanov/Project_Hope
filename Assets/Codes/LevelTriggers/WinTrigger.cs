using UnityEngine;

using Logic;
using UI;

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

        ScreenSystem.instance.Interactive(true);        
        m_WinWindow.Show();
    }
}
