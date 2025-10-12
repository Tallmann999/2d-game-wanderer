using UnityEngine;

public abstract class ItemDefinition : ScriptableObject
{
    [Header("Base Info")]
    public string Id;              // Уникальный идентификатор
    public string ItemName;        // Название
    public Sprite Icon;            // Иконка
    public ItemType Type;          // Тип предмета
    public Rarity Rarity;          // Редкость
    public bool Stackable;        
    public int MaxStack = 1;      
    public int Price;
    public float Weight;
}
