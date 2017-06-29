﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    private GameController gamecontroller;
    public static int scoreValue = 10;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gamecontroller = gameControllerObject.GetComponent<GameController>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Boundary")
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy")) 
        {
            return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            gamecontroller.GameOver();
        }
        gamecontroller.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
