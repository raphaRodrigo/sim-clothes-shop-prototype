using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventorySO", menuName = "ScriptableObjects/InventorySO")]
public class InventorySO : ScriptableObject {

    [field: SerializeField] public List<ItemSO> ItemSOs { get; private set; }


    public void AddItem(ItemSO item) {
        ItemSOs.Add(item);
    }

    public void RemoveItem(ItemSO item) {
        ItemSOs.Remove(item);
    }

    public bool Contains(ItemSO item) {
        return ItemSOs.Contains(item);
    }
}
