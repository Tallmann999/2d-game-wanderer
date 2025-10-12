using UnityEngine;

[CreateAssetMenu(menuName = "Items/Equipment")]
public class EquipmentItem : ItemDefinition
{
    [Header("Equipment Data")]
    public EquipmentSlotType Slot;    // ����, ���� ����������
    public int Attack;
    public int Defense;
    public float AttackSpeed;
}