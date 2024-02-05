using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField] Rigidbody rb;
    [SerializeField] float velocity;
    [SerializeField] Transform spawnPoint;
    Vector3 lastVelocity;


    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.name == "PitchPlayer1") Debug.Log("Player 1 Scored!");
        if (trigger.gameObject.name == "PitchPlayer2") Debug.Log("Player 2 Scored!");
        transform.position = spawnPoint.position;
        
       
    }


   void Start(){
       rb.velocity = new Vector3(3f,0f,3f);
   }
    void FixedUpdate(){
        lastVelocity = rb.velocity;
        if(rb.velocity.x == 0f || rb.velocity.z == 0f) rb.velocity = new Vector3(3f,0f,3f);
    }

    void OnCollisionEnter(Collision collision){
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed,0f);
    }


    



}