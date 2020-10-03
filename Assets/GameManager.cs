using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 60.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
    }

    public void AddTime(float t) => time += t;
    
    void OnGUI() {
        GUI.Label (new Rect (25, 25, 100, 30), string.Format("Time Left: {0:0.00}", time));
    }
}
