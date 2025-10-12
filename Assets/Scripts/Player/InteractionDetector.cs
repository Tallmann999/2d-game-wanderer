using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;

public class InteractionDetector : MonoBehaviour
{
    [SerializeField] private TilemapReader _tilemapReader;
    [SerializeField] private TileActionUI _tileActionUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // взаимодействие
        {
            TileDataSO tileData = _tilemapReader.GetCurrentTile(transform.position);
            TileEntity tileEntity = _tilemapReader.GetTileEntity(transform.position);

            _tileActionUI.ShowActions(tileData, tileEntity);

            if (tileData == null)
                return;
        }
    }
}   

