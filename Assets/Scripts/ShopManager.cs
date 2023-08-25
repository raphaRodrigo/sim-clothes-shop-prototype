using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {

    [SerializeField] private GameObject panel;
    [SerializeField] private Transform storeItemsParent, inventoryItemsParent;
    [SerializeField] private ShopInteractableSO shopInteractable;

    private List<Item> items = new();


    private void Awake() {
        shopInteractable.OnInteracted += OnInteracted;
    }
    private void OnDestroy() {
        shopInteractable.OnInteracted -= OnInteracted;
    }

    private void OnInteracted(GameObject gameObject) {
        ResetStore();
        LoadStore(gameObject);
        LoadInventory(gameObject);
        panel.SetActive(true);
    }

    private void ResetStore() {
        for (int i = 0; i < items.Count; i++) {
            Destroy(items[i].gameObject);
        }
        items.Clear();
    }

    private void LoadStore(GameObject gameObject) {
        List<ItemSO> itemSOs = shopInteractable.ItemSOs;
        for (int i = 0; i < itemSOs.Count; i++) {
            Item item = Instantiate(
                Resources.Load<Item>("Prefabs/Items/Item"), storeItemsParent
            );
            items.Add(item);
            item.Initialize(itemSOs[i], shopInteractable, gameObject);
        }
    }

    private void LoadInventory(GameObject gameObject) {
        List<ItemSO> itemSOs =
            gameObject.GetComponent<InventoryManager>().InventorySO.ItemSOs;
        for (int i = 0; i < itemSOs.Count; i++) {
            Item item = Instantiate(
                Resources.Load<Item>("Prefabs/Items/Item"), inventoryItemsParent
            );
            items.Add(item);
            item.Initialize(itemSOs[i], shopInteractable, gameObject);
        }
    }
}
