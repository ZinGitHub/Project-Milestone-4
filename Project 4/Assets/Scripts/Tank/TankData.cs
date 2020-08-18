using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankData : MonoBehaviour
{
    // Property atrribute add a head above fields in the inspector
    // Header for components
    [Header("Components")]
    // Header field for Transform
    // tf will hold data for Transform
    public Transform tf;
    // Header field for TankMotor
    // mover will hold data for TankMotor
    public TankMotor mover;
    // Header field for TankShooter
    // shoot will hold data for TankShooter
    public TankShooter shoot;
    // Header field for TankHealth
    // health will hold data for TankHealth
    public TankHealth health;

    // Property atrribute add a head above fields in the inspector
    // Header for variables
    [Header("Variables")]
    // Public float for moveSpeed = the speed at which the tank goes forward
    public float moveSpeed;
    // Float for reverseMoveSpeed = the speed at which the tank goes backwards
    public float reverseMoveSpeed;
    // Float for rotateSpeed = the speed at which the tank rotates
    public float rotateSpeed;
    // Float for fireCooldown = the duration for how long until another bullet can be shot
    public float fireCooldown;
    // Float for score, score will start at zero
    public float score = 0;
    // Float for points, for every tank killed gives you one point
    public float points = 1;

    // Property atrribute add a head above fields in the inspector
    // Header for components
    [Header("GameObjects")]
    // Set a bulletPreFab in inspector
    public GameObject bulletPrefab;

    //
    //public Text ScoreText;

    // Initialize the variables and game state
    private void Awake()
    {
        // Recall and intialize Transform component
        tf = GetComponent<Transform>();
        // Recall and intialize TankMotor component
        mover = GetComponent<TankMotor>();
        // Recall and intialize TankShooter component
        shoot = GetComponent<TankShooter>();
        // Recall and intialize TankHealth component
        health = GetComponent<TankHealth>();
    }

   
    // Public variable for a Vector3 named PlayerPos.
    // Vector3 to record the player position.
    public static Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        // A StartCoroutine method to call the IEnumerator function named TrackPlayer.
        StartCoroutine(TrackPlayer());
    }

    // An IEnumerator to trak the player tank movement.
    IEnumerator TrackPlayer()
    {
        // A while loop that will keep running until the IEnumerator deems it no longer run.
        while (true)
        {
            // The player position vector3 will be set by the transform position of the tank game object.
            playerPos = gameObject.transform.position;
            // Run the nect frame again for TrackPlayer Ienumerator.
            yield return null;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
