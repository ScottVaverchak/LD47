using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSway : MonoBehaviour
{
    public PlayerMotor player;
    private float ang = 0.0f;
    
    void Update()
    {
        if(player.IsMoving) {
            ang += 0.01f;
            // @TODO(sjv): This isn't good my dude - this should be smoother 
            transform.position += new Vector3(0.0f, Mathf.Sin(ang) * 0.125f * Time.deltaTime, 0.0f);
        }
    }
}
