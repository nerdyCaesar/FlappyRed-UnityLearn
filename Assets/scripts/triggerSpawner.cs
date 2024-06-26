using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerSpawner : MonoBehaviour
{
    public GameObject Trigger; //prefab of the trigger

    public float spawnRate = 7; //spawn interval of time
    private float timer = 0; //counts the number of seconds
    public float heightOffset = 10;
    public float widthOffset = 5;
    public float currentNumberOfTriggers = 0;
    public float maxNumberOfTriggers = 5;

    
    public void Update() {
        if (timer < spawnRate) {
            timer += Time.deltaTime;
        }
        else {
            if (currentNumberOfTriggers < maxNumberOfTriggers) {
                spawnTrigger();
            }
        }
    }
    
    public void spawnTrigger() {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        float nearestPoint = transform.position.x - widthOffset;
        float farthestPoint = transform.position.x + widthOffset;

        Vector3 spawnPos = new Vector3(Random.Range(nearestPoint, farthestPoint), Random.Range(lowestPoint, highestPoint), 0);
        
        Instantiate(Trigger, spawnPos, Quaternion.identity);
        currentNumberOfTriggers++;


    }
}
