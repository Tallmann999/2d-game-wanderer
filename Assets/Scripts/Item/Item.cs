using UnityEngine;

[System.Serializable]
public class Item
{
   public ItemDefinition ItemDefinition;
    public int Quantity;

    public Item(ItemDefinition itemDefinition, int quantity = 1)
    {
        ItemDefinition = itemDefinition;
        Quantity = quantity;
    }

    public string Name => ItemDefinition.ItemName;
    public Sprite Icon => ItemDefinition.Icon;
    public bool Stackable => ItemDefinition.Stackable;
}
