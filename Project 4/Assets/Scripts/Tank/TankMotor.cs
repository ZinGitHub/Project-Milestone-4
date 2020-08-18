using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// RequireComponent attribute which will automatically add the required components as dependencies
[RequireComponent(typeof(TankData))]
public class TankMotor : MonoBehaviour
{
    // Reference to the Character Controller component.
    private CharacterController characterController;
    // Public field TankData contained in data
    public TankData data;

    // Start is called before the first frame update
    void Start()
    {
        // The variable characterController will contain the component CharacterController
        characterController = GetComponent<CharacterController>();
        // The variable data will contain the component TankData
        data = gameObject.GetComponent<TankData>();
    }

    // Function handling Moving the tank
    // parameter = Vector3 worldDirectionToMove
    public void Move(Vector3 worldDirectionToMove)
    {
        // Create a vector3 variable
        // Set the vector3 variable to data.tf fields
        // TransformDirection = transforms direction from local space to world space
        // worldDirectionToMove parameter
        Vector3 directionToMove = data.tf.TransformDirection(worldDirectionToMove);

        // Move the tank according to SimpleMove speed
        characterController.SimpleMove(directionToMove * data.moveSpeed);
    }

    // Function handling Rotating the tank
    // parameter = float direction
    public void Rotate(float direction)
    {
        // Algorithm calcaultion for the rotation
        data.tf.Rotate(new Vector3(0, direction * data.rotateSpeed * Time.deltaTime, 0));
    }

    // Function handling the forward rotation
    // parameter = Vector3 lookVector
    public void RotateTowards(Vector3 lookVector)
    {
        // Create a Vector3 variable vectorToTarget and set it to the lookVector parameter
        Vector3 vectorToTarget = lookVector;

        // Quaternion are used to represent rotations
        // Create a quaternion and set it to LookRotation which will
        // create a rotation with the specified forward and upwards directions
        Quaternion targetQuaternion = Quaternion.LookRotation(vectorToTarget, Vector3.up);

        // Algorithm calculation for the forward rotation
        data.tf.rotation =
            Quaternion.RotateTowards(data.tf.rotation, targetQuaternion, data.rotateSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
