using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthScript : MonoBehaviour
{
    
    public Image healthBar;
    public float playerHealth = 50f;

    private Logic logicScript;


    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }


    // public void Update() 
    // {
    //     if (playerHealth == 0)
    //     {
    //         logicScript.gameOver();
    //     }    


    // }

    //takes a damage parameter and subtracts the player health with it
    public void LoseHealth (float damageTaken)
    {
        playerHealth -= damageTaken;
        healthBar.fillAmount = playerHealth / 50f;
    }


}
