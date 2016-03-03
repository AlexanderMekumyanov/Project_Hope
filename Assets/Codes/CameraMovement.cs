using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private Camera m_Camera;
    private Transform m_Transform;

    [SerializeField]
    private Transform m_PlayerTransform = null;

    [SerializeField]
    private float dampTime = 0.5f;

    private void Awake()
    {
        m_Camera = GetComponent<Camera>();

        m_Transform = transform;
    }

    private void Update()
    {
        if (m_PlayerTransform)
        {
            m_Transform.position = Vector3.SmoothDamp(m_Transform.position, m_PlayerTransform.position, ref velocity, dampTime * Time.deltaTime);
            m_Transform.position = new Vector3(m_Transform.position.x, m_Transform.position.y, -10);
        }
    }
}