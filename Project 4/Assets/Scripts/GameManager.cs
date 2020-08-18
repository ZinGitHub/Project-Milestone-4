using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // GameManager class contain instance to assure a copy
    public static GameManager instance;
    // Create a list for players that contain the data from TankController
    public List<TankController> players;

    //
    void Awake()
    {
        // An if statement for when the instance is null
        if (instance == null)
        {
            // Instance the GameManager
            instance = this;
            // Do not destroy the GameManager (gameObject) when loading a new scence
            DontDestroyOnLoad(gameObject);
        }
        // Else statement for destroying the GameManager (gameObject)
        else
        {
            // Destroy the GameManager (gameObject)
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
