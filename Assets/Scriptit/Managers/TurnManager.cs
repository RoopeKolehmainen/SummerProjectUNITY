using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance {  get; private set; }
    private bool is_player_turn = true;
    private int playerturnnumber;
    public int PlayerTurnNumber => playerturnnumber;
    private int enemyturnnumber;
    public int EnemyTurnNumber => enemyturnnumber;
    private void Start()
    {
        Instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Update_turn();
        }
    }
    public void Update_turn()
    {
        if (is_player_turn)
        {
            UpdateTurnNumber();
            is_player_turn = false;
            return;
        }
        UpdateTurnNumber();
        is_player_turn = true;
    }
    public void UpdateTurnNumber()
    {
        if (is_player_turn)
        {
            playerturnnumber += 1;

            if (CharacterManager.Instance.PlayerTeam.Count <= playerturnnumber -1)
            {

                playerturnnumber = 0;
                return;
            }
            enemyturnnumber += 1;
            if (CharacterManager.Instance.EnemyTeam.Count <= enemyturnnumber -1)
            {
                enemyturnnumber = 0;
                return;
            }
        }
    }
}
