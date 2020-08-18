using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrol : MonoBehaviour
{
    // Connect data from the TankData class with pawn 
    public TankData pawn;
    // Component variable that is attached to the patrolling tank that will allow it to navigate the scene.
    private NavMeshAgent agent;

    // GameObject component variable that will attached to player tank 
    public GameObject Player;

    // Transform array that will store the patrol points
    public Transform[] moveSpots;
    // Int variable that will select a random patrol point for the AI tank to travel to
    private int randomSpot;

    // Float variable that determines the distance between the player and AI
    // Can be editted by designer
    public float distToPlayer = 5.0f;

    // Float variable to record how long it takes for the AI tank to start strafing.
    private float randomStrafeStartTime;
    // Float variable to record how long it takes for the AI tank to wait strafe time
    private float waitStrafeTime;
    // Float variable determining the minimum strafe
    public float minStrafe;
    // Float variable determing the maxium strafe
    public float maxStrafe;

    // Transform variable to manipulate the position and rotation of the tank tracks on the right
    public Transform strafeRight;
    // Transform variable to manipulate the positiona dn rotation of the tank tracks on the left
    public Transform strafeLeft;
    // Int variable that will select a random strafe direction
    private int randomStrafeDir;

    // Float variable delcaring the chase radius
    public float chaseRadius = 20f;
    // Float varaible declaring the face player factor
    public float facePlayerFactor = 20f;

    // Float variable declaring and recording the wait time
    private float waitTime;
    // Float variable declaring and declaring the starting wait time
    public float startWaitTime = 1f;
    

    // Boolean variable to check if the player tank is in line of sight
    public bool playerIsInLOS = false;
    // Float variable delcaring the field of view angle on the AI tank
    public float fieldOfViewAngle = 160f;
    // Float variable declaring the line of sight radius of the AI tank
    public float losRadius = 45f;

    // boolean variable to check if the AI Remembers the player tank location
    private bool AIMemorizePlayer = false;
    // Float variable recording and declaring the start time of the AI memory
    public float memoryStartTime = 10f;
    // Float variable to increase memory time for the AI tank
    private float increasingMemoryTime;

    // Vector3 to store the noise position
    UnityEngine.Vector3 noisePosition;
    // Boolean variable to check if the AI tank heard the player tank
    private bool AIHeardPlayer = false;
    // Float variable declaring the AI's noise travel distance
    public float noiseTravelDistance = 50f;
    // Flaot variable declaring the AI's spin speed
    public float spinSpeed = 3f;
    // Boolean variable to check if the AI tank should spin
    private bool canSpin = false;
    // Float variable recording how long the AI tank is spinning
    private float isSpinningTime;
    // Float variable declaring the spin time
    public float spinTime = 3f;

    // Initialize the varaibles and game state before the game starts
    private void Awake()
    {
        // Return the NavMeshAgent that is called agent
        // Recieve the agent NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
        // Check if the agent NavMeshAgent is enabled
        agent.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set the wait time and the start of the wait time equal each other
        waitTime = startWaitTime;
        // Random number generator to choose a patrol point for the AI tank
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        // The distance will be set to the distance vector that will return the distance between vector a and vector b
        // Vector a = TankData.playerPos
        // Vector b = transform.position
        float distance = UnityEngine.Vector3.Distance(TankData.playerPos, transform.position);

        // An if statement that will execute the CheckLOS function only if distance is less than or equal to line of sight radius
        if(distance <= losRadius)
        {
            // CheckLOS function call
            CheckLOS();
        }

        // An if statement that will execute the patrol and chase code if the NavMeshAgent is active and enabled
        if (agent.isActiveAndEnabled)
        {
            // An if statement that will execute the Patrol, NoiseCheck functions, and stop coroutine on AI memeory
            // If statemnet will only be executed if...
            // Player is not in line of sight
            // AND AI does not memorize player
            // AND AI has not heard the player tank
            if(playerIsInLOS == false && AIMemorizePlayer == false && AIHeardPlayer == false)
            {
                // Patrol function call
                Patrol();
                // NoiseCheck function call
                NoiseCheck();
                // Stop the coroutine on the AI memory
                StopCoroutine(AIMemory());
            }
            // An else if statement that will execute the GoToNoisePosition function
            // Else if statemnet will only be executed if...
            // AI tank heard player
            // AND player is not in line of sight
            // AND AI does not memorize the player
            else if (AIHeardPlayer == true && playerIsInLOS == false && AIMemorizePlayer == false)
            {
                // Set the boolean value of canSpin to true
                canSpin = true;
                // GoToNoisePosition function call
                GoToNoisePosition();
            }
            // An else if statement that will execute FacePlayer and ChasePlayer function if player is in line of sight of AI tank
            else if(playerIsInLOS == true)
            {
                // Set the boolean value of AIMemorizePlayer to true
                AIMemorizePlayer = true;
                // FacePlayer function call
                FacePlayer();
                // ChasePlayer function call
                ChasePlayer();
            }
            // An else if statement that will execute the ChasePlayer function and start coroutine for AI memory
            // Will execute if the AI does memorize the player and the player is not in sight
            else if (AIMemorizePlayer == true && playerIsInLOS == false)
            {
                // ChasePlayer function call
                ChasePlayer();
                // Start the corutine for the AI memory
                StartCoroutine(AIMemory());
            }
        } 
    }

    // Function definition for NoiseCheck
    void NoiseCheck()
    {
        // The distance will be set to the distance vector that will return the distance between vector a and vector b
        // Vector a = transform.positon
        // Vector b = target.transform.position
        float distance = UnityEngine.Vector3.Distance(TankData.playerPos, transform.position);

        // An if statement that will run the majority of the NoiseCheck code only if the distance is less than or equal to the noiseTravelDistance
        if(distance <= noiseTravelDistance)
        {
            // An if statement that will set noisePosition and AIHeardPlayer true if the player has pressed the spacebar button on the keyboard
            if (Input.GetKey(KeyCode.Space))
            {
                // NoisePosition is set to the Player's transform position
                noisePosition = Player.transform.position;
                // Set the boolean value of AIHeardPlayer to true
                AIHeardPlayer = true;
            }
            // Exception condition if player has not yet pressed the spacebar button
            else
            {
                // Set the boolean value of AIHeardPlayer to false
                AIHeardPlayer = false;
                // Set the boolean value of canSpin to false
                canSpin = false;
            }
        }
    }

    // Function definition for GoToNoisePosition
    void GoToNoisePosition()
    {
        // Set the destination of the NavMeshAgent agent to the noise position vector
        agent.SetDestination(noisePosition);

        // If statement that will run a majority of the GoToNoisePosition function
        // Only if the vector3 distance transforsm position and noisePosition is less than or equal to 5
        // AND if canSpin is set to false
        if(UnityEngine.Vector3.Distance(transform.position, noisePosition) <= 5f && canSpin == true)
        {
            // Set the isSpinningTime Time.deltaTime
            isSpinningTime += Time.deltaTime;
            // Rotate the tank by using the values of Vector3 up Times spinSpeed and use the relative of the game world
            transform.Rotate(UnityEngine.Vector3.up * spinSpeed, Space.World);

            // An if statement that will revalue variables if the isSpinningTime is greater than or equal to spinTime
            if(isSpinningTime >= spinTime)
            {
                // Set the boolean variable of canSpin to false
                canSpin = false;
                // Set the boolean variable of AIHeardPlayer to false
                AIHeardPlayer = false;
                // Set the float value of isSpinningTime to zero
                isSpinningTime = 0f;
            }
        }
    }

    // An IEnumerator for AIMemory
    IEnumerator AIMemory()
    {
        // Initially set the increasingMemoryTime to zero 
        increasingMemoryTime = 0;

        // A while loop that will keep running until the increasingMemoryTime value is less than the value of memoryStartTime
        while(increasingMemoryTime < memoryStartTime)
        {
            // Set the increasingMemoryTime to Time.deltaTime
            increasingMemoryTime += Time.deltaTime;
            // Set the boolean value of AIMemorizePlayer to true
            AIMemorizePlayer = true;
            // Run the nect frame again for TrackPlayer Ienumerator.
            yield return null;
        }

        // Set the boolean value of AIHeardPlayer to false
        AIHeardPlayer = false;
        // Set the boolean value AIMemorizePlayer to false
        AIMemorizePlayer = false;
    }

    // Function defintion for CheckLOS
    // LOS = Line of Sight
    void CheckLOS()
    {
        // Set the vector3 distance to equal the Player's transform position minus the transform position
        UnityEngine.Vector3 direction = Player.transform.position - transform.position;
        // Set the angle equal to the Vector3 Angle with the values from direction Vector3 to transform position
        float angle = UnityEngine.Vector3.Angle(direction, transform.forward);

        // An if statement that will run a majority of the CheckLOS function if the angle value is less than the fieldOfViewAngle * 0.5f
        if(angle < fieldOfViewAngle * 0.5f)
        {
            // RayCastHit local variable named hit.
            // Structure used to get the information back from a raycast
            RaycastHit hit;

            // An if statement that will check if the physics properties of the raycast
            // Use the transform position as the origin
            // Use the normalized direction Vector3 as the direction
            // Use losRadius as the max distance
            if(Physics.Raycast(transform.position, direction.normalized, out hit, losRadius))
            {
                // Check to see if the hit collider has the player tag
                if(hit.collider.tag == "Player")
                {
                    // Set the boolean value of playerIsInLOS to true
                    playerIsInLOS = true;
                    // Set the AIMemorizePlayer boolean value to true
                    AIMemorizePlayer = true;
                }
                // An exception case if the hit collider did not equal to the game object with the player tag
                else
                {
                    // Set the boolean value of playerIsInLOS to false
                    playerIsInLOS = false;
                }
            }
        }
    }

    // Function defintion for Patrol
    void Patrol()
    {
        // Set the destination of the NavMeshAgent agent to the randomly picked patrol poiny
        agent.SetDestination(moveSpots[randomSpot].position);

        // An if else statement that will run a majority of the Patrol function code
        // This if statement will check if the Vector3 distance which will return the distance between vector a and vector b are less than 2.0
        // Vector a = transform.position
        // Vector b = moveSpots[randomSpot].position
        if(UnityEngine.Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 2.0f)
        {
            // Generate a random spot for the AI tank to travel to
            randomSpot = Random.Range(0, moveSpots.Length);
            // Set the wait time and the start of the wait time equal each other
            waitTime = startWaitTime;
        }
        // An else exception case in case the if statement's conditions are not met
        else
        {
            // set wait time to Time.deltaTime
            waitTime -= Time.deltaTime;
        }
    }

    // Function defintion for ChasePlayer
    void ChasePlayer()
    {
        // The distance will be set to the distance vector that will return the distance between vector a and vector b
        // Vector a = TankData.playerPos
        // Vector b = transform.position
        float distance = UnityEngine.Vector3.Distance(TankData.playerPos, transform.position);

        // An if statement that will set the agent NavMesh to the player position
        // If condition's are if distance is less than or equal to chaseRadius
        // AND the distance is greater than distance to player
        if(distance <= chaseRadius && distance > distToPlayer)
        {
            // Set the destination of the NavMeshAgent agent to the player position vector from TankData
            agent.SetDestination(TankData.playerPos);
        }
        // An else if statement that will handle strafing
        // Else if condition's are that the agent NavMesh is active and enabled
        // AND that the distance is less than or equal to distance to player
        else if(agent.isActiveAndEnabled && distance <= distToPlayer)
        {
            // Generate a random strafe direction
            randomStrafeDir = Random.Range(0, 2);
            // Generate a random strafe start time
            randomStrafeStartTime = Random.Range(minStrafe, maxStrafe);

            // A if statements that also has nested if else if statement to handle agent set direction with strafe position
            // If statement for when the wait strafe time is less than or equal to 0
            if(waitStrafeTime <= 0)
            {
                // If statement that will set the agent NavMesh direction for strafe left position
                // Applicable if the random strafe direction is equal to 0
                if(randomStrafeDir == 0)
                {
                    // Set the destination of the NavMeshAgent agent for the strafe left position
                    agent.SetDestination(strafeLeft.position);
                }
                // An else if statement that will set the agent NavMesh for strafe right position
                // Applicable only if the random strafe dirtectin is equal to 0
                else
                if(randomStrafeDir == 1)
                {
                    // Set the destination of the NavMeshAgent agent for the strafe right position
                    agent.SetDestination(strafeRight.position);
                }
                // Set the wait strafe time and random strafe start time equal to each other
                waitStrafeTime = randomStrafeStartTime;
            }
            // An else execption case in case the if statement condition is not met
            else
            {
                // set wait time to Time.deltaTime
                waitStrafeTime -= Time.deltaTime;
            }
        }
    }

    // Function defintion for FacePlayer
    void FacePlayer()
    {
        // Change the direction of the AI tank to face the player
        UnityEngine.Vector3 direction = (TankData.playerPos - transform.position).normalized;
        // Change the rotation of the AI tank to face the player
        UnityEngine.Quaternion lookRotation = UnityEngine.Quaternion.LookRotation(new UnityEngine.Vector3(direction.x, 0, direction.z));
        // Store and set the data of the rotation of the transform in comparison of the game world
        transform.rotation = UnityEngine.Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * facePlayerFactor);
        // Shoot function called
        Shoot();
    }

    // Function defintion for Shoot
    public void Shoot()
    {
        // If the pawn AI tank is not null then shoot bullet
        if (pawn != null)
        {
            // Shoot bullet 
            pawn.shoot.Shoot(pawn.bulletPrefab);
        }
    }
}
