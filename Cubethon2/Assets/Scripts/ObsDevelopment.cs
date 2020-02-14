using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObsDevelopment : MonoBehaviour
{
    public Text text;

    private void OnEnable()
    {
        PlayerMovement.OnReachHalfway += changeTextHalfway;
    }

    private void OnDisable()
    {
        PlayerMovement.OnReachHalfway -= changeTextHalfway;
    }

    public void changeTextHalfway()
    {
        text.text = "-halfway there!-";
    }
}
