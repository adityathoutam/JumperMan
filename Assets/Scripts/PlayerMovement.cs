using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float intialvelocity = 0f;
    public float accelaration = 20f; //20m/sec
    public float height = 1f;

    bool isGrounded =false;

    //u2 - v2 =2as
    // v2 =2as -u2;
    //v= sqrt(2(20f,1f), 0*0);

	void Update ()
    {
        float finalvelocity = Mathf.Sqrt(2f * (accelaration * height) + intialvelocity * intialvelocity);

        this.transform.Translate(new Vector3(0, 0, 0.5f));



        if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {   
            if(isGrounded)
            {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, finalvelocity, 0);
            isGrounded=false;
            }
        }
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.gameObject.tag=="Base")
       isGrounded=true;
    }
    
}
