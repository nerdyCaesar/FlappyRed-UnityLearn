using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middlePipe : MonoBehaviour
{

    private Logic logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)   
        {
            logic.addScore(1);
        }
    }

}
