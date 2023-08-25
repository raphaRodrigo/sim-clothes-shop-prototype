using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI nameTMP, priceTMP;
    [SerializeField] private Image icon;

    private int price;
    private ShopInteractableSO _shopSO;
    private InventorySO _inventorySO;
    private ItemSO _itemSO;
    private GameObject playerGameObject;


    private void SetUpButtonListener() {
        if (_shopSO.Contains(_itemSO))
            button.onClick.AddListener(BuyItem);
        else if (_inventorySO.Contains(_itemSO))
            button.onClick.AddListener(SellItem);
        else if (!_shopSO)
            button.onClick.AddListener(() => _itemSO.PerformAction(gameObject));
    }

    private void OnDestroy() {
        button.onClick.RemoveListener(BuyItem);
        button.onClick.RemoveListener(SellItem);
        button.onClick.RemoveListener(() => _itemSO.PerformAction(gameObject));
    }

    public void Initialize(ItemSO itemSO, ShopInteractableSO shopInteractable, GameObject gameObject) {
        playerGameObject = gameObject;
        _shopSO = shopInteractable;
        _inventorySO = playerGameObject.GetComponent<InventoryManager>().InventorySO;
        _itemSO = itemSO;
        price = itemSO.Price;
        priceTMP.text = "$ " + price.ToString();
        nameTMP.text = itemSO.Name;
        icon.sprite = itemSO.Icon;
        SetUpButtonListener();
    }

    public void BuyItem() {
        _inventorySO.AddItem(_itemSO);
        _shopSO.RemoveItem(_itemSO);
        _shopSO.Interact(playerGameObject);
    }

    public void SellItem() {
        _shopSO.AddItem(_itemSO);
        _inventorySO.RemoveItem(_itemSO);
        _shopSO.Interact(playerGameObject);
    }
}
