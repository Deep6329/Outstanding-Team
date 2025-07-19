using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterLocomotion : MonoBehaviour
{

    Rigidbody m_Rigidbody;
    public Rigidbody m_SecondaryTarget;

    public Vector2 groundMove;
    public float moveSharpness = 2.0f;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 vel = m_Rigidbody.linearVelocity;
        Vector3 oldVel = vel;
        Vector2 velGround = new Vector2(vel.x, vel.z);
        velGround = Vector2.MoveTowards(velGround, groundMove, moveSharpness * Time.fixedDeltaTime);
        vel.x = velGround.x;
        vel.z = velGround.y;
        m_Rigidbody.linearVelocity = vel;
        if(m_SecondaryTarget != null)
        {
            m_SecondaryTarget.linearVelocity += vel - oldVel;
        }
    }



    void Update()
    {

    }


}
