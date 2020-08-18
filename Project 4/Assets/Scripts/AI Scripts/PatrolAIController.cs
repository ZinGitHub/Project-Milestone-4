using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAIController : AIController
{
    // Start is called before the first frame update
    void Start()
    {
        //currentWaypoint = 0;
    }



    // Update is called once per frame
    void Update()
    {
        // Switch statment to change the behavior of the AI to either idle or patrol mode
        //switch (currentState)
        //{
        // If designer changes the AI type to Idle or if AI tank enters Idle mode.
            //case AIStates.Idle:
            // Initialize into Idle AI type (AI tank will do nothing)
            // Idle() function call
            //Idle();
            
            // An if statement to check if AI tank should enter patrol mode.
            //if (Time.time > stateStartTime + 3.0f)
            //{
                // The AI tank will enter patrol mode
                //ChangeState(AIStates.Patrol);
            //}
            // Exit out of case loop
            //break;

            // If designer changes the AI type to Patrol or if AI tank enters Patrol mode.
            //case AIStates.Patrol:
                // Initialize into Patrol AI type (AI tank will patrol using patrol points)
                // Patrol() function call
                //Patrol();
                // Exit out of case loop
                //break;

        //}
    }
}
