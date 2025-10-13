using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   /* [SerializeField]*/ private List<Item> _items = new List<Item>();

    public IReadOnlyList<Item> Items => _items;

    private float _maxWeight;
    private bool _IsMaxWeight;
    private int _itemCount;


    public event Action<bool> IsMaxWeightChanged;// Это передача в PlayerMover Для заторможенного движения

    public void AddItem(ItemDefinition itemDefinition, int amount = 1)
    {
        if (itemDefinition.Stackable)
        {
            Item existing = _items.FirstOrDefault(i => i.ItemDefinition == itemDefinition);

            if (existing != null)
            {
                existing.Quantity += amount;
                return;
            }
        }

        _items.Add(new Item(itemDefinition,amount));
    }


    public void RemoveItem(ItemDefinition itemDefinition, int amount = 1)
    {
        var item = _items.FirstOrDefault(i => i.ItemDefinition == itemDefinition);

        if (item == null)
            return;

        item.Quantity -= amount;

        if (item.Quantity <= 0)
            _items.Remove(item);
    }

    public void Clear() => _items.Clear();



    public void SetCurrentWeight(float currentWeight)
    {
        // здесь прописываем общий вес и устанавливаем его на старте игры
        // Возможно меняем через Update.У персонажа есть вес поднятия предметов без рюкзака
        // есть разные рюкзаки, которые мы можем одеть и вес измениться 
    }
}
