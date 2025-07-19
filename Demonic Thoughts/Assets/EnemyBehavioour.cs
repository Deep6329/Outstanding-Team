using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterLocomotion))]
public class EnemyBehavioour : MonoBehaviour
{

    CharacterLocomotion m_Locomotion;
    public Transform m_Target;

    public bool isAsleep = false;
    public float moveSpeed = 1.0f;
    public float targettingRadius = 10.0f;

    private void Awake()
    {
        m_Locomotion = GetComponent<CharacterLocomotion>();
    }

    void FixedUpdate()
    {
        if (isAsleep)
        {
            m_Locomotion.groundMove.Set(0, 0);
            return;
        }
        if (m_Target != null)
        {
            Vector3 tPos = m_Target.position;
            Vector3 cPos = transform.position;
            if (Vector3.Distance(tPos, cPos) < targettingRadius)
            {
                Vector2 diff = new Vector2(tPos.x - cPos.x, tPos.z - cPos.z);
                diff.Normalize();
                m_Locomotion.groundMove = diff * moveSpeed;
            }else
            {
                m_Locomotion.groundMove = Vector3.zero;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, targettingRadius);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour player))
        {
            player.AddGrowth(1.0f);
            Destroy(this);
        }
    }

}

