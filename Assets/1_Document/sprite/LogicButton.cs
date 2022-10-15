using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LogicButton : MonoBehaviour
{

    public Animator anima;

    public bool isPause;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoToScene(true));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string nameScene)
    {
        StartCoroutine(GoToScene(false));

        StartCoroutine(LoadScene_1(nameScene));

    }
    IEnumerator LoadScene_1(string nameScene)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nameScene);
    
    }

    public void QuitGame()
    {
        
        Application.Quit();
    }

    IEnumerator GoToScene(bool isAnimation) // Animation Screen when load scene
    {
        anima.gameObject.SetActive(true);

        if (isAnimation) anima.SetFloat("current", 1);
        else anima.SetFloat("current", -1);

        

        yield return new WaitForSeconds(1.5f);
        anima.gameObject.SetActive(false);
    }


    // Pause
    public void Pause() // Button call
    {
        if (!isPause)
        {
            Time.timeScale = 0f;
            isPause = true;

            return;
        }
        else
        {
            Time.timeScale = 1f;
            isPause = false;

            return;
        }
    }
}
