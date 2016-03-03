using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Application.LoadLevel("TestScene");
    }
}
