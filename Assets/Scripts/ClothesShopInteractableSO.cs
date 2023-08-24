using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ClothesShopInteractableSO", menuName = "ScriptableObjects/ClothesShopInteractableSO")]
public class ClothesShopInteractableSO : InteractableSO {

    private event Action onInteracted;

    public event Action OnInteracted {
        add { onInteracted += value; }
        remove { onInteracted -= value; }
    }

    public override void Interact() => onInteracted();
}
