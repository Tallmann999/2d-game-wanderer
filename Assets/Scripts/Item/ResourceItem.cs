using UnityEngine;

[CreateAssetMenu(menuName = "Items/Resource")]
public class ResourceItem : ItemDefinition
{
    [Header("Resource Data")]
    public string ResourceType;   // Например "Wood", "Iron", "Skin"
}