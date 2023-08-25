using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    [SerializeField] private Transform inventoryItemsParent;

    [field: SerializeField] public InventorySO InventorySO { get; private set; }

    private List<Item> items = new();

    public void OpenInventory() {
        ResetStore();
        LoadInventory();
    }

    private void ResetStore() {
        for (int i = 0; i < items.Count; i++) {
            Destroy(items[i].gameObject);
        }
        items.Clear();
    }

    private void LoadInventory() {
        List<ItemSO> itemSOs = InventorySO.ItemSOs;
        for (int i = 0; i < itemSOs.Count; i++) {
            Item item = Instantiate(
                Resources.Load<Item>("Prefabs/Items/Item"), inventoryItemsParent
            );
            items.Add(item);
            item.Initialize(itemSOs[i], null, gameObject);
        }
    }
}
