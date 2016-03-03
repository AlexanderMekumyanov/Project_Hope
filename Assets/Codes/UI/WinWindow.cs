using System;
using UnityEngine;

public enum ButtonType
{
    RESTART,
    QUIT
}

public class WinWindow : MonoBehaviour
{
    private Animator m_Animator = null;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }

    public void Restart()
    {
        Application.LoadLevel("TestScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Show()
    {
        m_Animator.SetTrigger("SHOW");
    }
}
