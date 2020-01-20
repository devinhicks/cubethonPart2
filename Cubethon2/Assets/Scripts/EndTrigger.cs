using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    public GameManager gameManager;

    // When player hits goal, level is complete
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && gameManager.collected >= 3)
        {
            gameManager.ComepleteLevel();
        }
        else if (col.gameObject.tag == "Player" && gameManager.collected < 3)
        {
            gameManager.EndGame();
        }
    }
}
