using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TreasureSearchController : MonoBehaviour
{
    [SerializeField] private Inventory _playerInventory;

    [Header("UI Elements")]
    [SerializeField] private RawImage _maskImage;
    [SerializeField] private int _texWidth = 512;
    [SerializeField] private int _texHeight = 512;
    [SerializeField] private RectTransform _itemsParent;
    [SerializeField] private TextMeshProUGUI _attemptsText;
    [SerializeField] private Button _finishButton;

    [Header("Brush Settings")]
    [SerializeField] private Texture2D _brushTexture;
    [SerializeField] private int _brushSize = 64;
    [SerializeField] private int _attempts = 10;
    [SerializeField] private Camera _uiCamera;

    private Texture2D _maskTexture;
    private RectTransform _maskRect;

    private bool _isActive = false;
    private int _attemptsLeft;

    private void Awake()
    {
        _maskRect = _maskImage.GetComponent<RectTransform>();
        _finishButton.onClick.AddListener(OnFinish);
    }

    private void OnEnable()
    {
        InitializeMask();
        _attemptsLeft = _attempts;
        _attemptsText.text = $"Попыток: {_attemptsLeft}";
        _isActive = true;
    }

    private void InitializeMask()
    {
        _maskTexture = new Texture2D(_texWidth, _texHeight, TextureFormat.RGBA32, false);
        var pixels = new Color32[_texWidth * _texHeight];

        for (int i = 0; i < pixels.Length; i++)
            pixels[i] = new Color32(0, 0, 0, 255);

        _maskTexture.SetPixels32(pixels);
        _maskTexture.Apply();

        _maskImage.texture = _maskTexture;
        Debug.Log("Mask texture created and assigned: " + _maskImage.texture);
    }

    private void Update()
    {
        if (!_isActive) return;
        if (_attemptsLeft <= 0) return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 localPoint;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_maskRect, Input.mousePosition, _uiCamera, out localPoint))
            {
                int px = Mathf.RoundToInt((localPoint.x + _maskRect.rect.width / 2) / _maskRect.rect.width * _texWidth);
                int py = Mathf.RoundToInt((localPoint.y + _maskRect.rect.height / 2) / _maskRect.rect.height * _texHeight);
                EraseCircle(px, py);

                _attemptsLeft--;
                _attemptsText.text = $"Попыток: {_attemptsLeft}";

                if (_attemptsLeft <= 0)
                    _isActive = false;
            }
        }
    }

    private void EraseCircle(int cx, int cy)
    {
        int radius = _brushSize / 2;

        for (int x = -radius; x < radius; x++)
        {
            for (int y = -radius; y < radius; y++)
            {
                int px = cx + x;
                int py = cy + y;

                if (px < 0 || py < 0 || px >= _texWidth || py >= _texHeight)
                    continue;

                float dist = Mathf.Sqrt(x * x + y * y);

                if (dist > radius)
                    continue;

                Color color = _maskTexture.GetPixel(px, py);
                color.a = Mathf.Max(0, color.a - 0.5f); // частично стираем
                _maskTexture.SetPixel(px, py, color);
            }
        }

        _maskTexture.Apply();
    }

    private void OnFinish()
    {
        _isActive = false;

        var foundItems = new List<TreasureItemUI>();  // Можно собрать все предметы, которые были "найдены"

        foreach (Transform child in _itemsParent)
        {
            var item = child.GetComponent<TreasureItemUI>();
            if (item != null)
            {
                item.isFound = true;
                foundItems.Add(item);
            }
        }

        Debug.Log($"Собрано {foundItems.Count} предметов");

        gameObject.SetActive(false);
    }
}
