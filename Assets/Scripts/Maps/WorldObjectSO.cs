using UnityEngine;

[CreateAssetMenu(fileName = "NewWorldObject", menuName = "Create/WorldObject")]
public class WorldObjectSO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private TileActionType[] _actions;

    public string Name => _name;
    public Sprite Sprite => _sprite;
    public TileActionType[] Actions => _actions;
}
