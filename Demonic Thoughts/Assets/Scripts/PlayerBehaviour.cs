using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(CharacterLocomotion))]
public class PlayerBehaviour : MonoBehaviour
{

    CharacterLocomotion m_Locomotion;
    InputSystem_Actions m_Input;
    public BobbleHead m_BobbleHead;
    

    Vector2 m_MoveInput;

    public float moveSpeed = 5.0f;

    private void Awake()
    {
        m_Locomotion = GetComponent<CharacterLocomotion>();
        m_Input = new InputSystem_Actions();
        m_Input.Enable();

        m_Input.Player.Move.performed += OnInputMove;
    }

    void Update()
    {
        m_MoveInput = m_Input.Player.Move.ReadValue<Vector2>();
        m_Locomotion.groundMove = m_MoveInput * moveSpeed;

    }

    void OnInputMove(InputAction.CallbackContext ctx)
    {
        
    }

    public void AddGrowth(float amount)
    {
        m_BobbleHead.radius = Mathf.Min(m_BobbleHead.radius + amount * 0.15f, 2.0f);
    }
}

