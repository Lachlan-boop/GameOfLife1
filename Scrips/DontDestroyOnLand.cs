using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLand : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene("SampleScene");

        /*for (int i = 0; i < Object.FindObjectsOfType<DontDestroyOnLand>().Length; i++)
        {
            if (Object.FindObjectsOfType<DontDestroyOnLand>()[i] != this)
            {
                if (Object.FindObjectsOfType<DontDestroyOnLand>()[i].name == gameObject.name)
                {
                    Destroy(gameObject);
                }
            }
            
        }*/

        DontDestroyOnLoad(gameObject);
    }

  
}
