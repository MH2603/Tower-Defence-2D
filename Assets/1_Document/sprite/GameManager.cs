using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [Header("Component")]
    public ManagerAsset managerAsset;
    public GameObject playerOb;

    [Header("Gui")]
    public Gui Gui;
    public WuiPlayer wuiPlayer;

    [Header("Energy")]
    public int maxEnergy = 100;
    public int currentEnergy;

    [Header("Status")]
    public List<GameObject> enemies;
    public int Score, LevelFinish = 1;

    [Header("* Sound Asset")]
    public AudioClip enemyDieSound;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Init();   
    }

    void Init()
    {
        Gui.Init(maxEnergy);
        managerAsset.Init();
    }

    public void RemoveEnemy(GameObject enemyOb)
    {
        enemies.Remove(enemyOb); 
        SoundManager.Instance.ShowSound(enemyDieSound,0.6f); 

    }

    public void EndGame()
    {
        // Set Data
        SaveData(LevelFinish , Score);

        Gui.ShowEndGame();
    }


    public bool UseEnergy(int value)
    {
        if( value > maxEnergy - currentEnergy)
        {
            wuiPlayer.SetTextStatus("Overload Engergy !!!");

            Gui.energyUi.icon.transform.DOShakePosition(3f, 0.5f).OnComplete( () =>
            {
                Gui.energyUi.icon.color = Color.white;
            });
            Gui.energyUi.icon.color = Color.red;

            return false;
        }
        else
        {
            currentEnergy += value;
            Gui.energyUi.SetEnergy(currentEnergy);

            if( value > 0 ) wuiPlayer.SetTextStatus("Done (^_^)");
            else wuiPlayer.SetTextStatus("Bad Tower (-.-)");

            return true;
        }
    }

    #region( User Data )

    public void SaveData(int level, int score)
    {
        if( PLayerPrefManager.HighLevel < level)
        {
            PLayerPrefManager.HighLevel = level;
        }

        if( PLayerPrefManager.HighScore < score)
        {
            PLayerPrefManager.HighScore = score;
        }
    }

    #endregion


    public void OffObject(GameObject ob, float delay = 1f)
    {
        StartCoroutine(OffOb(ob, delay));
    }

    IEnumerator OffOb(GameObject ob, float delay = 1f)
    {
        yield return new WaitForSecondsRealtime(delay);
        ob.Recycle();
    }
}

