using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(CharacterLocomotion))]
public class PlayerBehaviour : MonoBehaviour
{

    CharacterLocomotion m_Locomotion;
    InputSystem_Actions m_Input;
    public BobbleHead m_BobbleHead;
    public SphereCollider m_HeadCollider;
    public Transform m_HeadModelTransform;
    SpringJoint m_SpringJoint;
    public Animator m_BodyAnimator;
    public Animator m_HeadAnimator;

    public float headRadius = 0.5f;
    public float headRadiusChangeRate = 0.05f;

    Vector2 m_MoveInput;

    public float moveSpeed = 5.0f;

    private void Awake()
    {
        m_Locomotion = GetComponent<CharacterLocomotion>();
        m_SpringJoint = GetComponent<SpringJoint>();
        m_Input = new InputSystem_Actions();
        m_Input.Enable();
    }

    private void FixedUpdate()
    {
        float diff = headRadius - m_HeadCollider.radius;
        m_HeadCollider.radius += Mathf.Min(Mathf.Abs(diff), Time.fixedDeltaTime * headRadiusChangeRate) * (diff > 0.0f ? 1.0f : -1.0f);
        float scale = m_HeadCollider.radius * 2.0f;
        m_HeadModelTransform.transform.localScale = new Vector3(scale, scale, scale);
        Vector3 acnh = m_SpringJoint.anchor;
        acnh.y = 0.8f + scale * 1.15f;
        m_SpringJoint.anchor = acnh;
    }

    void Update()
    {
        m_MoveInput = m_Input.Player.Move.ReadValue<Vector2>();
        m_Locomotion.groundMove = m_MoveInput * moveSpeed;
        m_BodyAnimator.SetBool("Running", m_MoveInput.magnitude > 0.01f);
    }

    public void AddGrowth(float amount)
    {
        headRadius = Mathf.Min(headRadius + amount * 0.3f, 2.0f);
        m_BodyAnimator.SetTrigger("Hit");
        m_HeadAnimator.SetTrigger("Hit");
    }
}

