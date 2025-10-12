using UnityEngine;

public abstract class ItemDefinition : ScriptableObject
{
    [Header("Base Info")]
    public string Id;              // ���������� �������������
    public string ItemName;        // ��������
    public Sprite Icon;            // ������
    public ItemType Type;          // ��� ��������
    public Rarity Rarity;          // ��������
    public bool Stackable;        
    public int MaxStack = 1;      
    public int Price;
    public float Weight;
}
