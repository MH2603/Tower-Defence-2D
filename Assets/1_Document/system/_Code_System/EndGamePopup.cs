using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGamePopup : MonoBehaviour
{
    public TextMeshProUGUI textHightScore;
    public TextMeshProUGUI textCurrentScore;
    public TextMeshProUGUI textHightLevel;


    public void Init(int currentScore)
    {
        textCurrentScore.text = "Current Sscore : " + currentScore.ToString();

        textHightScore.text = "Hight Score : " +  PLayerPrefManager.HighScore.ToString();
        textHightLevel.text = "Level Finish : " +  PLayerPrefManager.HighLevel.ToString();
    }
}
