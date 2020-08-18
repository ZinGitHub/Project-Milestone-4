using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // cameraTransform will contain the data on transform(position, rotation, and scale)
    public Transform cameraTransform;
    // Create a vector for the camera
    private Vector3 cameraOffSet;

    // Range attribute for the smooth factor on the camera
    // Adds a slider in the inspector
    [Range(0.01f, 1.0f)]
    // By default the smooth factor of the camera will be set to 0.5f
    public float SmoothFactor = 0.5f;
    // By default the camera will not look at the player
    public bool lookAtPlayer = false;


    // Start is called before the first frame update
    void Start()
    {
        // The cameraOffset vector will be equal to the position of the transform
        // subtracted by the position of the camera transform
        cameraOffSet = transform.position - cameraTransform.position;
    }

    // LateUpdate is called every frame if the behavior is enabled.
    void LateUpdate()
    {
        // Create a new vector for the new position
        // Will equal to the camera transform's position plus the offset of the camera
        Vector3 newPosition = cameraTransform.position + cameraOffSet;

        // The current position of the camera will be calcuted by
        // the vector3 with a slerp which interpolates between two vectors
        // and transform.position, newPosition, SmoothFactor in the field/attributes 
        transform.position = Vector3.Slerp(transform.position, newPosition, SmoothFactor);

        // An if statement for if the designer enables the camera to look at player
        if (lookAtPlayer)
        {
            // Camera will have it's transform rotated so the forward vector is pointing at the target positon
            transform.LookAt(cameraTransform);
        }

    }
}
