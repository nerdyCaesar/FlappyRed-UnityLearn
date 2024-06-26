using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerMove : MonoBehaviour
{
    public float moveSpeed = 5;

    public void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
    }
}
