using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject SpawnPoint;

    private float time;

    // @HACK(sjv)
    // @HACK(sjv)
    private GUIStyle bigFont = new GUIStyle();

    void Start()
    {
        

        if(Player == null) { 
            Debug.LogError("Player is null omg");
        }
    
        SpawnPlayer();





        // @HACK(sjv)
        bigFont.fontSize = 50;

    }

    void Update()
    {
        time -= Time.deltaTime;

        if(time < 0.0f) {
            SpawnPlayer();
        }
    }

    public void AddTime(float t) => time += t;
    
    public void SpawnPlayer() { 
        // @TODO(sjv): The spawn point will probably want a rotation / orientation
        // @TODO(sjv): This should be moved to another class per level
        time = 10.0f;
        Player.transform.position = SpawnPoint.transform.position + Vector3.up * 2.0f;
    }
    
    
    void OnGUI() {
        // @HACK(sjv)
        GUILayout.Label (string.Format("Time Left: {0:0.00}", time), bigFont);
    }
}
