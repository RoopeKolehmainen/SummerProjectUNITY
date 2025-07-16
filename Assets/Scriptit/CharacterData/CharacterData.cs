using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField]private int health;
    public int Health => health;
    [SerializeField]private int damage;
    public int Damage => damage;
    public enum Team
    {
        defaultvalue, //not in use, this is to avoid random bugs 
        player, 
        enemy
    }
    [SerializeField] private Team team;
    public Team CharacterTeam => team;
}
