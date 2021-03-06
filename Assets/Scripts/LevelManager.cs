﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public float waitToRespawn;

    // Reference to PlayerController.cs 
    public PlayerController thePlayer;

    // Reference to deathSplosion prefab 
    public GameObject deathSplosion;

    public int coinCount; 

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>(); // Looks for PlayerController Script 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Respawn()
    {
        StartCoroutine("RespawnCo"); 
    }

    /* Co-Routines: Runs outside of the normal loop and runs on its own timeline and can carry objects in a certain sequence 
      and wait a little while before things happen. */
   
    public IEnumerator RespawnCo()
    {
		thePlayer.gameObject.SetActive(false); // Deactivates gameObject (Player)

        Instantiate(deathSplosion, thePlayer.transform.position, thePlayer.transform.rotation); // Clones an existing object (deathSplosion)

        yield return new WaitForSeconds(waitToRespawn); // Temporarily delays activation of gameObject (Player)  

		thePlayer.transform.position = thePlayer.respawnPosition; // Moves Player to last stored Respawn Position 

		thePlayer.gameObject.SetActive(true); // Reactivates gameObject (Player)   
	}

    public void AddCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;


    }
}
