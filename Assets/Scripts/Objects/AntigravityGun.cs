using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntigravityGun : MonoBehaviour
{
    public Rigidbody PlayerRigidBody;
    public GameObject ExplosionPrefab;
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
            var pt = transform.parent.transform;
            currentReload = 0.0f;
            // @TODO(sjv): Add particle on fire
            RaycastHit info;
            // @MAGIC(sjv): 1 << 8 should be a proper LayerMask
            if(Physics.Raycast(pt.position, pt.forward, out info, Mathf.Infinity, 1 << 8, QueryTriggerInteraction.Ignore)) {
                // Modify force based on that (use a curve my man)
                // @TODO(sjv): Add particle on hit
                PlayerRigidBody.AddExplosionForce(2000.0f, info.point, 50.0f);
                Instantiate(ExplosionPrefab, info.point, Quaternion.identity);
            }
        }
    }
}
