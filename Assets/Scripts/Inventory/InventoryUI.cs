using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Transform _slotsParent;
    [SerializeField] private GameObject _slotPrefab;


    private void OnEnable()
    {
        Refresh();
    }

    public void Refresh()
    {
        foreach (Transform child in _slotsParent)
            Destroy(child.gameObject);

        foreach (var item in _inventory.Items)
        {
            var slot = Instantiate(_slotPrefab, _slotsParent);
            var ui = slot.GetComponent<InventorySlotUI>();
            ui.Set(item);
        }
    }
 
}
