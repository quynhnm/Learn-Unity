using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour {

    public static int count;

    GameObject parent;
    ModeController modeController;

    private void Start()
    {
        parent = GameObject.Find("GamePlay");
        modeController = parent.GetComponent<ModeController>();
    }

    public void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
     
        if(player != null)
        {
            gameObject.SetActive(false);
            modeController.spawnItem = gameObject;
            count++;
            modeController.SetCountText();
            modeController.Spawn();
        }
    }

}
