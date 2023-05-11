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
        highScore.text = PLayerPrefManager.HighScore.ToString();
        highLevel.text = PLayerPrefManager.HighLevel.ToString();

        MenuHighScore.SetActive(true);
    }
}
