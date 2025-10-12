using UnityEngine;

[CreateAssetMenu(menuName = "Items/Equipment")]
public class EquipmentItem : ItemDefinition
{
    [Header("Equipment Data")]
    public EquipmentSlotType Slot;    // Слот, куда надевается
    public int Attack;
    public int Defense;
    public float AttackSpeed;
}