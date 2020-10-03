using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePointHit : MonoBehaviour
{
    public float AdditionalTime = 5.0f;

    private GameManager gameManager;

    void Start() {
        gameManager = GameObject.Find("_GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider collision) {
        var who = collision.attachedRigidbody.gameObject.name;

        if(who == "Player") {
            gameManager.AddTime(AdditionalTime);
            Destroy(gameObject);
        }
    }
}
