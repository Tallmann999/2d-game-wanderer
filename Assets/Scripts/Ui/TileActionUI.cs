using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TileActionUI : MonoBehaviour
{
    [SerializeField] private GameObject _buttonPrefab;   // ������ ������
    [SerializeField] private Transform _buttonContainer; // ���� ������� ������
    [SerializeField] private UIManager _uiManager;

    private List<GameObject> _spawnedButtons = new();

    public void ShowActions(TileDataSO tileData, TileEntity tileEntity)
    {
        // 
        // ������� ������
        foreach (var spawnedButton in _spawnedButtons)
            Destroy(spawnedButton);

        _spawnedButtons.Clear();

        if (tileData != null)
        {
            foreach (var action in tileData.Actions)
                CreateButton(action);
        }

        if (tileEntity != null && tileEntity.WorldObject != null)
        {
            foreach (var action in tileEntity.WorldObject.Actions)
                CreateButton(action);
        }
    }

    private void CreateButton(TileActionType action)
    {
        GameObject newButton = Instantiate(_buttonPrefab, _buttonContainer);
        _spawnedButtons.Add(newButton);

        var button = newButton.GetComponent<Button>();
        var text = newButton.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        text.text = action.ToString();

        button.onClick.AddListener(() =>
        {
            _uiManager.OpenActionWindow(action);
        });
    }

}
