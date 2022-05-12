using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    //public Animator transition;

    //public float transitionTime = 1f;

    // Update is called once per frame
    //void Update()
    //{
    // if(Input.GetMouseButtonDown(0))
    //{
    //LoadNextLevel();
    // }
    // }

    public bool GreenActive;
    public bool BlueActive;
    public bool PurpleActive;

    public GameObject gameCamera;
    Camera camera;

    private void Start()
    {
        camera = gameCamera.GetComponent<Camera>();
    }

    public void LoadGame(Image image)
    {
        camera.backgroundColor = image.color;
        SceneManager.LoadScene("GameOfLife");
        //StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        BlueActive = true;
        

    }

    public void LoadStartScreen()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadGamePurple(Image image)
    {
        camera.backgroundColor = image.color;
        SceneManager.LoadScene("GameOfLife");
        PurpleActive = true;
        
    }

    public void GameGreen(Image image)
    {
        camera.backgroundColor = image.color;
        SceneManager.LoadScene("GameOfLife");
        GreenActive = true;
        
    }

    /*IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load Scene
        SceneManager.LoadScene(levelIndex);
    }*/

    void Update ()
    {
        //mainCamera.SetActive(false);
        //greenCamera.SetActive(false);
        //purpleCamera.SetActive(false);

        /*if (BlueActive == true)
        {
            GreenActive = false;
            PurpleActive = false;

            //purpleCamera.SetActive(false);
            //greenCamera.SetActive(false);
            mainCamera.SetActive(true);
        }

        else if (GreenActive == true)
        {
            BlueActive = false;
            PurpleActive = false;

            //mainCamera.SetActive(false);
            //purpleCamera.SetActive(false);
            Destroy(mainCamera.gameObject);
            Destroy(purpleCamera.gameObject);
            greenCamera.SetActive(true);
        }

        else if (PurpleActive == true)
        {
            BlueActive = false;
            GreenActive = false;

            greenCamera.SetActive(false);
            mainCamera.SetActive(false);
            purpleCamera.SetActive(true);
        }
       */
    }

    public void DontDestroyOnLoad()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
