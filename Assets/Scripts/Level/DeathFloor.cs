using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFloor : MonoBehaviour
{
    private GameManager gameManager;

    void Start() {
        gameManager = GameObject.Find("_GameManager").GetComponent<GameManager>();
    }
    
    void OnTriggerEnter(Collider collision) {
        var who = collision.attachedRigidbody.gameObject.name;

        if(who == "Player") {
            gameManager.SpawnPlayer();
        }
    }

}
