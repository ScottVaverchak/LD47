using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntigravityGun : MonoBehaviour
{
    public Rigidbody PlayerRigidBody;
    public float ReloadTimer = 1.0f;

    private float currentReload;

    // Start is called before the first frame update
    void Start()
    {
        currentReload = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentReload += Time.deltaTime;
        
        Debug.DrawRay(transform.parent.transform.position, transform.parent.transform.forward * 8.0f, Color.green);

        // If a button is clicked 
        if(Input.GetAxis("Fire1") > 0 && currentReload > ReloadTimer) {
            currentReload = 0.0f;
            // Raycast    
                // Modify force based on that (use a curve my man)
                // update rigibody with boom
            //(float explosionForce, Vector3 explosionPosition, float explosionRadius, float upwardsModifier = 0.0f, ForceMode mode = ForceMode.Force)); 
            PlayerRigidBody.AddExplosionForce(2000.0f, transform.parent.transform.position + transform.parent.transform.forward * 2.0f, 50.0f);
            Debug.Log("Boom");
        }
    }
}
