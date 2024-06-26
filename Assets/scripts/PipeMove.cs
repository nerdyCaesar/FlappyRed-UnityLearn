using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeMove : MonoBehaviour
{

    public float moveSpeed = 5;
    public float deadZone = -34;

    
    void Update()
    {
    
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        
        if (transform.position.x <= deadZone)
        {
            Destroy(gameObject);
            // Debug.Log("deleted");
        }
    }

}
