using UnityEngine;

public class BaseInput : MonoBehaviour
{
    public delegate void MoveEventHandler(ObjectActions p_MovementDirection);
    public event MoveEventHandler MoveEvent;

    protected virtual void Awake()
    {

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (MoveEvent != null)
            {
                MoveEvent(ObjectActions.GOING_LEFT);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (MoveEvent != null)
            {
                MoveEvent(ObjectActions.GOING_RIGHT);
            }
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            if (MoveEvent != null)
            {
                MoveEvent(ObjectActions.STOP_RUN);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (MoveEvent != null)
            {
                MoveEvent(ObjectActions.JUMP);
            }
        }
    }
}
