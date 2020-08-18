using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHorizontalWalls : MonoBehaviour
{
    // GameObject component variable that will attach to the spawnee 
    public GameObject spawnee;
    // The amount of seconds it would take to spawn a new object
    public float spawnDelay;
    // Public float variable providing the range in the x position
    public float xPos;
    // Public float variable providing the range in the z position
    public float zPos;
    // private int that will count the amount of spawning objects
    private int count = 0;
    // public int that will give the editor/designer the option to decide how many objects to spawn
    public int amount;

    // Start is called before the first frame update
    void Start()
    {
        // SpawnObject function recall
        // Starting the coroutine on the SpawnObject method
        StartCoroutine(SpawnObject());
    }

    // Converted from void to IEnumerator to allow the usage of a coroutine
    IEnumerator SpawnObject()
    {
        // While loop that will keep spawning objects until the count variable equals the amount
        while (count < amount)
        {
            // Randomize and choose where to put the object within the x position
            // Range(30, -30)
            xPos = UnityEngine.Random.Range(30, -30);
            // Randomize and choose where to put the object within the z position
            // Range(30,-30)
            zPos = UnityEngine.Random.Range(30, -30);
            // Place the spawning object at the generated coordinates
            Instantiate(spawnee, new Vector3(xPos, 1.8f, zPos), Quaternion.identity);
            // Wait how every many seconds in spawnDelay variable
            yield return new WaitForSeconds(spawnDelay);
            // Increment count variable by 1
            count += 1;
        }
    }
}
