using UnityEngine;
using System.Collections;

public class CheckCollide : MonoBehaviour
{
    [SerializeField]
    private string m_Tag;

    public void OnTriggerEnter2D(Collider2D p_Collision)
    {
        transform.parent.gameObject.GetComponent<WinTrigger>().Win();
    }
}
