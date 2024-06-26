using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Triggerdeath : MonoBehaviour
{
    
    public float damage = 20f;
    private Logic logic; //creating a variable to reference the logic script
    public ParticleSystem deathParticle;
    public bool once = true;
    public float deathDelay = 0.1f;
    
    void Start()
    {   
        //reference the logic script from finding the game object that the script is attached to
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }

    // when trigger activates, increase score
    public void OnTriggerEnter2D(Collider2D other)
    {   
        // when the tag of the player is found
        if (other.gameObject.tag == "PlayerBird" && once) {
            // once = false;

            var emission = deathParticle.emission;
            emission.enabled = true;

            deathParticle.Play();
            Destroy(gameObject, deathDelay); // destroys the object this script is attached to (trigger)
            logic.addScore(1);   // use the function from the logic script and add 1 score
            logic.TakeDamage(damage);  // use the function from the logic script and damage 

        }
    }
}
