using UnityEngine;

public class BaseInput : MonoBehaviour
{
    public delegate void MoveEventHandler(ObjectActions p_MovementDirection, float p_SpeedCoeff);
    public event MoveEventHandler MoveEvent;

    private float m_SpeedCoef = 0.0f;

    protected virtual void Awake()
    {

    }

    private void Update()
    {
        m_SpeedCoef = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.A))
        {
            if (MoveEvent != null)
            {
                MoveEvent(ObjectActions.GOING_LEFT, m_SpeedCoef);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (MoveEvent != null)
            {
                MoveEvent(ObjectActions.GOING_RIGHT, m_SpeedCoef);
            }
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            if (MoveEvent != null)
            {
                MoveEvent(ObjectActions.STOP_RUN, m_SpeedCoef);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (MoveEvent != null)
            {
                MoveEvent(ObjectActions.JUMP_START, m_SpeedCoef);
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (MoveEvent != null)
            {
                MoveEvent(ObjectActions.JUMP_END, m_SpeedCoef);
            }
        }
    }
}
