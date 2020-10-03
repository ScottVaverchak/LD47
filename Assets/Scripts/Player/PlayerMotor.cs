using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    public float RunSpeed = 1.0f;
    public float JumpForce = 1.0f;
    public GameObject Camera;
    public GameObject Feet;
    public LayerMask LevelLayerMask;
    
    public bool IsMoving { get; private set; }
    
    private bool isGrounded = true;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RaycastHit info;
        if(Physics.Raycast(Feet.transform.position, Vector3.down, out info, Mathf.Infinity, LevelLayerMask, QueryTriggerInteraction.Ignore)) {
            Debug.DrawLine(Feet.transform.position, info.point, Color.red);
            isGrounded = info.distance < 0.2f;
        }

        var jump = Input.GetAxis("Jump");
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        if(jump > 0 && isGrounded) { 
            rb.velocity = new Vector3(0.0f, JumpForce, 0.0f);
            isGrounded = false;
        }

        Debug.DrawRay(Camera.transform.position, Camera.transform.forward * 2.0f, Color.red);

        // @TODO(sjv): This should be a physics based movement system - I think 
        var np = (new Vector3(v, 0, h)).normalized;
        IsMoving = v != 0 || h != 0;

        if(v != 0)
            transform.position +=  Camera.transform.forward * Time.deltaTime * np.x * RunSpeed;

        if(h != 0)
            transform.position +=  Camera.transform.right * Time.deltaTime * np.z * RunSpeed;
    }

    void FixedUpdate() 
    { 
        
    }
}
