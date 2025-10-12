using UnityEngine;

public class TileEntity : MonoBehaviour
{
    [SerializeField] private WorldObjectSO _worldObject;

    public WorldObjectSO WorldObject => _worldObject;
}
