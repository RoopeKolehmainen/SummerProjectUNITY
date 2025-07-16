using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    private List<GameObject> playerTeam = new List<GameObject>();
    private List<GameObject> enemyTeam = new List<GameObject>();
    public static CharacterManager Instance { get; private set; }
    private int AssignPlayerNumber = 1;
    private int AssignEnemyNumber = 1;
    void Start()
    {
        Instance = this;
        SceneManager.sceneLoaded += OnSceneLoad;
    }
    public IEnumerator AssignTeam(GameObject ID)
    {
        
        if (ID.GetComponent<Character>().CharacterStats.CharacterTeam == 0)
        {
            //Default value is 0 to avoid random bugs
            yield return null;
        }
        if (ID.GetComponent<Character>().CharacterStats.CharacterTeam.ToString() == "player")
        {
            playerTeam.Add(ID);
            yield break;
        }
        enemyTeam.Add(ID);
        yield break;

    }
    public void RemoveFromTeam(GameObject ID)
    {
        if (ID.GetComponent<Character>().CharacterStats.CharacterTeam.ToString() == "player")
        {
            playerTeam.Remove(ID);
            return;
        }
        enemyTeam.Remove(ID);
    }
    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        AssignPlayerNumber = 1;
        AssignEnemyNumber = 1;
    }
    public int AssignNumber(string team)
    {
        if(team == "player")
        {
            AssignPlayerNumber += 1;
            return AssignPlayerNumber - 1;
        }
        AssignEnemyNumber += 1;
        return AssignEnemyNumber - 1;
    }
}
