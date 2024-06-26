using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flapAnimation : MonoBehaviour
{
    public Animator flap__wing;
    private Logic logic;

    void Start() {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }

    
}
