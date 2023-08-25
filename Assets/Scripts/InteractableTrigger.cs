using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class InteractableTrigger : MonoBehaviour, IInteractable {

    [SerializeField] private InteractableSO interactableSO;

    public void Interact(GameObject gameObject) {
        interactableSO.Interact(gameObject);
    }
}
