using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;

public class Game : MonoBehaviour
{

    private static int SCREEN_WIDTH = 64;   //- 1024 pixels
    private static int SCREEN_HEIGHT = 48;  //- 768 pixels

    public float speed = 0.1f;

    private float timer = 0f;

    public bool simulationEnabled = false;

    public int evolutionCounter = 0;

    public int placedCount = 0;
    public int deathCount = 0;
    public int bornCount = 0;

    //string[] counterArray = { "Evolutions: ", "Placed Cells: ", "Cells Killed: ", "Cells Born: " };
    string[] counterArray;
    string myFilePath, fileName;

    Cell[,] grid = new Cell[SCREEN_WIDTH, SCREEN_HEIGHT];

    // Start is called before the first frame update
    void Start()
    {
        fileName = "history.txt";
        myFilePath = Application.dataPath + "/" + fileName;

        for (int y = 0; y < SCREEN_HEIGHT; y++)
        {
            for (int x = 0; x < SCREEN_WIDTH; x++)
            {

                Cell cell = Instantiate(Resources.Load("Prefabs/Cell", typeof(Cell)), new Vector2(x, y), Quaternion.identity) as Cell;
                grid[x, y] = cell;
                grid[x, y].SetAlive(false);
                placedCount++;

            }
        }

        PlaceCells(3);
    }

    //public void StartGame()
    //{
    //    simulationEnabled = true;
    //}

    //public void PauseGame()
    //{
    //    simulationEnabled = false;

        //test evolution counter:
        //Debug.Log(evolutionCounter);
        //success

        //test death count:
        //Debug.Log(deathCount);
        //success

        //test born count
        //Debug.Log(bornCount);
        //success

        //test placed count
        //Debug.Log(placedCount);
    //}

    // Update is called once per frame
    public void Update()
    {

        if (simulationEnabled)
        {
            if (timer >= speed)
            {
                timer = 0f;
                CountNeighbors();

                PopulationControl();

                evolutionCounter++;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }

        UserInput();


    }
    public void PresetInputData(int val)
    {

        if (val == 1)
        {
            PlaceCells(1);
        }

        if (val == 2)
        {
            PlaceCells(2);
        }

        if (val == 3)
        {
            PlaceCells(3);
        }

        if (val == 4)
        {
            PlaceCells(4);
        }

    }
    public void UserInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            int x = Mathf.RoundToInt(mousePoint.x);
            int y = Mathf.RoundToInt(mousePoint.y);

            if (x >= 0 && y >= 0 && x < SCREEN_WIDTH && y < SCREEN_HEIGHT)
            {
                // We are in bounds
                grid[x, y].SetAlive(!grid[x, y].isAlive);
                placedCount++;
            }
        }
        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            //Pause Simulation
            simulationEnabled = false;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            //Build simulation / resume
            simulationEnabled = true;
        }
    }

    public void PlaceCells(int type)
    {
        if(type == 1)
        {
            for (int y = 0; y < SCREEN_HEIGHT; y++)
            {
                for (int x = 0; x < SCREEN_WIDTH; x++)
                {
                    grid[x, y].SetAlive(false);
                }
            }
                }
        if (type == 2)
        {
            for (int y = 0; y < SCREEN_HEIGHT; y++)
            {
                for (int x = 0; x < SCREEN_WIDTH; x++)
                {

                    int rand = UnityEngine.Random.Range(0, 100);
                    if (rand > 75)
                    {
                        grid[x,y].SetAlive(true);
                    }
                }
            }
        }

        //kite
        if (type == 3)
        {
            for (int y = 21; y < 24; y++)
            {
                for (int x = 30; x < 33; x++)
                {
                    if (x != 33)
                    {
                        if (y == 21 || y == 23 && (x ==31) || y == 22 && (x == 32))
                        {
                            grid[x, y].SetAlive(true);
                        }
                    }
                }
            }
        }

        if (type == 4)
        {
            for (int y = 0; y < SCREEN_HEIGHT; y++)
            {
                for(int x = 0; x < SCREEN_WIDTH; x++)
                {
                    grid[x, y].SetAlive(false);
                }
            }
            
        }
    }

    public void PlayPause(Image image)
    {
        simulationEnabled = !simulationEnabled;
        if (simulationEnabled)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/pausebutton");
        } else
        {
            image.sprite = Resources.Load<Sprite>("Sprites/playbutton");
        }
    }

    void CountNeighbors()
    {
        for (int y = 0; y < SCREEN_HEIGHT; y++)
        {
            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                int numNeighbors = 0;

                //- North
                if (y + 1 < SCREEN_HEIGHT)
                {
                    if (grid[x, y + 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                //- East
                if (x + 1 < SCREEN_WIDTH)
                {
                    if (grid[x + 1, y].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                //- South
                if (y - 1 >= 0)
                {
                    if (grid[x, y - 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                //- West
                if (x - 1 >= 0)
                {
                    if (grid[x - 1, y].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                //- NothEast
                if (x + 1 < SCREEN_WIDTH && y + 1 < SCREEN_HEIGHT)
                {
                    if (grid[x + 1, y + 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                //- NorthWest
                if (x - 1 >= 0 && y + 1 < SCREEN_HEIGHT)
                {
                    if (grid[x - 1, y + 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                //- SouthEast
                if (x + 1 < SCREEN_WIDTH && y - 1 >= 0)
                {
                    if (grid[x + 1, y - 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                //- SouthWest
                if (x - 1 >= 0 && y - 1 >= 0)
                {
                    if (grid[x - 1, y - 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                grid[x, y].numNeighbors = numNeighbors;
            }
        }
    }
    public void PopulationControl()
    {
        for (int y = 0; y < SCREEN_HEIGHT; y++)
        {
            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                //- Rules
                //- Any live cell with 2 or 3 live neighbors survives
                //- Any dead with 3 live neighbors becomes a live cell
                //- All other live cells die in the next generation adn all other dead cells stay dead

                if (grid[x, y].isAlive)
                {
                    //- Cell is alive
                    if (grid[x, y].numNeighbors != 2 && grid[x, y].numNeighbors != 3)
                    {
                        grid[x, y].SetAlive(false);
                        deathCount++;
                    }
                }
                else
                {
                    //- Cell is Dead
                    if (grid[x, y].numNeighbors == 3)
                    {
                        grid[x, y].SetAlive(true);
                        bornCount++;
                    }
                }
            }
        }
    }

    /*bool RandomAliveCell()
    {
        int rand = UnityEngine.Random.Range(0, 100);

        if (rand > 75)
        {
            return true;
        }

        return false;
    }*/

   
    public void CreateFileWithHistory()
    {
        //build array
        string[] counterArray = { $"Evolutions: {evolutionCounter} ", $"Placed Cells: {placedCount}", $"Cells Killed: {deathCount}", $"Cells Born: {bornCount}" };

        //write local array to a txt file
        File.WriteAllLines(myFilePath, counterArray);
    }
}

