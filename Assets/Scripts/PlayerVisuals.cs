using UnityEngine;

public class PlayerVisuals : MonoBehaviour {

    [field: SerializeField] public LayeredRenderer BaseRenderer { get; private set; }
    [field: SerializeField] public LayeredRenderer OutfitRenderer { get; private set; }
    [field: SerializeField] public LayeredRenderer HairRenderer { get; private set; }
    [field: SerializeField] public LayeredRenderer HatRenderer { get; private set; }
}

