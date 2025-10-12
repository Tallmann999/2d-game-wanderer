using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TileData", menuName = "Game/Tile Data")]
public class TileDataSO : ScriptableObject
{
    [Header("Базовая информация")]
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private BiomType _type;

    [Header("Список Активностей")]
    [SerializeField] private List<TileActionType> _actions;

    public List<Sprite> Sprites => _sprites;
    public BiomType Type => _type;
    public IReadOnlyList<TileActionType> Actions => _actions;
}
