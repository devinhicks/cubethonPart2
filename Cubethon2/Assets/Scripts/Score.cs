using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameManager gm;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gm.collected.ToString("0");
    }
}