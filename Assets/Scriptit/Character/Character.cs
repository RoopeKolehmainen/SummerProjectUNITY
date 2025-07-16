using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public CharacterData CharacterStats;
    private int health;
    private int damage;
    public static Action<int> healthChanged;
    public int TurnNumber;
    public int teamID;
    private void Start()
    {
        Reset_game();
        CharacterManager.Instance.StartCoroutine("AssignTeam",gameObject);
        teamID = CharacterManager.Instance.AssignNumber(CharacterStats.CharacterTeam.ToString());
        //TODO add IEnumerator
    }
    public void Reset_game()
    {
        health = CharacterStats.Health;
        damage = CharacterStats.Damage;
    }
    public void Update_health(int damage) 
    {
        health -= damage;
        healthChanged?.Invoke(health);
        if (health <= 0)
        {
            CharacterManager.Instance.RemoveFromTeam(gameObject);
            Destroy(gameObject);
        }
    }
}
