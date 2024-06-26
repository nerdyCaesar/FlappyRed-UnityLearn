using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    private const bool V = false;
    public Rigidbody2D rigidBody;

    public Transform birdTransform;
    public float upForce;
    private Logic logic;

    // public Text score;

    public bool isAlive = true;
    

    void Start()
    {
        // rigidBody.gravityScale = 0;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        
    }

    void Update()
    {   
        if (Input.GetKeyDown("space") && isAlive)
        {
            rigidBody.velocity = Vector2.up * upForce;
        }

        if (birdTransform.position.y >= 15 || birdTransform.position.y <= -15) {
            logic.HighScoreUpdate();//updates the highscore after falling beyond the boundary
            logic.gameOver(); //game over fucntion is called
            isAlive = false; // player alive status is set to false
} 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        logic.gameOver();
        logic.HighScoreUpdate();
        isAlive = false;
    }


}
