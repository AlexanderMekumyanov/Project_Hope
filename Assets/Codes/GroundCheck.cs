using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private Transform        m_Transform;
    private CircleCollider2D m_CircleCollider;

    [SerializeField]
    private LayerMask        m_Ground;

    public LayerMask ground
    {
        get { return m_Ground; }
    }

    public Vector2 position
    {
        get { return m_Transform.position; }
    }

    public float radius
    {
        get { return m_CircleCollider.radius; }
    }

    private void Awake()
    {
        m_Transform      = transform;
        m_CircleCollider = GetComponent<CircleCollider2D>();
    }
}