using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : MonoBehaviour {

    [SerializeField] private new Rigidbody2D rigidbody2D;
    [SerializeField] private Animator animator;

    private PlayerInputActions playerInputActions;
    private int moveXHash, moveYHash, isMovingHash;

    private PlayerInputActions.PlayerActions PlayerActions {
        get => playerInputActions.Player;
    }

    private Vector2 Velocity {
        get => rigidbody2D.velocity;
        set => rigidbody2D.velocity = value;
    }

    private void Awake() {
        moveXHash = Animator.StringToHash("MoveSpeedX");
        moveYHash = Animator.StringToHash("MoveSpeedY");
        isMovingHash = Animator.StringToHash("IsMoving");

        playerInputActions = new();

        PlayerActions.Enable();
        PlayerActions.Move.started += Move_started;
        PlayerActions.Move.canceled += Move_canceled;
        PlayerActions.Interact.started += InteractStarted;
    }

    private void InteractStarted(InputAction.CallbackContext obj) {
        Collider2D[] hits = Physics2D.OverlapPointAll(transform.position);
        for (int i = 0; i < hits.Length; i++)
            if (hits[i].TryGetComponent(out IInteractable interactable)) {
                interactable.Interact(gameObject);
                break;
            }
    }

    private void Move_started(InputAction.CallbackContext obj) {
        enabled = true;
        animator.SetBool(isMovingHash, true);
    }

    private void Move_canceled(InputAction.CallbackContext obj) {
        enabled = false;
        Velocity = Vector2.zero;
        animator.SetBool(isMovingHash, false);
    }

    private void OnDestroy() {
        PlayerActions.Move.started -= Move_started;
        PlayerActions.Move.canceled -= Move_canceled;
        PlayerActions.Interact.started -= InteractStarted;
        PlayerActions.Disable();
    }

    private void FixedUpdate() {
        Velocity = (Vector3)PlayerActions.Move.ReadValue<Vector2>();
        animator.SetFloat(moveXHash, Velocity.x);
        animator.SetFloat(moveYHash, Velocity.y);
    }
}
