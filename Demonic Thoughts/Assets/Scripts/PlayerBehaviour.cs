using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(CharacterLocomotion))]
public class PlayerBehaviour : MonoBehaviour
{

    CharacterLocomotion m_Locomotion;
    InputSystem_Actions m_Input;
    

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
}

