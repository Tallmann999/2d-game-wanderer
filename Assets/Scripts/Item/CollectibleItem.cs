using UnityEngine;

[CreateAssetMenu(menuName = "Items/Collectible")]
public class CollectibleItem : ItemDefinition
{
    [Header("Collectible Data")]
    public string CollectionName;  // Например "Set of Ancient Coins"
}