using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    private bool is_game_running = true;

    private void Start()
    {
        Instance = this;
    }
    public void Update_game_state() 
    {
        if (is_game_running)
        {
            is_game_running = false;
            return;
        }
        is_game_running = true;
        
    }

}
