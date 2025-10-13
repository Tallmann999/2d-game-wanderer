using System;
using UnityEngine;
using UnityEngine.WSA;

public class InteractionDetector : MonoBehaviour
{
    [SerializeField] private TilemapReader _tilemapReader;
    [SerializeField] private TileActionUI _tileActionUI;
    [SerializeField] private GameObject _inventoryWindow;

    private void Awake()
    {
        _inventoryWindow.SetActive(false);
    }

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

        if (Input.GetKeyDown(KeyCode.I))
        {
            _inventoryWindow.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            _inventoryWindow.SetActive(false);

        }
    }
}

