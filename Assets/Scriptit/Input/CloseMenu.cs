using UnityEngine;

public class CloseMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            close();
        }
    }
    public void close()
    {
        this.gameObject.SetActive(false);
    }
}
