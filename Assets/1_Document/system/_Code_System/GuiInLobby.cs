using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiInLobby : MonoBehaviour
{
    public GameObject MenuHighScore;
    public Text highScore, highLevel;

    public void ShowHighScore()
    {
        highScore.text = PlayerPrefs.GetFloat("HighScore").ToString();
        highLevel.text = PlayerPrefs.GetFloat("HighLevel").ToString();

        MenuHighScore.SetActive(true);
    }
}
