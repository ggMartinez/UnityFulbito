using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField] Rigidbody rb;
    [SerializeField] float maxSpeed = 5f;
    [SerializeField] float minSpeed = 2f;
    [SerializeField] Transform spawnPoint;
    Vector3 lastVelocity;





   void Start(){
        lastVelocity = new Vector3(0f,0f,0f);
        // get a random number between -1 and 1
        //rb.velocity = new Vector3(Random.Range(-minSpeed,maxSpeed),0,Random.Range(-minSpeed,maxSpeed));
        rb.velocity = new Vector3(4f,0,4f);

        

   }
    void FixedUpdate(){
        Debug.Log("Velocity: " + rb.velocity + ", Magnitude: " + rb.velocity.magnitude);
        lastVelocity = rb.velocity;
        keepFluidMovement();
        

    }

    void keepFluidMovement(){
        if(rb.velocity.magnitude < maxSpeed)
           rb.velocity = new Vector3(maxSpeed * randomSign(), 0f, maxSpeed * randomSign());
        
       
        
        if(Mathf.Abs(rb.velocity.z) < 1.5f )
            rb.velocity = new Vector3(rb.velocity.x,0f,minSpeed * randomSign());

    }

    void OnCollisionEnter(Collision collision){
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed,0f);
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.name == "PitchPlayer1") Debug.Log("Player 1 Scored!");
        if (trigger.gameObject.name == "PitchPlayer2") Debug.Log("Player 2 Scored!");
        transform.position = spawnPoint.position;
       
    }

    float randomSign()
    {
        if (Random.value >= 0.5)
            return 1f;
        return -1f;
    }


}