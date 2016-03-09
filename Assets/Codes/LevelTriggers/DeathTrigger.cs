using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Application.LoadLevel("TestScene");
    }
}
