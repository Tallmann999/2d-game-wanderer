using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _fishingWindow;
    [SerializeField] private GameObject _treasureSearchtrieWindow;
    [SerializeField] private GameObject _huntingWindow;
    [SerializeField] private GameObject _miningWindow;
    [SerializeField] private PlayerController _player;

    private GameObject _currentWindow;

    public void OpenActionWindow(TileActionType action)
    {
        CloseAllWindows();
        // «десь можно оптимизировать.—делать список окон и  сделать к каждому окну определенный тип де€тельности
        // Enum ActionWindowType а потом методом переборов показать то окно которое совпадает с событием вызова
        switch (action)
        {
            case TileActionType.Fish:
                _fishingWindow.SetActive(true);
                _currentWindow = _fishingWindow;
                break;
            case TileActionType.TreasureSearchtrie:
                _treasureSearchtrieWindow.SetActive(true);
                _currentWindow = _treasureSearchtrieWindow;
                break;
            case TileActionType.Hunt:
                _huntingWindow.SetActive(true);
                _currentWindow = _huntingWindow;
                break;
            case TileActionType.CollectResources:
                _miningWindow.SetActive(true);
                _currentWindow = _miningWindow;
                break;
        }

        _player.SetState(PlayerState.Interaction);
    }

    public void CloseAllWindows()
    {
        _fishingWindow.SetActive(false);
        _huntingWindow.SetActive(false);
        _miningWindow.SetActive(false);
        _treasureSearchtrieWindow.SetActive(false);
        _currentWindow = null;

        _player.SetState(PlayerState.Exploration);
    }

    public void CloseCurrentWindow()
    {
        if (_currentWindow != null)
        {
            _currentWindow.SetActive(false);
            _currentWindow = null;
        }

        _player.SetState(PlayerState.Exploration);
    }
}
