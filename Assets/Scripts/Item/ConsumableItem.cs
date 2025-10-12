using UnityEngine;

[CreateAssetMenu(menuName = "Items/Consumable")]
public class ConsumableItem : ItemDefinition
{
    [Header("Consumable Data")]
    public int HealthRestore;
    public int ManaRestore;
    public float BuffStaminaDuration;
}
