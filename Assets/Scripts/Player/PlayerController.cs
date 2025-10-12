using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerState State { get; private set; } = PlayerState.Exploration;

    void Update()
    {
        if (State == PlayerState.Exploration)
        {
            // обычное движение это когда идёт активация окон в ui
        }
        else if (State == PlayerState.Interaction)
        {
            // блокируем движение это когда идёт активация окон в ui
        }
    }

    public void SetState(PlayerState newState)
    {
        State = newState;
    }
}
