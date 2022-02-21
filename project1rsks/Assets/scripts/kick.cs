using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kick : MonoBehaviour
{
    public float kickDist;
    public float kickForce;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") ==true)
        {
            //Draw interaction ray from camera
            Debug.DrawRay(transform.position, transform.forward * kickDist, Color.green, 1.5f);
            // raycast in foward position
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, kickDist) == true)
            {
                //Get direction player is facing
                Vector3 dir = new Vector3(transform.forward.x, -transform.forward.y, transform.forward.z); //-transform.forward.y makes the ball be kicked upwards based on angle(to cancel behaiviour replace with 0)
                //draw kicktrajectory
                Debug.DrawRay(transform.position, dir * 3, Color.red, 1.5f);

                if(hit.collider.tag == "Ball") //is the thing we hit tagged as 'Ball' 
                {
                    if(hit.collider.TryGetComponent(out Rigidbody rb) == true) //try to find the rigid body on the Ball
                    {
                        rb.AddForce(dir * kickForce, ForceMode.Impulse); // add an instant force to the ball
                    }
                }
            }
        }
    }
}
