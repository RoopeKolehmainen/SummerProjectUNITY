using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour
{
    [SerializeField] public CharacterData CharacterStats;
    private int health;
    private int damage;
    public int Damage => damage;
    public static Action<int> healthChanged;

    private void Start()
    {
        Reset_game();
        StartCoroutine(nameof(setTeam));
        
      
    }
    public IEnumerator setTeam()
    {
        if(CharacterManager.Instance == null)
        {
            yield return null;
        }
        CharacterManager.Instance.StartCoroutine("AssignTeam", gameObject);
        yield break;
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
