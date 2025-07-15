using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance {  get; private set; }
    private bool is_player_turn = true;
    private void Start()
    {
        Instance = this;
    }
    public void Update_turn()
    {
        if (is_player_turn)
        {
            is_player_turn = false;
            return;
        }
        is_player_turn = true;
    }
}
