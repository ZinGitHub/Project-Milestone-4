using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject player;
    public TankHealth health;
    
    public void GameOverMenu()
    {
        if (health.currentHealth == 1 && GameObject.FindWithTag("Player"))
        {
            SceneManager.LoadScene("Game Over Menu");
            
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
