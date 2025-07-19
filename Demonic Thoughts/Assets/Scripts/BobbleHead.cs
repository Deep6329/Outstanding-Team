using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class BobbleHead : MonoBehaviour
{
    public float radius = 0.5f;
    public float radiusChangeSpeed = 0.05f;
    public Transform m_ModelObject;
    SphereCollider m_Collider;
    Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Collider = GetComponent<SphereCollider>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float diff = radius - m_Collider.radius;
        m_Collider.radius += Mathf.Min(Mathf.Abs(diff), Time.fixedDeltaTime * radiusChangeSpeed) * (diff > 0.0f ? 1.0f : -1.0f);
        float scale = m_Collider.radius * 2.0f;
        m_ModelObject.transform.localScale = new Vector3(scale, scale, scale);
    }
}
