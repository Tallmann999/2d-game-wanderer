using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerState State { get; private set; } = PlayerState.Exploration;

    void Update()
    {
        if (State == PlayerState.Exploration)
        {
            // ������� �������� ��� ����� ��� ��������� ���� � ui
        }
        else if (State == PlayerState.Interaction)
        {
            // ��������� �������� ��� ����� ��� ��������� ���� � ui
        }
    }

    public void SetState(PlayerState newState)
    {
        State = newState;
    }
}
