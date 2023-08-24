using UnityEngine;

public class PlayerCharacterController : MonoBehaviour {

    private PlayerInputActions playerInputActions;

    private PlayerInputActions.PlayerActions PlayerActions => playerInputActions.Player;


    private void Awake() {
        playerInputActions = new();
        PlayerActions.Enable();
    }

    private void OnDisable() {
        PlayerActions.Disable();
    }

    private void FixedUpdate() {
        transform.position += (Vector3)PlayerActions.Move.ReadValue<Vector2>() * .025f;
    }
}
