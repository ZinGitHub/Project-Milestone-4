using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    // Connect data from the TankData class with pawn 
    public TankData pawn;
    // Connect data from the TankData class with target
    public TankData target;

    // Creating a enum for the different types of AI
    public enum AITypes
    {
        // Idle = AI tank won't do anything
        // Shoot = AI will just shoot (won't move)
        // Chase  = AI will chase after the player tank
        // Flee = AI will run away from the player tank
        Idle, Chase, Flee, Shoot
    }

    // Float variable to record how long it takes for the AI tanks to start their state.
    public float stateStartTime;
    // Creating a variable to adjust AI type
    public AITypes currentAIType;

    // Component variable that is attached to the fleeing tank that will allow it to navigate the scene.
    private NavMeshAgent agent;
    // Float variable that will determine how far the AI tank will flee away from the player tank
    public float EnemyDistance = 4.0f;

    // A IPatrol variables
    //
    //public Transform[] moveSpots;
    //
    //private int randomSpot;
    //
    //public float distToPlayer = 5.0f;
    //
    //private float randomStrafeStartTime;
    //
    //private float waitStrafeTime;
    //
    //public float minStrafe;
    //
    //public float maxStrafe;
    //
    //public Transform strafeRight;
    //
    //public Transform strafeLeft;
    //
    //private int randomStrafeDir;
    //
    //public float chaseRadius = 20f;
    //
    //public float facePlayerFactor = 20f;
    //
    //private float waitTime;
    //
    //public float startWaitTime = 1f;
    //
    //public bool playerIsInLOS = false;
    //
    //public float fieldOfViewAngle = 160f;
    //
    //public float losRadius = 45f;
    //
    //private bool AIMemorizePlayer = false;
    //
    //public float memoryStartTime = 10f;
    //
    //private float increasingMemoryTime;
    //
    //Vector3 noisePosition;
    //
    //private bool AIHeardPlayer = false;
    //
    //public float noiseTravelDistance = 50f;
    //
    //public float spinSpeed = 3f;
    //
    //private bool canSpin = false;
    //
    //private float isSpinningTime;
    //
    //public float spinTime = 3f;

    // Function definition for ChangeState
    // AITypes newState set as paramters
    public void ChangeState(AITypes newState)
    {
        // Record the time the tank entered the state
        stateStartTime = Time.time;
        // Set the current AI state into a new state
        currentAIType = newState;
    }

    // Function definition for Idle
    public void Idle()
    {
        // Do Nothing!
    }

    // Function definition for ChasePlayer
    //Vector3 targetPoint set as parameter
    public void ChasePlayer(Vector3 targetPoint)
    {
        // If the pawn AI tank is not null then shoot bullet
        if (pawn != null)
        {
            // Set the targetVector to the targetPoint vector subtracted by the tank pawn's transform and position
            // Normalize the vector to keep the same direction at a length of 1.0 and keep it unchanged while adding a new normalizd vector to return
            Vector3 targetVector = (targetPoint - pawn.tf.position).normalized;
            // Rotate the pawn tank to face the targetVector
            pawn.mover.RotateTowards(targetVector);
            // Move the pawn tank forward
            pawn.mover.Move(Vector3.forward);
        }
    }

    // Function defintion for Flee
    public void Flee()
    {
        // Return the NavMeshAgent that is called agent
        // Recieve the agent NavMeshAgent
        agent = GetComponent<NavMeshAgent>();

        // The distance will be set to the distance vector that will return the distance between vector a and vector b
        // Vector a = transform.positon
        // Vector b = target.transform.position
        float distance = Vector3.Distance(transform.position, target.transform.position);

        // An if statement that will execute code if the float distance is less than the enemy distance
        if (distance < EnemyDistance)
        {
            // The vector of setting the direction to the player will be calculated by subtracting the transform position by the target(player tank) transform position 
            Vector3 dirToPlayer = transform.position - target.transform.position;
            // The vector of setting the new position will be calculated by adding the transform position and the vector dirToPlayer
            Vector3 newPos = transform.position + dirToPlayer;
            // Set the destination of the NavMeshAgent agent to the new position vector
            agent.SetDestination(newPos);
        }
    }

    // Function definition for Shoot
    public void Shoot()
    {
        // If the pawn AI tank is not null then shoot bullet
        if (pawn != null)
        {
            // Shoot the bullet
            pawn.shoot.Shoot(pawn.bulletPrefab);
        }
    }

    //
    //public void Patrol()
    //{
        //
        //agent = GetComponent<NavMeshAgent>();
        //
        //agent.enabled = true;

        //
        //waitTime = startWaitTime;
        //
        //randomSpot = Random.Range(0, moveSpots.Length);

        //
        //float distance = UnityEngine.Vector3.Distance(TankData.playerPos, transform.position);

        //
        //if (distance <= losRadius)
        //{
            //
            //CheckLOS();
        //}

        //
        //if (agent.isActiveAndEnabled)
        //{
            //
            //if (playerIsInLOS == false && AIMemorizePlayer == false && AIHeardPlayer == false)
            //{
                //
                //PatrolAI();
                //
                //NoiseCheck();
                //
                //StopCoroutine(AIMemory());
            //}
            //
            //else if (AIMemorizePlayer == true && playerIsInLOS == false && AIMemorizePlayer == false)
            //{
                //
                //canSpin = true;
                //
                //GoToNoisePosition();
            //}
            //
            //else if (playerIsInLOS == true)
            //{
                //
                //AIMemorizePlayer = true;
                //
                //FacePlayer();
                //
                //ChasePlayer();
            //}
            //
            //else if (AIMemorizePlayer == true && playerIsInLOS == false)
            //{
                //
                //ChasePlayer();
                //
                //StartCoroutine(AIMemory());
            //}
        //}
    //}

    //
    //void NoiseCheck()
    //{
        //
        //float distance = UnityEngine.Vector3.Distance(TankData.playerPos, transform.position);

        //
        //if (distance <= noiseTravelDistance)
        //{
            //
            //if (Input.GetKey(KeyCode.Space))
            //{
                //
                //noisePosition = target.transform.position;
                //
                //AIHeardPlayer = true;
            //}
            //
            //else
            //{
                //
                //AIHeardPlayer = false;
                //
                //canSpin = false;
            //}
        //}
    //}

    //
    //void GoToNoisePosition()
    //{
        //
        //agent.SetDestination(noisePosition);

        //
        //if (Vector3.Distance(transform.position, noisePosition) <= 5f && canSpin == true)
        //{
            //
            //isSpinningTime += Time.deltaTime;
            //
            //transform.Rotate(UnityEngine.Vector3.up * spinSpeed, Space.World);

            //
            //if (isSpinningTime >= spinTime)
            //{
                //
                //canSpin = false;
                //
                //AIHeardPlayer = false;
                //
                //isSpinningTime = 0f;
            //}
        //}
    //}

    //
    //IEnumerator AIMemory()
    //{
        //
        //increasingMemoryTime = 0;

        //
        //while (increasingMemoryTime < memoryStartTime)
        //{
            //
            //increasingMemoryTime += Time.deltaTime;
            //
            //AIMemorizePlayer = true;
            //
            //yield return null;
        //}

        //
        //AIHeardPlayer = false;
        //
        //AIMemorizePlayer = false;
    //}

    //
    //void CheckLOS()
    //{
        //
        //Vector3 direction = target.transform.position - transform.position;

        //
        //float angle = UnityEngine.Vector3.Angle(direction, transform.forward);

        //
        //if (angle < fieldOfViewAngle * 0.5f)
        //{
            //
            //RaycastHit hit;

            //
            //if (Physics.Raycast(transform.position, direction.normalized, out hit, losRadius))
            //{
                //
                //if (hit.collider.tag == "Player")
                //{
                    //
                    //playerIsInLOS = true;
                    //
                    //AIMemorizePlayer = true;
                //}
            //}
        //}
    //}

    //
    //void PatrolAI()
    //{
        //
        //agent.SetDestination(moveSpots[randomSpot].position);

        //
        //if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 2.0f)
        //{
            //
            //randomSpot = Random.Range(0, moveSpots.Length);
            //
            //waitTime = startWaitTime;
        //}
        //
        //else
        //{
            //
            //waitTime -= Time.deltaTime;
        //}
    //}

    //
    //void ChasePlayer()
    //{
        //
        //float distance = UnityEngine.Vector3.Distance(TankData.playerPos, transform.position);

        //
        //if (distance <= chaseRadius && distance > distToPlayer)
        //{
            //
            //agent.SetDestination(TankData.playerPos);
        //}
        //
        //else if (agent.isActiveAndEnabled && distance <= distToPlayer)
        //{
            //
            //randomStrafeDir = Random.Range(0, 2);
            //
            //randomStrafeStartTime = Random.Range(minStrafe, maxStrafe);

            //
            //if (waitStrafeTime <= 0)
            //{
                //
                //if (randomStrafeDir == 0)
                //{
                    //
                    //agent.SetDestination(strafeLeft.position);
                //}
                //
                //else
                //if (randomStrafeDir == 1)
                //{
                    //
                    //agent.SetDestination(strafeRight.position);
                //}

                //
                //waitStrafeTime = randomStrafeStartTime;
            //}
            //
            //else
            //{
                //
                //waitStrafeTime -= Time.deltaTime;
            //}
        //}
    //}

    //
    //void FacePlayer()
    //{
        //
        //Vector3 direction = (TankData.playerPos - transform.position).normalized;
        //
        //Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //
        //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * facePlayerFactor);
        //
        //Shoot();
    //}
}
