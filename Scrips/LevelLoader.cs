using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    // Update is called once per frame
    //void Update()
    //{
       // if(Input.GetMouseButtonDown(0))
        //{
            //LoadNextLevel();
       // }
   // }

    public void LoadGame()
    {
        SceneManager.LoadScene("GameOfLife");
        //StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        
    }

    public void LoadStartScreen()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadGamePurple()
    {
        SceneManager.LoadScene("GamePurple");
    }

    public void GameGreen()
    {
        SceneManager.LoadScene("GameGreen");
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load Scene
        SceneManager.LoadScene(levelIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
