using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopInteractableSO", menuName = "ScriptableObjects/ShopInteractableSO")]
public class ShopInteractableSO : InteractableSO {

    [field: SerializeField] public List<ItemSO> ItemSOs { get; private set; }

    private event Action<GameObject> onInteracted;

    public event Action<GameObject> OnInteracted {
        add { onInteracted += value; }
        remove { onInteracted -= value; }
    }

    public void AddItem(ItemSO item) {
        ItemSOs.Add(item);
    }

    public void RemoveItem(ItemSO item) {
        ItemSOs.Remove(item);
    }

    public bool Contains(ItemSO item) {
        return ItemSOs.Contains(item);
    }

    public override void Interact(GameObject gameObject) {
        onInteracted?.Invoke(gameObject);
    }
}
