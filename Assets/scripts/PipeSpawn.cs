using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    
    public GameObject pipe;

    public float spawnRate = 3; //spawn interval of time
    private float timer = 0; //counts the number of seconds
    public float heightOffset = 7;
    


    public void Start()
    {
        spawnPipe();
    }

    public void Update() 
    {

        if (timer < spawnRate){
            timer += Time.deltaTime;
        }
        else{
            spawnPipe();    
            timer = 0;
        }
    }

    void spawnPipe()
    {

        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
