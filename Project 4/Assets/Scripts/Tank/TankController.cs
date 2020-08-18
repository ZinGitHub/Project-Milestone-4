using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    // Setting the controller scheme using WASD or ArrowKeys
    public enum ControllerSetting { WASD, ArrowKeys };

    //
    AudioSource shootingSound;

    // Connect data from the TankData class with pawn 
    public TankData pawn;
    // Set the data from the ControllerSetting enum to controllerSetting
    public ControllerSetting controllerSetting;

    private void Awake()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        shootingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // If there is no input action don't move
        Vector3 directionToMove = Vector3.zero;

        // An if statement for if the designer decides to control tank with WASD keys
        if (controllerSetting == ControllerSetting.WASD)
        {
            // Input action for when the W key is used
            if (Input.GetKey(KeyCode.W))
            {
                // Move forward
                directionToMove += Vector3.forward;
            }

            // Input action for when the S key is used
            if (Input.GetKey(KeyCode.S))
            {
                // Move backwards
                directionToMove += -Vector3.forward;
            }

            // Input action for when the A key is used
            if (Input.GetKey(KeyCode.A))
            {
                // Rotate right
                pawn.mover.Rotate(-pawn.rotateSpeed * Time.deltaTime);
            }

            // Input action for when the D key is used
            if (Input.GetKey(KeyCode.D))
            {
                // Rotate Left 
                pawn.mover.Rotate(pawn.rotateSpeed * Time.deltaTime);
            }
        }
        // An else if statment in case the designer decides to control the tank with arrow keys
        else if (controllerSetting == ControllerSetting.ArrowKeys)
        {
            // Input action for when the arrow key is used
            if (Input.GetKey(KeyCode.UpArrow))
            {
                // Move forward
                directionToMove += Vector3.forward;
            }

            // Input action for when the down arrow is used
            if (Input.GetKey(KeyCode.DownArrow))
            {
                // Move backwards
                directionToMove += -Vector3.forward;
            }

            // Input action for when the left arrow is used
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                // Rotate left
                pawn.mover.Rotate(-pawn.rotateSpeed * Time.deltaTime);
            }

            // Input action for when the right arrow is used
            if (Input.GetKey(KeyCode.RightArrow))
            {
                // Rotate right
                pawn.mover.Rotate(pawn.rotateSpeed * Time.deltaTime);
            }

        }

        // Input action for when the space bar is used
        if (Input.GetKey(KeyCode.Space))
        {
            //
            shootingSound.Play();
            // Shoot out a bullet
            pawn.shoot.Shoot(pawn.bulletPrefab);
        }

        // Move according to the Move function from the TankMotor class
        pawn.mover.Move(directionToMove);

    }
}
