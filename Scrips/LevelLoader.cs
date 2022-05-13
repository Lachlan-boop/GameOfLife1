// Version 3 of LevelLoader
// Updated and much more efficient method to changing the colour of the game

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    public GameObject gameCamera;
    Camera camera;

    private void Start()
    {
        // access camera component of game camera
        camera = gameCamera.GetComponent<Camera>();
    }

    public void LoadGame(Image image)
    {
        // change background colour of camera to blue
        camera.backgroundColor = image.color;

        // load game
        SceneManager.LoadScene("GameOfLife");
    }

    public void LoadStartScreen()
    {
        // load start screen
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadGamePurple(Image image)
    {
        // change background colour of camera to purple
        camera.backgroundColor = image.color;

        // load game
        SceneManager.LoadScene("GameOfLife");
    }

    public void GameGreen(Image image)
    {
        // change background colour of camera to green
        camera.backgroundColor = image.color;

        // load game
        SceneManager.LoadScene("GameOfLife");
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
