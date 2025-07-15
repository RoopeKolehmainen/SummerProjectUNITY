using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterData CharacterStats;
    private int health;
    private int damage;
    public static Action<int> healthChanged;
    private void Start()
    {
        Reset_game();
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
    }

}
