using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapReader : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private TileDataSO[] _tileDataList;

    private Dictionary<Sprite, TileDataSO> _spriteToData;

    private void Awake()
    {
        _spriteToData = new Dictionary<Sprite, TileDataSO>();
        foreach (var data in _tileDataList)
        {
            if (data == null || data.Sprites == null) continue;
            foreach (var sp in data.Sprites)
            {
                if (sp == null) continue;
                if (!_spriteToData.ContainsKey(sp))
                    _spriteToData[sp] = data; // первый встретившийся wins
            }
        }
    }

    public TileDataSO GetCurrentTile(Vector3 worldPos)
    {
        Vector3Int cellPos = _tilemap.WorldToCell(worldPos);
        TileBase tile = _tilemap.GetTile(cellPos);
        if (tile == null) return null;

        Sprite tileSprite = (tile as Tile)?.sprite;
        if (tileSprite == null) return null;

        _spriteToData.TryGetValue(tileSprite, out var data);
        return data;
    }

    public TileEntity GetTileEntity(Vector3 worldPosition)
    {
        Vector3Int gridPosition = _tilemap.WorldToCell(worldPosition);
        Vector3 centerPosition = _tilemap.GetCellCenterWorld(gridPosition);

        // ищем объект на этом тайле (лучше через Physics2D.OverlapCircle)
        Collider2D[] colliderSeach = Physics2D.OverlapCircleAll(centerPosition, 0.5f);

        foreach (var colliderSeac in colliderSeach)
        {
            if (colliderSeac.TryGetComponent(out TileEntity entity))
                return entity;
        }
        return null;
    }
}
