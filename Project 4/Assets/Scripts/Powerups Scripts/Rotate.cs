using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ths line of code will animate an object, specifically the powerups
        // Will rotate the object by its x,y, and z axis.
        // Time.deltaTime will ensure that tha animation rund at the same speed on every device
        transform.Rotate(new Vector3(100f, 50f, 50f) * Time.deltaTime);
    }
}
