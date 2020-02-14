using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Announce : MonoBehaviour
{
    public Text text;
    public GameManager gm;

    private void OnEnable()
    {
        PlayerMovement.OnReachHalfway += changeTextHalfway;
        PlayerMovement.OnPastHalfway += changeTextBlank;
        PlayerMovement.OnFall += changeTextOops;
    }

    private void OnDisable()
    {
        PlayerMovement.OnReachHalfway -= changeTextHalfway;
        PlayerMovement.OnPastHalfway -= changeTextBlank;
        PlayerMovement.OnFall -= changeTextOops;
    }

    // At halfway point, change the text
    public void changeTextHalfway()
    {
        text.text = "-halfway there!-";
    }

    // After a few second, change text back to blank
    public void changeTextBlank()
    {
        text.text = "";
    }

    // If you fall off, say oop! and end the game
    public void changeTextOops()
    {
        text.text = "oops!";
        Invoke("EndIt", 1f);
    }

    public void EndIt()
    {
        gm.EndGame();
    }
}
