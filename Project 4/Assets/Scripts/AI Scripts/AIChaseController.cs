using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChaseController : AIController
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Switch statment to change the behavior of the AI to either idle, chase, or shoot mode
        switch (currentAIType)
        {
            // If designer changes the AI type to Idle or if AI tank enters Idle mode.
            case AITypes.Idle:
                // Initialize into Idle AI type (AI tank will do nothing)
                // Idle() function call
                Idle();

                // An if statement to check if AI tank should enter chase mode.
                if (Time.time > stateStartTime + 3.0f)
                {
                    // The AI tank will enter chase mode
                    ChangeState(AITypes.Chase);
                }
                // Exit out of case loop
                break;

            // If designer changes the AI type to Chase or if AI tank enters Chase mode.
            case AITypes.Chase:
                // If the pawn AI tank is not null then call the SeekPoint() function
                if (pawn != null)
                {
                    // ChasePlayer function call
                    // Take in consideration of the target, tf(transform), and position paramters
                    ChasePlayer(target.tf.position);
                }

                // An if statement to check if AI tank should enter shoot mode
                if (Vector3.Distance(target.tf.position, pawn.tf.position) < 5.0f)
                {
                    // The AI tank will enter shoot mode
                    ChangeState(AITypes.Shoot);
                }
                // Exit out of case loop
                break;

            // If designer changes the AI type to Shoot or if AI tank enters Shoot mode.
            case AITypes.Shoot:
                // Initialize into Shoot AI type (AI tank will shoot bullets but won't move)
                // Shoot() function call
                Shoot();

                // If the pawn AI tank is not null then shoot bullet
                if (pawn != null)
                {
                    // An if statement to check if AI tank should enter chase mode
                    if (Vector3.Distance(target.tf.position, pawn.tf.position) > 7.0f)
                    {
                        // The AI tank will enter chase mode.
                        ChangeState(AITypes.Chase);
                    }
                }
                // Exit out of case loop
                break;
        }
    }
}
