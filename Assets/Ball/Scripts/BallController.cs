using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField] Rigidbody rb;
    [SerializeField] float force = 100;
    [SerializeField] Transform spawnPoint;
    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.name == "PitchPlayer1") Debug.Log("Player 1 Scored!");
        if (trigger.gameObject.name == "PitchPlayer2") Debug.Log("Player 2 Scored!");
        transform.position = spawnPoint.position;
        rb.velocity = new Vector3(0,0,0);
       
    }

    public void Hit(){
        //rb.AddForce(Vector3.forward  * force);
        //rb.AddForce(Vector3.left * force);
        rb.velocity = new Vector3(3f,0f,3f);
    }



}
