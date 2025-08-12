using UnityEngine;
using UnityEngine.Rendering;

public class AttackManager : MonoBehaviour
{
    public static AttackManager Instance { get; private set; }

    [SerializeField] Camera maincamera;
    private float distance = 10;
    private GameObject currentTarget;
    [SerializeField] private GameObject actionMenu;
    private void Start()
    {
        Instance = this;
    }
    public void Attack(GameObject source, GameObject target)
    {
        target.GetComponent<Character>().Update_health(source.GetComponent<Character>().Damage);
    }
    public void shootRay()
    {
        Vector3 mouseWorldposition = maincamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldposition.z = -1f;
        RaycastHit hit;

        if (Physics.Raycast(mouseWorldposition, new Vector3(0, 0, distance), out hit))
        {
            popInfo(hit.transform.gameObject);

        }
     
    }
    public void popInfo(GameObject target)
    {

        if (target.GetComponent<Character>().CharacterStats.CharacterTeam.ToString() == "enemy")
        {

            currentTarget = target;
            actionMenu.SetActive(true);
        }

    }
    public void playerAttack()
    {

    }
}
