using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject RulesUI;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Rules()
    {
        RulesUI.SetActive(true);
    }

    public void Update ()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            RulesUI.SetActive(false);
        }
    }
}
