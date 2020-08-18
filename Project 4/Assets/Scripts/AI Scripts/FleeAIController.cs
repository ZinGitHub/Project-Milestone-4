using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FleeAIController : AIController
{
    //public TankData target;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        // Switch statment to change the behavior of the AI to either idle or flee mode
        switch (currentAIType)
        {
            // If designer changes the AI type to Idle or if AI tank enters Idle mode.
            case AITypes.Idle:
                // Initialize into Idle AI type (AI tank will do nothing)
                // Idle() function call
                Idle();

                // An if statement to check if AI tank should enter flee mode.
                if (Time.time > stateStartTime + 3.0f)
                {
                    // The AI tank will enter chase mode
                    ChangeState(AITypes.Flee);
                }
                // Exit out of case loop
                break;

            // If designer changes the AI type to Flee or if AI tank enters Flee mode.
            case AITypes.Flee:
                // Initialize into Flee AI type (AI tank will runaway from player tank)
                // Flee() function call
                Flee();
                // Exit out of case loop
                break;
        }
    }
}
