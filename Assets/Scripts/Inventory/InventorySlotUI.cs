using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _quantityText;

    public void Set(Item item)
    {
        _icon.sprite = item.Icon;
        _quantityText.text = item.ItemDefinition.Stackable ? item.Quantity.ToString() : "";
    }
}
